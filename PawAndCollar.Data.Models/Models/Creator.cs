using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawAndCollar.Data.Models.Models
{
    using static PawAndCollar.Common.EntittyValidationConstants.Creator;
    public class Creator
    {
        public Creator()
        {
            this.Id = Guid.NewGuid();
            this.Products = new List<Product>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        //[Required, ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        [Required]
        public ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
