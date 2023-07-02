using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarServices.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<AllCategoriesViewModel>> GetAllCategoriesAsync();

        Task<ICollection<ProductHomeViewModel>> GetHomePageProductsAsync();
    }
}
