using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Product
{
    using static Common.EntittyValidationConstants.Product;
    public class OrderSummaryProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Range(QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; set; }

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }
        public decimal TotalPrice { get => (this.Quantity * this.Price); }
    }
}
