using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawAndCollar.Data.Models.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; } = null!;

        [Required, ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        [Required]
        public ApplicationUser Customer { get; set; } = null!;

        [Required]
        public DateTime DatePosted { get; set; }
    }
}
