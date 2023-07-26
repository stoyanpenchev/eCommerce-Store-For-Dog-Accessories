using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public string Id { get; set; } = null!;

        public string CustomerName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

		public string OrderDate { get; set; } = null!;
        public string Email { get; set; } = null!;

        public int Status { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
