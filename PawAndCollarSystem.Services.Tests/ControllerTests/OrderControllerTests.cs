using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PawAndCollar.Web.Controllers;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PawAndCollar.Data.Models.Enums;
using Microsoft.Extensions.Caching.Memory;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PawAndCollar.Services.Data.Models.Order;

namespace PawAndCollarSystem.Services.Tests.ControllerTests
{
	[TestFixture]
	public class OrderControllerTests
	{
		private OrderController _controller;
		private Mock<IOrderService> _orderServiceMock;
		private Mock<IEnumService> _enumServiceMock;
		private Mock<IProductService> _productServiceMock;
		private Mock<IMemoryCache> _memoryCacheMock;
		private Mock<IApplicationUserService> _applicationUserServiceMock;
		private Mock<ITempDataDictionary> _tempDataMock;

		[SetUp]
		public void Setup()
		{
			_orderServiceMock = new Mock<IOrderService>();
			_enumServiceMock = new Mock<IEnumService>();
			_productServiceMock = new Mock<IProductService>();
			_memoryCacheMock = new Mock<IMemoryCache>();
			_applicationUserServiceMock = new Mock<IApplicationUserService>();
			_tempDataMock = new Mock<ITempDataDictionary>();

			_controller = new OrderController(
				_orderServiceMock.Object,
				_enumServiceMock.Object,
				_productServiceMock.Object,
				_memoryCacheMock.Object,
				_applicationUserServiceMock.Object
			)
			{
				TempData = _tempDataMock.Object
			};
		}

		[Test]
		public async Task Summary_UserIsAuthenticated_ReturnsViewResultWithOrderSummaryViewModel()
		{
			string userId = "user123";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
						new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.GetOrderSummaryProductAsync(userId))
				.ReturnsAsync(new List<OrderSummaryProductViewModel>());

			_enumServiceMock.Setup(s => s.GetEnumSelectList<PaymentTypes>())
				.Returns(new List<SelectListItem>());

			// Act
			var result = await _controller.Summary() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.IsNull(result.ViewName);
			Assert.IsInstanceOf<OrderSummaryViewModel>(result.Model);
			var model = result.Model as OrderSummaryViewModel;
			Assert.IsNotNull(model.PaymentMethods);
			Assert.AreEqual(0, model.OrderedItems.Count);
		}

