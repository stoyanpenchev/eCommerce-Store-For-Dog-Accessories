using PawAndCollar.Services.Data.Models.Order;
using PawAndCollar.Web.ViewModels.Order;
using PawAndCollar.Web.ViewModels.Product;

namespace PawAndCollarServices.Interfaces
{
	public interface IOrderService
	{
		Task AddOrderSummaryAsync(OrderSummaryViewModel model, string userId);
        Task<AllOrdersFilteredAndPagedServiceModel> GetAllOrdersAsync(AllOrdersQueryModel queryModel);
        Task<Guid> GetOrderNumberAsync(string userId);
        Task<ICollection<OrderSummaryProductViewModel>> GetOrderSummaryProductAsync(string userId);

		Task<ICollection<string>> GetAllOrderStatusesAsync();
		Task<OrderDetailsViewModel> GetOrderDetailsAsync(string id);
        Task UpdateOrderStatusAsync(OrderDetailsViewModel viewModel);
    }
}
