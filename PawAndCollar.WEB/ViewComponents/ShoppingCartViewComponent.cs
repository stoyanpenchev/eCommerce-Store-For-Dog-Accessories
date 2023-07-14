using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PawAndCollarServices.Interfaces;
using System.Security.Claims;

namespace PawAndCollar.Web
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly ICartService cartService;
        public ShoppingCartViewComponent(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            string cartItemCount = await cartService.GetCartItemsCountAsync(userId);
            return Content(cartItemCount);
        }
    }
}
