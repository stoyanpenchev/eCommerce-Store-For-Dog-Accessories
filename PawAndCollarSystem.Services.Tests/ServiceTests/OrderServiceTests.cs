using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollarServices.Interfaces;
using PawAndCollarServices;
using System.Threading.Tasks;
using System;
using PawAndCollarSystem.Services.Tests.CreatorTests;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollar.Web.ViewModels.Product;
using System.Collections.Generic;
using System.Linq;
using PawAndCollar.Services.Data.Models.Order;
using PawAndCollar.Web.ViewModels.Order.Enums;
using PawAndCollar.Data.Models.Enums;

namespace PawAndCollarSystem.Services.Tests.ServiceTests
{
	using static DatabaseSeeder;
	public class OrderServiceTests
	{
		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private ICreatorService creatorService;
		private ICartService cartService;
		private IProductService productService;
		private OrderService orderService;

		[SetUp]
		public async Task OneTimeSetup()
		{
			this.dbOptions = new DbContextOptionsBuilder<PawAndCollarDbContext>()
				.UseInMemoryDatabase("PawAndCollarInMemory" + Guid.NewGuid().ToString())
				.Options;
			dbContext = new PawAndCollarDbContext(this.dbOptions, false);

			await dbContext.Database.EnsureDeletedAsync();
			await this.dbContext.Database.EnsureCreatedAsync();
			SeedDatabase(dbContext);

			this.orderService = new OrderService(this.dbContext);
			this.creatorService = new CreatorService(this.dbContext);
			this.cartService = new CartService(this.dbContext);
			this.productService = new ProductService(this.dbContext);
		}

		[Test]
		public async Task AddOrderSummaryAsync_ShouldCreateOrder()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			OrderSummaryViewModel orderModel = new OrderSummaryViewModel()
			{
				CustomerName = "Customer Name",
				Phone = "+359885434543",
				OrderNumber = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD96"),
				ShippingAddress = "TestTest Test TestTest",
				PaymentMethod = 3,
				OrderedItems = new List<OrderSummaryProductViewModel>()
				{
					new OrderSummaryProductViewModel()
					{
						Id = productId,
						Quantity = 1,
						Name = ProductCollar.Name,
						Price = ProductCollar.Price
					}
				}
			};

			await this.orderService.AddOrderSummaryAsync(orderModel, userId);

			Assert.AreEqual(1, User.BuyedProducts.Count);
			Assert.AreEqual(1, User.Orders.Count);
			Assert.IsTrue(User.BuyedProducts.Any(bp => bp.Id == productId));
		}

		[Test]
		public async Task AddOrderSummaryAsync_ShouldReturnNullIfUserIdIsIncorrect()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			OrderSummaryViewModel orderModel = new OrderSummaryViewModel()
			{
				CustomerName = "Customer Name",
				Phone = "+359885434543",
				OrderNumber = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD96"),
				ShippingAddress = "TestTest Test TestTest",
				PaymentMethod = 3,
				OrderedItems = new List<OrderSummaryProductViewModel>()
				{
					new OrderSummaryProductViewModel()
					{
						Id = productId,
						Quantity = 1,
						Name = ProductCollar.Name,
						Price = ProductCollar.Price
					}
				}
			};

