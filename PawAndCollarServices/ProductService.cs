﻿using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Data.Models;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollar.Web.ViewModels.Product.Enums;
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

		public async Task<AllProductsFilteredAndPagedServiceModel> GetAllProductsAsync(AllProductsQueryModel queryModel)
		{
			IQueryable<Product> productsQuery = this.dbContext.Products.AsQueryable();
			if (!string.IsNullOrWhiteSpace(queryModel.Category))
			{
				productsQuery = productsQuery.Where(p => p.Category.Name == queryModel.Category);
			}
			int sizeValue = 0;
			if(!string.IsNullOrWhiteSpace(queryModel.Size))
			{
                SizeTypes size = Enum.Parse<SizeTypes>(queryModel.Size);
                sizeValue = (int)size;
                productsQuery = productsQuery.Where(p => (int)p.Size == sizeValue);
            }
			productsQuery = queryModel.ProductSorting switch
			{
				ProductSorting.PriceAscending => productsQuery.OrderBy(p => p.Price),
				ProductSorting.PriceDescending => productsQuery.OrderByDescending(p => p.Price),
				ProductSorting.Oldest => productsQuery.OrderBy(p => p.CreatedOn),
				ProductSorting.Newest => productsQuery.OrderByDescending(p => p.CreatedOn),
				ProductSorting.BestSelling => productsQuery.OrderByDescending(p => p.OrderedItems.Count),
				_ => productsQuery.OrderBy(p => p.Name)
			};

			IEnumerable<ProductHomeViewModel> products = await productsQuery
				.Where(p => p.IsActive == true)
				.Skip((queryModel.CurrentPage - 1) * queryModel.ProductsPerPage)
				.Take(queryModel.ProductsPerPage)
				.Select(p => new ProductHomeViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					CreatorName = p.Creator.User.UserName,
					Size = p.Size.ToString(),
					Price = p.Price
				}).ToListAsync();

			int totalProducts = await productsQuery.CountAsync();
			return new AllProductsFilteredAndPagedServiceModel()
			{
				TotalProductsCount = totalProducts,
				Products = products
			};
		}

    //    public async Task<ICollection<ProductHomeViewModel>> GetAllProductsByCreatorIdAsync(string creatorId)
    //    {
    //        var products = await this.dbContext.Products
    //            .Where(p => p.CreatorId == Guid.Parse(creatorId))
    //            .Select(p => new ProductHomeViewModel()
				//{
    //                Id = p.Id,
    //                ImageUrl = p.ImageUrl,
    //                Name = p.Name,
    //                CreatorName = p.Creator.User.UserName,
    //                Price = p.Price
    //            }).ToListAsync();
    //    }

        public async Task<ICollection<ProductHomeViewModel>> GetHomePageProductsAsync()
		{
			List<ProductHomeViewModel> models = await this.dbContext.Products
				.Where(p => p.IsActive == true)
				.Select(p => new ProductHomeViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					CreatorName = p.Creator.User.UserName,
					Price = p.Price,
					Size = p.Size.ToString()
				}).ToListAsync();
			return models;
		}

		public async Task<ICollection<ProductHomeViewModel>> SearchProductsByNameAsync(string searchedItem)
		{
			searchedItem = $"%{searchedItem.ToLower()}%";
			var products = await this.dbContext.Products
				.Where(p => EF.Functions.Like(p.Name, searchedItem) && p.IsActive == true)
				.Select(p => new ProductHomeViewModel()
				{
					Id = p.Id,
					ImageUrl = p.ImageUrl,
					Name = p.Name,
					CreatorName = p.Creator.User.UserName,
					Price = p.Price
				}).ToListAsync();
			return products;
		}
	}
}
