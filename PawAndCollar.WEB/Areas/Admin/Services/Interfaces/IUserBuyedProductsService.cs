using PawAndCollar.Web.Areas.Admin.ViewModels.Product;

namespace PawAndCollar.Web.Areas.Admin.Services.Interfaces
{
    public interface IUserBuyedProductsService
    {
        Task<IEnumerable<MostBuyedProductsViewModel>> GetMostBuyedProductsAsync();
    }
}
