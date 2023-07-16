using PawAndCollar.Web.ViewModels.Order;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarServices.Interfaces
{
	public interface IOrderService
	{
		Task AddOrderSummaryAsync(OrderSummaryViewModel model, string userId);
        Task<Guid> GetOrderNumberAsync(string userId);
        Task<ICollection<OrderSummaryProductViewModel>> GetOrderSummaryProductAsync(string userId);
	}
}
