using Microsoft.AspNetCore.Mvc.Rendering;
using PawAndCollar.Web.ViewModels.Product;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PawAndCollar.Web.ViewModels.Order
{
	public class OrderDetailsViewModel : OrderViewModel
	{
        public OrderDetailsViewModel()
        {
            this.OrderedItems = new List<OrderSummaryProductViewModel>();
        }

		public string OrderNumber { get; set; } = null!;


        [Display(Name = "Payment Method")]
        public int PaymentMethod { get; set; }

        public IEnumerable<SelectListItem> PaymentMethods { get; set; }


		public string ShippingAddress { get; set; } = null!;

        public ICollection<OrderSummaryProductViewModel> OrderedItems { get; set; }
    }
}
