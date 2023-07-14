using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models.Models;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Cart;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
	using static PawAndCollar.Common.NotificationMessagesConstants;

	[Authorize]
	public class CartController : Controller
	{
		private readonly ICartService cartService;
		private readonly ICreatorService creatorService;
		private readonly IProductService productService;
		public CartController(ICartService cartService, ICreatorService creatorService, IProductService productService)
		{
			this.cartService = cartService;
			this.creatorService = creatorService;
			this.productService = productService;
		}
		[HttpGet]
		public async Task<IActionResult> ViewCart()
		{
			string userId = this.User.GetId()!;
			try
			{
				ViewCartViewModel cartViewModel = await this.cartService.GetCartItemsAsync(userId);
				return View(cartViewModel);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddToCart(int productId)
		{
			string userId = this.User.GetId()!;
			bool productExists = await this.productService.ExistsByIdAsync(productId);
			if (!productExists)
			{
				this.TempData["ErrorMessage"] = "Product does not exist";
				return this.RedirectToAction("Index", "Home");
			}

			string? creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(this.User.GetId()!);
			if (creatorId != null)
			{
				bool isCreatorOfProduct = await this.productService.IsCreatorWithIdOwnerOfProducWithIdAsync(productId, creatorId!);
				if (isCreatorOfProduct)
				{
					this.TempData[ErrorMessage] = "You are the creator of this product!";
					return this.RedirectToAction("Mine", "Product");
				}
			}
			try
			{
				await this.cartService.AddToCartAsync(userId, productId);
				return RedirectToAction(nameof(ViewCart));
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> IncreaseQuantity(int productId)
		{
			string userId = this.User.GetId()!;
			try
			{
                await this.cartService.IncreaseQuantityAsync(userId, productId);
                return RedirectToAction(nameof(ViewCart));
            }
            catch (Exception)
			{
                return this.GeneralError();
            }
		}

		[HttpPost]
		public async Task<IActionResult> DecreaseQuantity(int productId)
		{
			string userId = this.User.GetId()!;
			try
			{
				await this.cartService.DecreaseQuantityAsync(userId, productId);
				return RedirectToAction(nameof(ViewCart));
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCart(int productId)
		{
			string userId = this.User.GetId()!;
			try
			{
				await this.cartService.RemoveItemFromCart(userId, productId);
				return RedirectToAction(nameof(ViewCart));
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetCartItemCount()
		{
			string userId = this.User.GetId()!;
			try
			{
				string cartItemCount = await this.cartService.GetCartItemsCountAsync(userId);
				return Content(cartItemCount);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		private IActionResult GeneralError()
		{
			this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
			return this.RedirectToAction("Index", "Home");
		}
	}
}
