using PawAndCollar.Web.ViewModels.Order;

namespace PawAndCollar.Services.Data.Models.Order
{
    public class AllOrdersFilteredAndPagedServiceModel
    {
        public AllOrdersFilteredAndPagedServiceModel()
        {
            this.Orders = new List<OrderViewModel>();
        }

        public int TotalOrdersCount { get; set; }

        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
