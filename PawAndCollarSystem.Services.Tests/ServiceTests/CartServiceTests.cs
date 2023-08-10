using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollarServices.Interfaces;
using PawAndCollarServices;
using System.Threading.Tasks;
using System;
using PawAndCollarSystem.Services.Tests.CreatorTests;
using PawAndCollar.Web.ViewModels.Cart;
using System.Linq;

namespace PawAndCollarSystem.Services.Tests.ServiceTests
{
	using static DatabaseSeeder;
	public class CartServiceTests
	{
		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private ICreatorService creatorService;
		private ICartService cartService;
		private IProductService productService;

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

			this.creatorService = new CreatorService(this.dbContext);
			this.cartService = new CartService(this.dbContext);
			this.productService = new ProductService(this.dbContext);
		}

		[Test]
		public async Task AddToCartAsync_WithValidData_ShouldAddToCart()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			Assert.AreEqual(1, this.dbContext.Carts.CountAsync().Result);
			Assert.AreEqual(3, this.dbContext.Orders.CountAsync().Result);
			Assert.AreEqual(1, this.dbContext.OrderedItems.CountAsync().Result);
			Assert.IsTrue(this.dbContext.OrderedItems.AnyAsync(oi => oi.ProductId == productId).Result);
			Assert.IsTrue(this.dbContext.Orders.AnyAsync(o => o.CustomerId.ToString() == userId).Result);
			Assert.IsTrue(this.dbContext.Carts.AnyAsync(c => c.UserId.ToString() == userId).Result);
		}

		[Test]
		public async Task AddToCartAsync_WithInValidData_ShouldNotAddToCart()
		{
			string userId = User.Id.ToString();

			Assert.ThrowsAsync<ArgumentException>(async () => await this.cartService.AddToCartAsync(userId, 0));
		}

		[Test]
		public async Task DecreaseQuantityAsync_ShouldDecreaseQuantity()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			await this.cartService.DecreaseQuantityAsync(userId, productId);

			Assert.AreEqual(1, this.dbContext.Carts.CountAsync().Result);
			Assert.AreEqual(3, this.dbContext.Orders.CountAsync().Result);
			Assert.AreEqual(0, this.dbContext.OrderedItems.CountAsync().Result);
			Assert.IsFalse(this.dbContext.OrderedItems.AnyAsync(oi => oi.ProductId == productId).Result);
			Assert.IsTrue(this.dbContext.Orders.AnyAsync(o => o.CustomerId.ToString() == userId).Result);
			Assert.IsTrue(this.dbContext.Carts.AnyAsync(c => c.UserId.ToString() == userId).Result);
		}

		[Test]
		public async Task DecreaseQuantityAsync_WithInValidData_ShouldNotDecreaseQuantity()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;
			await this.cartService.AddToCartAsync(userId, productId);
			await this.cartService.DecreaseQuantityAsync(userId, 0);

			Assert.AreEqual(1, this.dbContext.OrderedItems.CountAsync().Result);
			Assert.AreEqual(1, this.dbContext.Carts.CountAsync().Result);
			Assert.AreEqual(3, this.dbContext.Orders.CountAsync().Result);
			Assert.IsTrue(this.dbContext.OrderedItems.AnyAsync(oi => oi.ProductId == productId).Result);
			Assert.IsTrue(this.dbContext.Orders.AnyAsync(o => o.CustomerId.ToString() == userId).Result);
			Assert.IsTrue(this.dbContext.Carts.AnyAsync(c => c.UserId.ToString() == userId).Result);
		}

		[Test]
		public async Task IncreaseQuantityAsync_ShouldIncreaseQuantity()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			await this.cartService.IncreaseQuantityAsync(userId, productId);

			decimal excpectedPrice = ProductCollar.Price * 2;

			Assert.AreEqual(excpectedPrice, User.ActiveCart.TotalPrice);
		}

		[Test]
		public async Task IncreaseQuantityAsync_WithInValidData_ShouldNotIncreaseQuantity()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			await this.cartService.IncreaseQuantityAsync(userId, 0);

			decimal excpectedPrice = ProductCollar.Price;
			
			Assert.AreEqual(excpectedPrice, User.ActiveCart.TotalPrice);
		}

		[Test]
		public async Task GetCartItemsAsync_ShouldGetCartItems()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			int product2Id = ProductHarness.Id;
			await this.cartService.AddToCartAsync(userId, product2Id);

			ViewCartViewModel cartItems = await this.cartService.GetCartItemsAsync(userId);

			string productCollarName = cartItems.CartItems.FirstOrDefault(p => p.Name == ProductCollar.Name).Name;

			Assert.AreEqual(ProductCollar.Name, productCollarName);
		}

		[Test]
		public async Task GetCartItemsAsync_WithInValidData_ShouldNotGetCartItems()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			int product2Id = ProductHarness.Id;
			await this.cartService.AddToCartAsync(userId, product2Id);

			Assert.ThrowsAsync<InvalidOperationException>(async () => await this.cartService.GetCartItemsAsync("0"));
		}

		[Test]
		public async Task GetCartItemsCountAsync_ShouldGetCartItemsCount()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);

			int product2Id = ProductHarness.Id;
			await this.cartService.AddToCartAsync(userId, product2Id);

			string cartItemsCount = await this.cartService.GetCartItemsCountAsync(userId);

			Assert.AreEqual("2", cartItemsCount);
		}

		[Test]
		public async Task GetCartItemsCountAsync_ShouldGetZeroWhenNoItemsInCart()
		{
			string userId = User.Id.ToString();

			string cartItemsCount = await this.cartService.GetCartItemsCountAsync(userId);

			Assert.AreEqual("0", cartItemsCount);
		}

		[Test]
		public async Task RemoveItemFromCart_ShouldRemoveTheItemFromCart()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			await this.cartService.IncreaseQuantityAsync(userId, productId);

			await this.cartService.RemoveItemFromCart(userId, productId);

			Assert.AreEqual(0, User.ActiveCart.TotalPrice);
			Assert.AreEqual(0, User.ActiveCart.OrderedItems.Count());
		}

		[Test]
		public async Task RemoveItemFromCart_WithInValidData_ShouldNotRemoveTheItemFromCart()
		{
			string userId = User.Id.ToString();
			int productId = ProductCollar.Id;

			await this.cartService.AddToCartAsync(userId, productId);
			await this.cartService.IncreaseQuantityAsync(userId, productId);

			Assert.ThrowsAsync<NullReferenceException>(async () =>
			{
				await this.cartService.RemoveItemFromCart(userId, 0);
			});
		}
	}
}
