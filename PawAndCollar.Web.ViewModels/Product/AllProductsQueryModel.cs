using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Web.ViewModels.Product.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PawAndCollar.Web.ViewModels.Product
{
	using static PawAndCollar.Common.GeneralApplicationConstants;
	public class AllProductsQueryModel
	{
        public AllProductsQueryModel()
        {
			this.CurrentPage = DefaultPage;
			this.Products = new List<ProductHomeViewModel>();
			this.ProductsPerPage = EntitiesPerPage;
			this.Categories = new HashSet<string>();
			this.Sizes = new HashSet<string>();
        }
		 
        public string? Category { get; set; }
        public string? Size { get; set; }

        [Display(Name = "Sort Products By")]
        public ProductSorting ProductSorting { get; set; }

		public int CurrentPage { get; set; }

		[Display(Name = "Products Per Page")]
		public int ProductsPerPage { get; set; }

		public int TotalProducts { get; set; }

        public IEnumerable<string> Sizes { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public IEnumerable<ProductHomeViewModel> Products { get; set; }
    }
}
