using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.Areas.Admin.ViewModels.Product
{
    public class MostBuyedProductsViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string CreatorName { get; set; } = null!;
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; } = null!;

        [Display(Name = "Buyed Counter")]
        public int BuyedCount { get; set; }

    }
}
