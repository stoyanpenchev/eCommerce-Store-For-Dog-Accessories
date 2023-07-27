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
            this.PaymentMethods = new List<SelectListItem>();
            this.StatusOptions = new List<SelectListItem>();
        }

		public string OrderNumber { get; set; }


        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        public IEnumerable<SelectListItem> PaymentMethods { get; set; }

        public IEnumerable<SelectListItem> StatusOptions { get; set; }

        public string ShippingAddress { get; set; }

        public ICollection<OrderSummaryProductViewModel> OrderedItems { get; set; }
    }
}
