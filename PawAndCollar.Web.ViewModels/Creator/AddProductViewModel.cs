using static PawAndCollar.Common.EntittyValidationConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Creator
{
    using static Common.EntittyValidationConstants.Product;
    using PawAndCollar.Data.Models.Enums;
    using PawAndCollar.Web.ViewModels.Category;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AddProductViewModel
	{
        public AddProductViewModel()
        {
            this.Categories = new List<AllCategoriesViewModel>();
            this.SizeList = new List<SelectListItem>
            {
                new SelectListItem { Text = "XS", Value = "1" },
                new SelectListItem { Text = "S", Value = "2" },
                new SelectListItem { Text = "M", Value = "3" },
                new SelectListItem { Text = "L", Value = "4" },
                new SelectListItem { Text = "XL", Value = "5" },
                new SelectListItem { Text = "XXL", Value = "6" },
            };
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The Name field must be between {2} and {1} characters long.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "The Description field is required.")]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "The Description field must be between {2} and {1} characters long.")]
        public string Description { get; set; } = null!;

        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = "The Price field must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Quantity field is required.")]
        [Range(QuantityMinValue, QuantityMaxValue, ErrorMessage = "The Quantity field must be between {1} and {2}.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "The Image URL field is required.")]
        [StringLength(ImageUrlMaxLength, MinimumLength = ImageUrlMinLength, ErrorMessage = "The Image URL field must be between {2} and {1} characters long.")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "The Category field is required.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public int MyProperty { get; set; }

        [Required(ErrorMessage = "Please select a Size.")]
        public int Size { get; set; }

        [Required(ErrorMessage = "The Color field is required.")]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength, ErrorMessage = "The Color field must be between {2} and {1} characters long.")]
        public string Color { get; set; } = null!;

        [Required(ErrorMessage = "The Material field is required.")]
        [StringLength(MaterialMaxLength, MinimumLength = MaterialMinLength, ErrorMessage = "The Material field must be between {2} and {1} characters long.")]
        public string Material { get; set; } = null!;

        public ICollection<AllCategoriesViewModel> Categories { get; set; }
        public IEnumerable<SelectListItem> SizeList { get; set; }


    }
}
