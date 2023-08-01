using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Review;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
	using static PawAndCollar.Common.NotificationMessagesConstants;
	public class ReviewController : Controller
	{
		private readonly IReviewService reviewService;
		private readonly IProductService productService;
		public ReviewController(IReviewService reviewService, IProductService productService)
		{
			this.reviewService = reviewService;
			this.productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> ReviewIndex(int id)
		{
			bool isProductExisting = await this.productService.ExistsByIdAsync(id);
			if (!isProductExisting)
			{
				this.TempData["ErrorMessage"] = "Product does not exist";
				return this.RedirectToAction("Index", "Home");
			}
			string? userId = this.User.GetId();
			ReviewViewModel reviewModel = await this.reviewService.GetReviewByProductIdAsync(id, userId);
			return this.View(reviewModel);
		}

		private IActionResult GeneralError()
		{
			this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
			return this.RedirectToAction("Index", "Home");
		}
	}
}
