using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollarServices.Interfaces;
using PawAndCollarServices;
using PawAndCollarSystem.Services.Tests.CreatorTests;
using System.Threading.Tasks;
using System;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollar.Data.Models.Enums;
using System.Collections;
using PawAndCollar.Web.ViewModels.Category;
using System.Collections.Generic;
using Moq;
using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;
using PawAndCollar.Web.ViewModels.Creator;

namespace PawAndCollarSystem.Services.Tests.ServiceTests
{
	using static DatabaseSeeder;
	public class ProductsServiceTests
	{
		private DbContextOptions<PawAndCollarDbContext> dbOptions;
		private PawAndCollarDbContext dbContext;

		private ICreatorService creatorService;
		private IApplicationUserService userService;
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
			this.userService = new ApplicationUserService(this.dbContext, this.creatorService);
			this.productService = new ProductService(this.dbContext);
		}

		[Test]
		public async Task AddProductAsync_ShouldCreateProductAndAddItToDatabase()
		{

			var productModel = new AddProductViewModel()
			{
				Name = "Midnight Floral Collar",
				Description = "Midnight Floral brings out a lovely serenity. Featuring an abundance of lively flowers on a bold black background, this print is sure to stand out on any color of fur. 100% cotton fabric with the perfect touch of rose gold metal hardware.",
				Price = 52.00M,
				Quantity = 3,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614",
				CategoryId = 5,
				Size = 5,
				Color = "Midnight",
				Material = "Cotton"
			};
			string creatorId = CreatorUser.Id.ToString();

			await this.productService.AddProductAsync(productModel, creatorId);

			Assert.AreEqual(3, dbContext.Products.CountAsync().Result);
		}

		[Test]
		public async Task DeleteProductByIdAsync_ShouldDeleteTheProduct()
		{
			await this.productService.DeleteProductByIdAsync(ProductCollar.Id);

			Assert.AreEqual(2, dbContext.Products.CountAsync().Result);
			Assert.True(ProductCollar.IsActive == false);
			Assert.True(ProductCollar.Quantity == 0);
		}

		[Test]
		public async Task DeleteProductByIdAsync_ShouldNotDeleteTheProductIfProductNotFound()
		{

			this.productService.DeleteProductByIdAsync(9999);

			Assert.False(ProductCollar.IsActive == false);
			Assert.False(ProductCollar.Quantity == 0);
		}

		[Test]
		public async Task EditProductAsync_ShouldEditTheProduct()
		{
			int oldQuantity = ProductCollar.Quantity;
			int newQuantity = 5;
			decimal oldPrice = ProductCollar.Price;
			decimal newPrice = 55.00M;
			var productModel = new AddProductViewModel()
			{
				Id = ProductCollar.Id,
				Name = "Midnight Floral Collar",
				Description = "Midnight Floral brings out a lovely serenity. Featuring an abundance of lively flowers on a bold black background, this print is sure to stand out on any color of fur. 100% cotton fabric with the perfect touch of rose gold metal hardware.",
				Price = newPrice,
				Quantity = newQuantity,
				ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614",
				CategoryId = 5,
				Size = 5,
				Color = "Midnight",
				Material = "Cotton"
			};
			await this.productService.EditProductAsync(productModel);

			Assert.AreEqual(newQuantity, ProductCollar.Quantity);
			Assert.AreNotEqual(oldQuantity, ProductCollar.Quantity);
			Assert.AreEqual(newPrice, ProductCollar.Price);
			Assert.AreNotEqual(oldPrice, ProductCollar.Price);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnTrueIfProductExists()
		{
			bool result = await this.productService.ExistsByIdAsync(ProductCollar.Id);

			Assert.True(result);
		}

		[Test]
		public async Task ExistsByIdAsync_ShouldReturnFalseIfProductDoesNotExist()
		{
			bool result = await this.productService.ExistsByIdAsync(9999);

			Assert.False(result);
		}

		[Test]
		public async Task GetAllCategoriesAsync_ShouldGetListOfAllCategories()
		{
			ICollection<AllCategoriesViewModel> categories = await this.productService.GetAllCategoriesAsync();
			Assert.AreEqual(2, categories.Count);
		}

		[Test]
		public async Task GetAllProductsAsync_ShouldGetAllProducts()
		{
			IEnumerable<ProductHomeViewModel> models = new List<ProductHomeViewModel>()
			{
				new ProductHomeViewModel()
				{
					Id = Collar.Id,
					Name = "Midnight Floral Collar",
					CreatorName = CreatorUser.UserName,
					Price = 52.00M,
					Quantity = 3,
					ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614",
					Size = "XL",
					AverageReviewScore = 0
				},
				new ProductHomeViewModel()
				{
					Id = Harness.Id,
					Name = "Midnight Floral Harness",
					CreatorName = CreatorUser.UserName,
					Price = 81.00M,
					Quantity = 6,
					ImageUrl = "https://cdn.shopify.com/s/files/1/0102/1437/5505/products/DSC07134-1-181634_720x.jpg?v=1683713614",
					Size = "XS",
					AverageReviewScore = 0
				}
			};
			IEnumerable<string> categories = new List<string>()
			{
				"Collar",
				"Harness"
			};
			IEnumerable<string> sizes = new List<string>()
			{
				"XS",
				"XL"
			};

			var products = new AllProductsQueryModel()
			{
				Products = models,
				ProductsPerPage = 2,
				Categories = categories,
				Sizes = sizes,
				TotalProducts = 2
			};
			
			var result = await this.productService.GetAllProductsAsync(products);

			Assert.AreEqual(2, result.TotalProductsCount);
		}

		[Test]
		public async Task GetAllProductsAsync_ShouldGetZeroProductsIfNoProducts()
		{
			IEnumerable<ProductHomeViewModel> models = new List<ProductHomeViewModel>();

			var products = new AllProductsQueryModel()
			{
				Products = models,
			};

			var result = await this.productService.GetAllProductsAsync(products);

			Assert.AreEqual(0, result.Products.Count());
		}

		[Test]
		public async Task GetAllProductsByCreatorIdAsync_ShouldReturnProducts()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();
			ICollection<ProductHomeViewModel> products = await this.productService.GetAllProductsByCreatorIdAsync(Creator.Id.ToString());
			Assert.AreEqual(1, products.Count());
		}

