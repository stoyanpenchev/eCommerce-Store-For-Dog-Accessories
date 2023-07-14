using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PawAndCollar.Web.Controllers
{
	[Authorize]
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
