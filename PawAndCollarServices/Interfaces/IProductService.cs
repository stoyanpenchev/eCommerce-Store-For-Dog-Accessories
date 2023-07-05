using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarServices.Interfaces
{
    public interface IProductService
    {
		Task AddProductAsync(AddProductViewModel model, string id);
		Task<ICollection<ProductHomeViewModel>> GetHomePageProductsAsync();

        Task<ICollection<ProductHomeViewModel>> GetAllProducts();

        Task<ICollection<ProductHomeViewModel>> SearchProductsByNameAsync(string searchedItem);
    }
}
