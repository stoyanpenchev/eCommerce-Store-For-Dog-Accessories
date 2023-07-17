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
        public Guid UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}
