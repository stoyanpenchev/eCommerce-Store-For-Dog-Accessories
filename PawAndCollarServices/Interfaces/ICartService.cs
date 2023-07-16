using PawAndCollar.Web.ViewModels.Cart;
using PawAndCollar.Web.ViewModels.Order;

namespace PawAndCollarServices.Interfaces
{
	public interface ICartService
	{
		Task<ViewCartViewModel> GetCartItemsAsync(string userId);
		Task AddToCartAsync(string userId, int productId);
        Task IncreaseQuantityAsync(string userId, int productId);

		Task DecreaseQuantityAsync(string userId, int productId);
		Task RemoveItemFromCart(string userId, int productId);
		Task<string> GetCartItemsCountAsync(string userId);
	}
}
