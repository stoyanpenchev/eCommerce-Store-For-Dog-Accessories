using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollar.Services.Data.Models.Product
{
	public class AllProductsFilteredAndPagedServiceModel
	{
        public AllProductsFilteredAndPagedServiceModel()
        {
            this.Products = new List<ProductHomeViewModel>();
        }
        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductHomeViewModel> Products { get; set; }
    }
}
