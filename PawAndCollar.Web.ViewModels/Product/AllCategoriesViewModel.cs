using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Category
{
    using static Common.EntittyValidationConstants.Category;
    public class AllCategoriesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The Name field must be between {2} and {1} characters.")]
        public string Name { get; set; } = null!;
    }

}
