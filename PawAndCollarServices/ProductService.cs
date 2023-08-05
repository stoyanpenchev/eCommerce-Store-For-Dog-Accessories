using Microsoft.EntityFrameworkCore;
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
            if (product.Quantity <= 0)
            {
                product.IsActive = false;
            }
            product.IsActive = true;
            await this.dbContext.Products.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductByIdAsync(int id)
        {
            Product product = await this.dbContext.Products
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id == id);
            product.IsActive = false;
            product.Quantity = 0;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditProductAsync(AddProductViewModel model, string creatorId)
        {
            Product? product = await this.dbContext.Products.FirstOrDefaultAsync(p => p.Id == model.Id && p.IsActive);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Quantity = model.Quantity;
                product.ImageUrl = model.ImageUrl;
                product.CategoryId = model.CategoryId;
                product.CreatorId = Guid.Parse(creatorId);
                product.Size = (SizeTypes)model.Size;
                product.Color = model.Color;
                product.Material = model.Material;
                if (product.Quantity <= 0)
                {
                    product.IsActive = false;
                }
                product.IsActive = true;
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.dbContext.Products
               .Where(p => p.IsActive)
               .AnyAsync(p => p.Id == id);
            return result;
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
            IQueryable<Product> productsQuery = this.dbContext.Products
                .Include(p => p.OrderedItems)
                .ThenInclude(oi => oi.Order)
                .ThenInclude(or => or.UserBuyedProducts)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                productsQuery = productsQuery.Where(p => p.Category.Name == queryModel.Category);
            }
            int sizeValue = 0;
            if (!string.IsNullOrWhiteSpace(queryModel.Size))
            {
                SizeTypes size = Enum.Parse<SizeTypes>(queryModel.Size);
                sizeValue = (int)size;
                productsQuery = productsQuery.Where(p => (int)p.Size == sizeValue);
            }

            if (queryModel.ProductSorting == ProductSorting.BestSelling)
            {
                var bestSellingProductIds = this.dbContext.UsersBuyedProducts
                    .GroupBy(ubp => ubp.ProductId)
                    .OrderByDescending(group => group.Sum(ubp => ubp.Quantity))
                    .Select(group => group.Key)
                    .ToList();

                productsQuery = productsQuery.Where(p => bestSellingProductIds.Contains(p.Id));
            }
            else
            {
                productsQuery = queryModel.ProductSorting switch
                {
                    ProductSorting.PriceAscending => productsQuery.OrderBy(p => p.Price),
                    ProductSorting.PriceDescending => productsQuery.OrderByDescending(p => p.Price),
                    ProductSorting.Oldest => productsQuery.OrderBy(p => p.CreatedOn),
                    ProductSorting.Newest => productsQuery.OrderByDescending(p => p.CreatedOn),
                    _ => productsQuery.OrderBy(p => p.CreatorId != null)
                        .ThenByDescending(p => p.CreatedOn)
                };
            }


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
                    Price = p.Price,
                }).ToListAsync();

            int totalProducts = await productsQuery.CountAsync();
            return new AllProductsFilteredAndPagedServiceModel()
            {
                TotalProductsCount = totalProducts,
                Products = products
            };
        }

        public async Task<ICollection<ProductHomeViewModel>> GetAllProductsByCreatorIdAsync(string creatorId)
        {
            List<ProductHomeViewModel> products = await this.dbContext.Products
                .Where(p => p.CreatorId == Guid.Parse(creatorId))
                .Select(p => new ProductHomeViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    CreatorName = p.Creator.User.UserName,
                    Price = p.Price,
                    Size = p.Size.ToString(),
                    Quantity = p.Quantity
                }).ToListAsync();

            return products;
        }

        public async Task<ICollection<ProductsForTestOrderQuantityViewModel>> GetAllProductsForQuantityTestAsync()
        {
            ICollection<ProductsForTestOrderQuantityViewModel> products = await this.dbContext.Products
                .Select(p => new ProductsForTestOrderQuantityViewModel()
                {
                    Id = p.Id,
                    Quantity = p.Quantity
                }).ToListAsync();
            return products;
        }

        public async Task<ProductDeatailsViewModel?> GetDetailsByIdAsync(int productId)
        {
            ProductDeatailsViewModel? product = await this.dbContext.Products
                .Where(p => p.Id == productId) // && p.IsActive == true
                .Select(p => new ProductDeatailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Size = p.Size.ToString(),
                    Quantity = p.Quantity,
                    Creator = new CreatorDeatailViewModel()
                    {
                        Email = p.Creator.User.Email,
                        PhoneNumber = p.Creator.PhoneNumber,
                    }
                }).FirstOrDefaultAsync();

            if (product == null)
            {
                return null;
            }
            return product;
        }

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

        public async Task<AddProductViewModel?> GetProductByIdAsync(int productId)
        {
            AddProductViewModel? product = await this.dbContext.Products
                .Where(p => p.Id == productId && p.IsActive)
                .Select(p => new AddProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    Size = (int)p.Size,
                    Color = p.Color,
                    Material = p.Material
                }).FirstOrDefaultAsync();
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<ProductPreDeleteViewModel> GetProductForDeleteByIdAsync(int id)
        {
            ProductPreDeleteViewModel product = await this.dbContext.Products
                .Where(p => p.Id == id && p.IsActive)
                .Select(p => new ProductPreDeleteViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Size = p.Size.ToString(),
                    Quantity = p.Quantity
                }).FirstAsync();
            return product;
        }

        public async Task<bool> IsCreatorWithIdOwnerOfProducWithIdAsync(int productId, string creatorId)
        {
            Product product = await this.dbContext.Products
                .Where(p => p.Id == productId)
                .FirstAsync();
            return product.CreatorId == Guid.Parse(creatorId);
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
