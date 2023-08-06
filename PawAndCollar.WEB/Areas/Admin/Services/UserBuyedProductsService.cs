namespace PawAndCollar.Web.Areas.Admin.Services
{
    using Microsoft.EntityFrameworkCore;
    using PawAndCollar.Data;
    using PawAndCollar.Data.Models;
    using PawAndCollar.Web.Areas.Admin.Services.Interfaces;
    using PawAndCollar.Web.Areas.Admin.ViewModels.Product;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserBuyedProductsService : IUserBuyedProductsService
    {
        private readonly PawAndCollarDbContext dbContext;
        public UserBuyedProductsService(PawAndCollarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<MostBuyedProductsViewModel>> GetMostBuyedProductsAsync()
        {
            var bestSellingProductIds = this.dbContext.UsersBuyedProducts
                    .GroupBy(ubp => ubp.ProductId)
                    .OrderByDescending(group => group.Sum(ubp => ubp.Quantity))
                    .Select(group => group.Key)
                    .ToList();

            IEnumerable<MostBuyedProductsViewModel> mostBuyedProductsViewModels = this.dbContext.Products
                .AsNoTracking()
                .Where(p => bestSellingProductIds.Contains(p.Id))
                .Select(p => new MostBuyedProductsViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    CreatorName = p.Creator.User.UserName,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    isItActive = p.IsActive,
                    Size = p.Size.ToString(),
                    BuyedCount = this.dbContext.UsersBuyedProducts
                        .Where(ubp => ubp.ProductId == p.Id)
                        .Sum(ubp => ubp.Quantity)
                })
                .OrderByDescending(p => p.BuyedCount)
                .ToList();

            return mostBuyedProductsViewModels;
        }
    }
}
