using Microsoft.EntityFrameworkCore;
using PawAndCollar.Data;
using PawAndCollar.Web.ViewModels.Category;
using PawAndCollarServices.Interfaces;

namespace PawAndCollarServices
{
	public class CategoryService : ICategoryService
	{
		private readonly PawAndCollarDbContext dbContext;
		public CategoryService(PawAndCollarDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<string>> AllCategoryNamesAsync()
		{
			IEnumerable<string> categoryNames = await this.dbContext.Categories
				.Select(c => c.Name)
				.ToListAsync();
			return categoryNames;
		}

		public async Task<bool> ExistByIdAsync(int id)
		{
			bool result = await this.dbContext.Categories.AnyAsync(c => c.Id == id);
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
	}
}
