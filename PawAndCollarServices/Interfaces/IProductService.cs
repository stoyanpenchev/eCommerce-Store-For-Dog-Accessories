using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarServices.Interfaces
{
    public interface IProductService
    {
		Task AddProductAsync(AddProductViewModel model, string id);
		Task<ICollection<ProductHomeViewModel>> GetHomePageProductsAsync();

        Task<AllProductsFilteredAndPagedServiceModel> GetAllProductsAsync(AllProductsQueryModel queryModel);

        Task<ICollection<ProductHomeViewModel>> SearchProductsByNameAsync(string searchedItem);

        Task<ICollection<ProductHomeViewModel>> GetAllProductsByCreatorIdAsync(string creatorId);

        Task<ProductDeatailsViewModel?> GetDetailsByIdAsync(string productId);
    }
}