			Assert.ThrowsAsync<InvalidOperationException>(async () =>
			{
				await this.orderService.AddOrderSummaryAsync(orderModel, "3CB1A657-3D82-483C-8932-F53CD637BD96");
			});
		}

		[Test]
		public async Task GetAllOrdersAsync_ShouldGetAllOrders()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			OrderViewModel orderModel = new OrderViewModel()
			{
				Id = order.Id.ToString(),
				CustomerName = order.CustomerName,
				PhoneNumber = "+359884376854",
				OrderDate = order.OrderDate.ToString(),
				Email = order.Customer.Email,
				Status = order.Status.ToString(),
				TotalPrice = order.TotalAmount
			};

			AllOrdersQueryModel allOrdersQueryModel = new AllOrdersQueryModel()
			{
				CurrentPage = 1,
				OrderSorting = (OrderSorting)2,
				OrdersPerPage = 1,
				Orders = new List<OrderViewModel>()
				{
					orderModel
				}
			};

			var result = await this.orderService.GetAllOrdersAsync(allOrdersQueryModel);

			Assert.AreEqual(2, result.TotalOrdersCount);
		}

		[Test]
		public async Task GetAllOrderStatusesAsync_ShouldGetAllOrderStatusesWithoutCancelled()
		{
			var result = await this.orderService.GetAllOrderStatusesAsync();

			Assert.AreEqual(1, result.Count);
		}

		[Test]
		public async Task GetMyOrdersAsync_ShouldGetOrders()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			var result = await this.orderService.GetMyOrdersAsync(userId);

			Assert.AreEqual(1, result.Count);
			Assert.IsTrue(result.Any(o => o.CustomerName == User.UserName));
		}

		[Test]
		public async Task GetOrderDetailsAsync_ShouldGetOrderDetails()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			var result = await this.orderService.GetOrderDetailsAsync(order.Id.ToString());

			Assert.AreEqual(order.OrderNumber.ToString(), result.OrderNumber);
		}

		[Test]
		public async Task GetOrderDetailsAsync_ShouldReturnNullIfIdIsInvalid()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			var result = await this.orderService.GetOrderDetailsAsync("7B724B4E-70EA-42BC-5992-08DB77F1F68E");

			Assert.IsNull(result);
		}

		[Test]
		public async Task GetOrderNumberAsync_ShouldGetOrderNumber()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			Guid orderNumber = order.OrderNumber;
			var result = await this.orderService.GetOrderNumberAsync(userId);

			Assert.AreEqual(orderNumber, result);
		}

		[Test]
		public async Task GetOrderNumberAsync_ShouldReturnNullWhenUserIdIsInvalid()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			var result = await this.orderService.GetOrderNumberAsync("7B729B4E-70EA-42BC-5992-08DB77F1F68E");

			Assert.AreNotEqual(order.OrderNumber.ToString(), result);
		}

		[Test]
		public async Task GetOrderSummaryProductAsync_ShouldGetOrderSummaryProduct()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			var result = await this.orderService.GetOrderSummaryProductAsync(userId);

			Assert.AreEqual(1, result.Count);
			Assert.IsTrue(result.Any(p => p.Id == productId));
		}


		[Test]
		public async Task GetOrderSummaryProductAsync_ShouldReturnNullWhenUserIdIsInvalid()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			var result = await this.orderService.GetOrderSummaryProductAsync("7B729B4E-70EA-42BC-5112-08DB77F1F68E");

			Assert.IsNull(result);
		}

		[Test]
		public async Task IsUsersOrderAsync_ShouldReturnTrueIfUserIdIsCorrect()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();
			var result = await this.orderService.IsUsersOrderAsync(order.Id.ToString(), userId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task IsUsersOrderAsync_ShouldReturnFalseIfUserIdIsIncorrect()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();
			var result = await this.orderService.IsUsersOrderAsync("7B729B4E-70EA-42BC-5112-08DB77F1F68E", userId);

			Assert.IsFalse(result);
		}

		[Test]
		public async Task UpdateOrderStatusAsync_ShouldUpdateOrderStatus()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;
			string productName = ProductCollar.Name;
			decimal productPrice = ProductCollar.Price;
			int productQuantity = ProductCollar.Quantity;

			await this.cartService.AddToCartAsync(userId, productId);
			var order = User.Orders.First();

			var orderViewModel = new OrderDetailsViewModel()
			{
				Id = order.Id.ToString(),
				OrderNumber = order.OrderNumber.ToString(),
				PaymentMethod = order.PaymentMethod.ToString(),
				Status = "Shipped",
				ShippingAddress = order.ShippingAddress,
			};
			orderViewModel.OrderedItems.Add(new OrderSummaryProductViewModel()
			{
				Id = productId,
				Name = productName,
				Price = productPrice,
				Quantity = productQuantity,
			});

			await this.orderService.UpdateOrderStatusAsync(orderViewModel);

			Assert.AreEqual(OrderStatus.Shipped, order.Status);
			
		}

		[Test]
		public async Task UserPurchasedProductAsync_ShouldReturnTrueIfUserPurchasedProduct()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			OrderSummaryViewModel orderModel = new OrderSummaryViewModel()
			{
				CustomerName = "Customer Name",
				Phone = "+359885434543",
				OrderNumber = Guid.Parse("3CB1A657-3D82-483C-8932-F53CD637BD96"),
				ShippingAddress = "TestTest Test TestTest",
				PaymentMethod = 3,
				OrderedItems = new List<OrderSummaryProductViewModel>()
				{
					new OrderSummaryProductViewModel()
					{
						Id = productId,
						Quantity = 1,
						Name = ProductCollar.Name,
						Price = ProductCollar.Price
					}
				}
			};

			await this.orderService.AddOrderSummaryAsync(orderModel, userId);

			var result = await this.orderService.UserPurchasedProductAsync(userId, productId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task UserPurchasedProductAsync_ShouldReturnFalseIfUserDidNotPurchasedProduct()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			var result = await this.orderService.UserPurchasedProductAsync(userId, productId);

			Assert.IsFalse(result);
		}
	}
}