		[Test]
		public async Task Summary_Post_ValidModel_ReturnsRedirectToActionIndex()
		{
			// Arrange
			var summaryViewModel = new OrderSummaryViewModel
			{
				PaymentMethod = 2,
				OrderedItems = new List<OrderSummaryProductViewModel>
			{
				new OrderSummaryProductViewModel { Id = 1, Quantity = 1 },
				new OrderSummaryProductViewModel { Id = 2, Quantity = 2 }
			}
			};


			string userId = "user123";

			var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
		new Claim(ClaimTypes.NameIdentifier, userId)
			}, "test"));

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext { User = user }
			};

			_orderServiceMock.Setup(s => s.GetOrderNumberAsync(userId))
							.ReturnsAsync(Guid.Parse("5d6eb967-90b5-4b97-8a77-48007df80fa5"));
			_productServiceMock.Setup(s => s.GetAllProductsForQuantityTestAsync())
				  .ReturnsAsync(new List<ProductsForTestOrderQuantityViewModel>
				  {
					  new ProductsForTestOrderQuantityViewModel { Id = 1, Quantity = 5 },
					  new ProductsForTestOrderQuantityViewModel { Id = 2, Quantity = 5 }
				  });
			_memoryCacheMock.Setup(mc => mc.Remove(It.IsAny<object>()));

			var result = await _controller.Summary(summaryViewModel) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
		}

		[Test]
		public async Task ManageOrders_WithAdminUser_ReturnsViewWithOrders()
		{
			string userId = "adminUserId";
			var orders = new AllOrdersFilteredAndPagedServiceModel
			{
				Orders = new List<OrderDetailsViewModel>
		{
			new OrderDetailsViewModel { Id = "1", OrderNumber = "ORD123" },
			new OrderDetailsViewModel { Id = "2", OrderNumber = "ORD124" }
		},
				TotalOrdersCount = 2
			};

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Role, "Administrator")
			}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.GetAllOrdersAsync(It.IsAny<AllOrdersQueryModel>()))
				.ReturnsAsync(orders);

			_orderServiceMock.Setup(s => s.GetAllOrderStatusesAsync())
				.ReturnsAsync(new List<string>());

			var result = await _controller.ManageOrders(new AllOrdersQueryModel()) as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual(orders.Orders, (result.Model as AllOrdersQueryModel)?.Orders);
		}

		[Test]
		public async Task ManageOrders_WithNoAdminUser_ReturnsNull()
		{
			string userId = "noadminUser";
			var orders = new AllOrdersFilteredAndPagedServiceModel
			{
				Orders = new List<OrderDetailsViewModel>
		{
			new OrderDetailsViewModel { Id = "1", OrderNumber = "ORD123" },
			new OrderDetailsViewModel { Id = "2", OrderNumber = "ORD124" }
		},
				TotalOrdersCount = 2
			};

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Role, "User")
			}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.GetAllOrdersAsync(It.IsAny<AllOrdersQueryModel>()))
				.ReturnsAsync(orders);

			_orderServiceMock.Setup(s => s.GetAllOrderStatusesAsync())
				.ReturnsAsync(new List<string>());

			var result = await _controller.ManageOrders(new AllOrdersQueryModel()) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
		}

		[Test]
		public async Task MyOrders_WithValidUser_ReturnsViewWithOrders()
		{
			string userId = "validUserId";
			var orderModels = new List<OrderViewModel>()
			{
				new OrderViewModel { Id = "1"},
				new OrderViewModel { Id = "2"}
			};

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.GetMyOrdersAsync(userId))
				.ReturnsAsync(orderModels);

			var result = await _controller.MyOrders() as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual(orderModels, result.Model as List<OrderViewModel>);
		}

		[Test]
		public async Task MyOrders_WithInvalidUser_ReturnsRedirectToHome()
		{
			// Arrange
			string invalidUserId = "invalidUserId";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, invalidUserId)
					}, "test"))
				}
			};

			var result = await _controller.MyOrders() as RedirectToActionResult;


			Assert.IsNull(result);
		}

		[Test]
		public async Task Details_WithAdminUser_ReturnsViewWithOrderDetails()
		{
			// Arrange
			string userId = Guid.NewGuid().ToString();
			string orderId = "orderId";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Role, "Administrator")
					}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.GetOrderDetailsAsync(orderId))
				.ReturnsAsync(new OrderDetailsViewModel { Id = orderId });

			var result = await _controller.Details(orderId) as ViewResult;

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.Model as OrderDetailsViewModel);
		}

		[Test]
		public async Task Details_WithNonAdminUserAndUsersOrder_ReturnsViewWithOrderDetails()
		{
			string userId = Guid.NewGuid().ToString();
			string orderId = "orderId";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Role, "User")
					}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.IsUsersOrderAsync(orderId, userId))
				.ReturnsAsync(true);

			_orderServiceMock.Setup(s => s.GetOrderDetailsAsync(orderId))
				.ReturnsAsync(new OrderDetailsViewModel { Id = orderId });

			var result = await _controller.Details(orderId) as ViewResult;

			Assert.IsNotNull(result);
			Assert.IsNotNull(result.Model as OrderDetailsViewModel);
		}

		[Test]
		public async Task Details_WithNonAdminUserAndNotUsersOrder_ReturnsRedirectToHome()
		{
			string userId = Guid.NewGuid().ToString();
			string orderId = "orderId";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.IsUsersOrderAsync(orderId, userId))
				.ReturnsAsync(false);

			var result = await _controller.Details(orderId) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
		}


		[Test]
		public async Task UpdateStatus_WithAdminUser_ReturnsRedirectToDetailsWithSuccessMessage()
		{
			string userId = "adminUserId";
			string orderId = "orderId";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId),
				new Claim(ClaimTypes.Role, "Administrator")
					}, "test"))
				}
			};

			_orderServiceMock.Setup(s => s.GetOrderDetailsAsync(orderId))
				.ReturnsAsync(new OrderDetailsViewModel { Id = orderId });

			var result = await _controller.UpdateStatus(new OrderDetailsViewModel { Id = orderId, Status = "NewStatus" }) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Details", result.ActionName);
			Assert.AreEqual(orderId, result.RouteValues["id"]);
		}

		[Test]
		public async Task UpdateStatus_WithNonAdminUser_ReturnsUnauthorized()
		{
			string userId = "validUserId";

			_controller.ControllerContext = new ControllerContext
			{
				HttpContext = new DefaultHttpContext
				{
					User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
					{
				new Claim(ClaimTypes.NameIdentifier, userId)
					}, "test"))
				}
			};

			var orderDetailsViewModel = new OrderDetailsViewModel
			{
				Id = "orderId",
				Status = "NewStatus",
				OrderNumber = "ORD123",
				PaymentMethod = "CreditCard",
				ShippingAddress = "123 Main St",
				OrderedItems = new List<OrderSummaryProductViewModel>()
			};

			_orderServiceMock.Setup(s => s.GetOrderDetailsAsync(It.IsAny<string>()))
	               .ReturnsAsync(new OrderDetailsViewModel
	               {
		              Id = "orderId",
					  Status = "NewStatus",
					  OrderNumber = "ORD123",
					  PaymentMethod = "CreditCard",
					  ShippingAddress = "123 Main St",
					  OrderedItems = new List<OrderSummaryProductViewModel>()
	               });


			var result = await _controller.UpdateStatus(orderDetailsViewModel) as RedirectToActionResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Index", result.ActionName);
			Assert.AreEqual("Home", result.ControllerName);
		}

	}
}
