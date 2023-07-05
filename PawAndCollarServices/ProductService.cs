using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class ProductService : IProductService
	{
		private readonly PawAndCollarDbContext dbContext;
		public ProductService(PawAndCollarDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task AddProductAsync(AddProductViewModel model, string creatorId)
		{

			Product product = new Product
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
				Quantity = model.Quantity,
				ImageUrl = model.ImageUrl,
				CategoryId = model.CategoryId,
				CreatorId = Guid.Parse(creatorId),
				Size = (SizeTypes)model.Size,
				Color = model.Color,
				Material = model.Material
			};
			await this.dbContext.Products.AddAsync(product);
			await this.dbContext.SaveChangesAsync();
		}
		public async Task<ICollection<AllCategoriesViewModel>> GetAllCategoriesAsync()
		{
			List<AllCategoriesViewModel> categories = await this.dbContext.Categories
				.Select(c => new AllCategoriesViewModel()
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToListAsync();
			return categories;
		}

		public async Task<ICollection<ProductHomeViewModel>> GetAllProducts()
		{
			var products = await this.dbContext.Products
				.Select(p => new ProductHomeViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					CreatorName = p.Creator.User.UserName,
					Price = p.Price.ToString()
				}).ToListAsync();
			return products;
		}

		public async Task<ICollection<ProductHomeViewModel>> GetHomePageProductsAsync()
		{
			List<ProductHomeViewModel> models = await this.dbContext.Products
				.Select(p => new ProductHomeViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					CreatorName = p.Creator.User.UserName,
					Price = p.Price.ToString()
				}).ToListAsync();
			return models;
		}

		public async Task<ICollection<ProductHomeViewModel>> SearchProductsByNameAsync(string searchedItem)
		{
			var products = await this.dbContext.Products
				.Where(p => p.Name.Contains(searchedItem))
				.Select(p => new ProductHomeViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					CreatorName = p.Creator.User.UserName,
					Price = p.Price.ToString()
				}).ToListAsync();
			return products;
		}
	}
}
