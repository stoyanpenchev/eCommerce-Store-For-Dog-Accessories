using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Product
{
	public class ProductPreDeleteViewModel
	{

        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Size { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
