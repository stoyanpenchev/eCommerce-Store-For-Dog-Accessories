using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollarServices.Interfaces;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollar.Services.Data.Models.Order;

namespace PawAndCollar.Web.Controllers
{
    using static PawAndCollar.Common.NotificationMessagesConstants;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IEnumService enumService;
        private readonly IProductService productService;
        private readonly IApplicationUserService applicationUserService;
        public OrderController(IOrderService orderService, IEnumService enumService, IProductService productService, IApplicationUserService applicationUserService)
        {
            this.orderService = orderService;
            this.enumService = enumService;
            this.productService = productService;
            this.applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Summary()
        {
            string userId = this.User.GetId()!;
            try
            {
                OrderSummaryViewModel summaryViewModel = new OrderSummaryViewModel();
                summaryViewModel.PaymentMethods = this.enumService.GetEnumSelectList<PaymentTypes>();
                summaryViewModel.OrderedItems = await this.orderService.GetOrderSummaryProductAsync(userId);
                return this.View(summaryViewModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Summary(OrderSummaryViewModel summaryViewModel)
        {
            string userId = this.User.GetId()!;
            summaryViewModel.OrderNumber = await this.orderService.GetOrderNumberAsync(userId);

            if (summaryViewModel.PaymentMethod == 0)
            {
                this.ModelState.AddModelError(nameof(summaryViewModel.PaymentMethod), "Please select a payment method!");
            }

            ICollection<ProductsForTestOrderQuantityViewModel> products = await this.productService.GetAllProductsForQuantityTestAsync();
            foreach (var item in summaryViewModel.OrderedItems)
            {
                if (products.Any(p => p.Id == item.Id && p.Quantity < item.Quantity))
                {
                    this.TempData[ErrorMessage] = string.Format("Your Product with name {0} has less quantity in stock than you want!", item!.Name);
                    return this.RedirectToAction("ViewCart", "Cart");
                }
            }

            if (!this.ModelState.IsValid)
            {
                summaryViewModel.PaymentMethods = this.enumService.GetEnumSelectList<PaymentTypes>();
                summaryViewModel.OrderedItems = await this.orderService.GetOrderSummaryProductAsync(userId);
                return this.View(summaryViewModel);
            }
            try
            {
                await this.orderService.AddOrderSummaryAsync(summaryViewModel, userId);
                this.TempData[SuccessMessage] = "Order created successfully!";
                return this.RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException)
            {
                summaryViewModel.PaymentMethods = this.enumService.GetEnumSelectList<PaymentTypes>();
                summaryViewModel.OrderedItems = await this.orderService.GetOrderSummaryProductAsync(userId);
                return this.View(summaryViewModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your new Product! Please try again later or contact administrator!");
                summaryViewModel.PaymentMethods = this.enumService.GetEnumSelectList<PaymentTypes>();
                summaryViewModel.OrderedItems = await this.orderService.GetOrderSummaryProductAsync(userId);
                return this.View(summaryViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageOrders([FromQuery] AllOrdersQueryModel queryModel)
        {
            string userId = this.User.GetId()!;
            if(!this.User.IsAdministrator())
            {
                this.TempData[ErrorMessage] = "You are not authorized to view this page!";
                return this.RedirectToAction("Index", "Home");
            }
            try
            {
                AllOrdersFilteredAndPagedServiceModel orders = await this.orderService.GetAllOrdersAsync(queryModel);
                queryModel.Orders = orders.Orders;
                queryModel.TotalOrders = orders.TotalOrdersCount;
                queryModel.Statuses = await this.orderService.GetAllOrderStatusesAsync();
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string orderId)
        {
            if(!this.User.IsAdministrator())
            {
                this.TempData[ErrorMessage] = "You are not authorized to view this page!";
				return this.RedirectToAction("Index", "Home");
			}
            try
            {
				OrderViewModel orderDetailsViewModel = await this.orderService.GetOrderDetailsAsync(orderId);
				return this.View(orderDetailsViewModel);
			}
			catch (Exception)
            {
				return this.GeneralError();
			}
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}
