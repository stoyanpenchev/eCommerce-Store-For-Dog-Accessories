using PawAndCollar.Web.ViewModels.Product;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Creator
{
	public class CreatorDeatailViewModel
	{
        public CreatorDeatailViewModel()
        {
            this.Products = new List<ProductHomeViewModel>();
        }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;

        public ICollection<ProductHomeViewModel> Products { get; set; }
    }
}
