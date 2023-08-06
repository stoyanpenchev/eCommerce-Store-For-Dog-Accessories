using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.ViewModels.Category;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarServices.Interfaces
{
    public interface IProductService
    {
		Task AddProductAsync(AddProductViewModel model, string id);
		Task<ICollection<ProductHomeViewModel>> GetHomePageProductsAsync();

        Task<AllProductsFilteredAndPagedServiceModel> GetAllProductsAsync(AllProductsQueryModel queryModel);

        Task<ICollection<ProductsForTestOrderQuantityViewModel>> GetAllProductsForQuantityTestAsync();

        Task<ICollection<ProductHomeViewModel>> SearchProductsByNameAsync(string searchedItem);

        Task<ICollection<ProductHomeViewModel>> GetAllProductsByCreatorIdAsync(string creatorId);

        Task<ProductDeatailsViewModel?> GetDetailsByIdAsync(int productId);

        Task<AddProductViewModel?> GetProductByIdAsync(int productId);
		Task EditProductAsync(AddProductViewModel model);

        Task DeleteProductByIdAsync(int id);

        Task<bool> IsCreatorWithIdOwnerOfProducWithIdAsync(int productId, string creatorId);
		Task<bool> ExistsByIdAsync(int id);
		Task<ProductPreDeleteViewModel> GetProductForDeleteByIdAsync(int id);
	}
}
