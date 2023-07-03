using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Data.Models
{
    using static PawAndCollar.Common.EntittyValidationConstants.Category;
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
    }
}
