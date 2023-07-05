using PawAndCollar.Web.ViewModels.Category;

namespace PawAndCollarServices.Interfaces
{
	public interface ICategoryService
	{
		Task<ICollection<AllCategoriesViewModel>> GetAllCategoriesAsync();

		Task<IEnumerable<string>> AllCategoryNamesAsync();

		Task<bool> ExistByIdAsync(int id);
	}
}
