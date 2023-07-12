using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawAndCollar.Data.Models.Models
{
    using static Common.EntittyValidationConstants.Cart;
	public class Cart
	{
        public Cart()
        {
            this.Id = Guid.NewGuid();
            this.OrderedItems = new List<OrderItem>();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Range(MinTotalPrice, MaxTotalPrice)]
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}
