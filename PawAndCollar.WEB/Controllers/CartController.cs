using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private readonly ICartService cartService;
		public CartController(ICartService cartService)
		{
			this.cartService = cartService;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
