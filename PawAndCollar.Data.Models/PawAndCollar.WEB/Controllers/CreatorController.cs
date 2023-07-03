
namespace PawAndCollar.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using PawAndCollar.Data.Models.Enums;
	using PawAndCollar.Web.Infrastructure.Extensions;
	using PawAndCollar.Web.ViewModels.Creator;
	using PawAndCollarServices.Interfaces;
	using System.Security.Claims;
	using static PawAndCollar.Common.NotificationMessagesConstants;

	[Authorize]
	public class CreatorController : Controller
	{
		private readonly IEnumService enumService;
		private readonly IProductService productService;
		private readonly ICreatorService creatorService;
		public CreatorController(IEnumService enumService, IProductService productService, ICreatorService creatorService)
		{
			this.enumService = enumService;
			this.productService = productService;
			this.creatorService = creatorService;
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			string? userId = this.User.GetId();
			bool isCreator = await this.creatorService.AgentExistByUserIdAsync(userId);
			if (isCreator)
			{
				TempData[ErrorMessage] = "You are already a creator";
				return this.RedirectToAction("Index", "Home");
			}
			return this.View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeCreatorFormModel model)
		{
            string? userId = this.User.GetId();
            bool isCreator = await this.creatorService.AgentExistByUserIdAsync(userId);
            if (isCreator)
            {
                this.TempData[ErrorMessage] = "You are already a creator";
                return this.RedirectToAction("Index", "Home");
            }

			bool isPhoneNumberTaken = await this.creatorService.AgentExistByPhoneNumberAsync(model.PhoneNumber);
			if (isPhoneNumberTaken)
			{
				this.ModelState.AddModelError(nameof(model.PhoneNumber), "This phone number is already taken");
			}
			if (!this.ModelState.IsValid)
			{
				return this.View(model);
			}
			try
			{
                await this.creatorService.Create(userId, model);
            }
			catch (Exception)
			{
				this.TempData[ErrorMessage] = "Unexpected error occured while registering you as an creator! Please try again later or contact administrotor!";
				return this.RedirectToAction("Index", "Home");
			}
			this.TempData[SuccessMessage] = "You are now a creator";
			return this.RedirectToAction("Index", "Home");
        }

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			AddProductViewModel model = new AddProductViewModel();
			model.Categories = await this.productService.GetAllCategoriesAsync();
			model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			string ownerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
			await this.creatorService.AddProductAsync(model, ownerId);
			return this.RedirectToAction("Index", "Home");
		}
	}
}
