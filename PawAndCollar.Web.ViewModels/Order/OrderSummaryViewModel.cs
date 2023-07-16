﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PawAndCollar.Web.ViewModels.Product;
using System.ComponentModel.DataAnnotations;

namespace PawAndCollar.Web.ViewModels.Order
{
    using static PawAndCollar.Common.EntittyValidationConstants.Order;
    public class OrderSummaryViewModel
	{
        public OrderSummaryViewModel()
        {
            this.OrderedItems = new List<OrderSummaryProductViewModel>();
			this.PaymentMethods = new List<SelectListItem>
			{
                new SelectListItem { Text = "Cash", Value = "1" },
                new SelectListItem { Text = "CreditCard", Value = "2" },
                new SelectListItem { Text = "PayPal", Value = "3" },
                new SelectListItem { Text = "BankTransfer", Value = "4" }
            };
        }
        [Required(ErrorMessage = "Customer Name is required.")]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string CustomerName { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string Phone { get; set; } = null!;

        [Required]
        public string OrderDate { get; set; } = null!;

        public decimal TotalAmaunt { get => (this.OrderedItems.Sum(oi => oi.TotalPrice)); }

        [Required]
        public Guid OrderNumber { get; set; }

        [Required(ErrorMessage = "Shipping Address is required.")]
        [StringLength(ShippingAddressMaxLength, MinimumLength = ShippingAddressMinLength)]
        public string ShippingAddress { get; set; } = null!;
        public int PaymentMethod { get; set; }

        public IEnumerable<SelectListItem> PaymentMethods { get; set; }

        public ICollection<OrderSummaryProductViewModel> OrderedItems { get; set; }
	}
}