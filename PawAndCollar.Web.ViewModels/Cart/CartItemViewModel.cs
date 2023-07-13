using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Cart
{
	public class CartItemViewModel
	{
		
		public int Id { get; set; }

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
