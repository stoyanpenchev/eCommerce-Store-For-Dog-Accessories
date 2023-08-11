namespace PawAndCollar.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using PawAndCollar.Web.Infrastructure.Extensions;
	using PawAndCollar.Web.ViewModels.Creator;
	using PawAndCollarServices.Interfaces;
	using static PawAndCollar.Common.NotificationMessagesConstants;

	[Authorize]
	public class CreatorController : Controller
	{
		private readonly ICreatorService creatorService;
		public CreatorController(ICreatorService creatorService)
		{
			this.creatorService = creatorService;
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			string? userId = this.User.GetId();
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(userId);
			if (isCreator)
			{
				TempData[ErrorMessage] = "You are already a creator";
				return this.RedirectToAction("Index", "Home");
			}
			return this.View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Become(BecomeCreatorFormModel model)
		{
			string? userId = this.User.GetId();
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(userId);
			if (isCreator)
			{
				this.TempData[ErrorMessage] = "You are already a creator";
				return this.RedirectToAction("Index", "Home");
			}

			bool isPhoneNumberTaken = await this.creatorService.CreatorExistByPhoneNumberAsync(model.PhoneNumber);
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

	}
}