		[Test]
		public async Task GetAllProductsByCreatorIdAsync_ShouldReturnZeroProductsIfIdIsInvalid()
		{
			ProductCollar.CreatorId = CreatorUser.Id;
			await this.dbContext.SaveChangesAsync();
			ICollection<ProductHomeViewModel> products = await this.productService.GetAllProductsByCreatorIdAsync(CreatorUser.Id.ToString());
			Assert.AreEqual(0, products.Count());
		}

		[Test]
		public async Task GetAllProductsForQuantityTestAsync_ShouldReturnProducts()
		{
			ICollection<ProductsForTestOrderQuantityViewModel> products = await this.productService.GetAllProductsForQuantityTestAsync();
			Assert.AreEqual(2, products.Count());
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldGetDetailsById()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();

			ProductDeatailsViewModel product = await this.productService.GetDetailsByIdAsync(ProductCollar.Id);
			Assert.AreEqual(ProductCollar.Id, product.Id);
		}

		[Test]
		public async Task GetDetailsByIdAsync_ShouldReturnNullWhenIdIsIncorrect()
		{
			ProductCollar.CreatorId = User.Id;
			await this.dbContext.SaveChangesAsync();

			ProductDeatailsViewModel product = await this.productService.GetDetailsByIdAsync(ProductCollar.Id);
			Assert.IsNull(product);
		}

		[Test]
		public async Task GetHomePageProductsAsync_ShouldGetProducts()
		{
			ProductCollar.Creator = Creator;
			ProductCollar.CreatorId = Creator.Id;
			ProductHarness.Creator = Creator;
			ProductHarness.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();
			ICollection<ProductHomeViewModel> products = await this.productService.GetHomePageProductsAsync();

			Assert.AreEqual(2, products.Count());
			Assert.AreEqual(ProductCollar.Id, products.First().Id);
			Assert.AreEqual(ProductHarness.Id, products.Last().Id);
		}

		[Test]
		public async Task GetProductByIdAsync_ShouldGetProductById()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();

			AddProductViewModel product = await this.productService.GetProductByIdAsync(ProductCollar.Id);
			Assert.AreEqual(ProductCollar.Id, product.Id);
		}

		[Test]
		public async Task GetProductByIdAsync_ShouldReturnNullWhenIdIsInvalid()
		{
			await this.dbContext.SaveChangesAsync();

			AddProductViewModel product = await this.productService.GetProductByIdAsync(999);
			Assert.IsNull(product);
		}

		[Test]
		public async Task GetProductForDeleteByIdAsync_ShouldGetProductForDeleteById()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();

			ProductPreDeleteViewModel product = await this.productService.GetProductForDeleteByIdAsync(ProductCollar.Id);
			Assert.AreEqual(ProductCollar.Id, product.Id);
		}

		[Test]
		public async Task IsCreatorWithIdOwnerOfProducWithIdAsync_ShouldReturnTrueIfCreatorIsOwnerOfProduct()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();

			bool result = await this.productService.IsCreatorWithIdOwnerOfProducWithIdAsync(ProductCollar.Id, Creator.Id.ToString());
			Assert.IsTrue(result);
		}

		[Test]
		public async Task IsCreatorWithIdOwnerOfProducWithIdAsync_ShouldReturnFalseIfCreatorIsNotOwnerOfProduct()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();

			bool result = await this.productService.IsCreatorWithIdOwnerOfProducWithIdAsync(ProductHarness.Id, Creator.Id.ToString());
			Assert.IsFalse(result);
		}

		[Test]
		public async Task SearchProductsByNameAsync_ShouldGetProducts()
		{
			ProductCollar.CreatorId = Creator.Id;
			await this.dbContext.SaveChangesAsync();

			ICollection<ProductHomeViewModel> products = await this.productService.SearchProductsByNameAsync("Midnight");

			Assert.AreEqual(1, products.Count());
		}


	}
}
