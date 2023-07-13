using PawAndCollar.Web.ViewModels.Cart;

namespace PawAndCollarServices.Interfaces
{
	public interface ICartService
	{
		Task<ViewCartViewModel> GetCartItemsAsync(string userId);
		Task AddToCartAsync(string userId, int productId);

	}
}
