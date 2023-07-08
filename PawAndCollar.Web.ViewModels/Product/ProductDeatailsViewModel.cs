using PawAndCollar.Web.ViewModels.Creator;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Product
{
	public class ProductDeatailsViewModel
	{
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
        [Required]
		public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Size { get; set; } = null!;


        [Required]
        public CreatorDeatailViewModel Creator { get; set; } = null!;

    }
}
