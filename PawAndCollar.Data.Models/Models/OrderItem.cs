using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PawAndCollar.Data.Models.Models
{
    using static PawAndCollar.Common.EntittyValidationConstants.OrderItem;  
    public class OrderItem
    {

        [Required]
        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }

        [Required]
        public Order Order { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Cart))]
		public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = null!;

		[Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; }

    }
}
