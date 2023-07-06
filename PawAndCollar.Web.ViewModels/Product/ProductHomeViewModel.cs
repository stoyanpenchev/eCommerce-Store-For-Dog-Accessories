using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Product
{
    public class ProductHomeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string CreatorName { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Size { get; set; } = null!;
    }
}
