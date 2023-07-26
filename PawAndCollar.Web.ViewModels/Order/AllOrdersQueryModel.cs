namespace PawAndCollar.Web.ViewModels.Order
{
    using PawAndCollar.Web.ViewModels.Order.Enums;
    using System.ComponentModel.DataAnnotations;
    using static PawAndCollar.Common.GeneralApplicationConstants;
    public class AllOrdersQueryModel
    {
        public AllOrdersQueryModel()
        {
            this.CurrentPage = DefaultPageOrder;
            this.Orders = new List<OrderViewModel>();
            this.OrdersPerPage = EntitiesPerPageOrder;
            this.Statuses = new HashSet<string>();
        }

        public string? Status { get; set; }
        public IEnumerable<string> Statuses { get; set; }

        public int CurrentPage { get; set; }


        [Display(Name = "Sort Orders By")]
        public OrderSorting OrderSorting { get; set; }


        [Display(Name = "Orders Per Page")]
        public int OrdersPerPage { get; set; }

        public int TotalOrders { get; set; }

        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
