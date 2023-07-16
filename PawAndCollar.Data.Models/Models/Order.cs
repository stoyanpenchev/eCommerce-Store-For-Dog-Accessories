using PawAndCollar.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PawAndCollar.Data.Models.Models
{
    using static PawAndCollar.Common.EntittyValidationConstants.Order;
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderedItems = new List<OrderItem>();
            this.OrderNumber = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        [Required]
        public ApplicationUser Customer { get; set; } = null!;

        [Required]
        [StringLength(CustomerNameMaxLength)]
        public string CustomerName { get; set; } = null!;
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public Guid OrderNumber { get; set; }

        [Required]
        public decimal TotalAmaunt { get; set; }

        public string? Phone { get; set; }
        public OrderStatus Status { get; set; }

        [Required]
        [StringLength(ShippingAddressMaxLength)]
        public string ShippingAddress { get; set; } = null!;

        [Required]
        public PaymentTypes PaymentMethod { get; set; }

        public ICollection<OrderItem> OrderedItems { get; set; }
    }
}
