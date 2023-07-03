using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Web.ViewModels.Category;
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
