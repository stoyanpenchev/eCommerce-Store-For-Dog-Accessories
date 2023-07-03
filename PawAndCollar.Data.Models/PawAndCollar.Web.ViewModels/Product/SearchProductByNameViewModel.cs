using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Product
{
	public class SearchProductByNameViewModel
	{
        public SearchProductByNameViewModel()
        {
            this.SearchResults = new List<ProductHomeViewModel>();
        }

        [Required]
        public string SearchedItem { get; set; } = null!;

		public ICollection<ProductHomeViewModel> SearchResults { get; set; }
	}
}
