using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollarServices.Interfaces;
using PawAndCollar.Data.Models.Enums;
namespace PawAndCollar.Web.Controllers
{
    using static PawAndCollar.Common.NotificationMessagesConstants;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IEnumService enumService;
        public OrderController(IOrderService orderService, IEnumService enumService)
        {
            this.orderService = orderService;
            this.enumService = enumService;

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
            var errors = ModelState
              .Where(x => x.Value.Errors.Count > 0)
              .Select(x => new { x.Key, x.Value.Errors })
              .ToArray();
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
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your new Product! Please try again later or contact administrator!");
                summaryViewModel.PaymentMethods = this.enumService.GetEnumSelectList<PaymentTypes>();
                summaryViewModel.OrderedItems = await this.orderService.GetOrderSummaryProductAsync(userId);
                return this.View(summaryViewModel);
            }
        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
            return this.RedirectToAction("Index", "Home");
        }
    }
}
