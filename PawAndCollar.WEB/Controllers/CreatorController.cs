
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
		private readonly ICategoryService categoryService;
		private readonly ICreatorService creatorService;
		private readonly IProductService productService;
		public CreatorController(IEnumService enumService, ICategoryService categoryService, ICreatorService creatorService, IProductService productService)
		{
			this.enumService = enumService;
			this.creatorService = creatorService;
			this.categoryService = categoryService;
			this.productService = productService;
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
			bool isCreator = await this.creatorService.AgentExistByUserIdAsync(this.User.GetId()!);
			if (!isCreator)
			{
				this.TempData[ErrorMessage] = "You are not a creator!";
				return this.RedirectToAction("Become", "Creator");
			}
			AddProductViewModel model = new AddProductViewModel();
			model.Categories = await this.categoryService.GetAllCategoriesAsync();
			model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
			return this.View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddProductViewModel model)
		{
			bool isCreator = await this.creatorService.AgentExistByUserIdAsync(this.User.GetId()!);
			if (!isCreator)
			{
				this.TempData[ErrorMessage] = "You are not a creator!";
				return this.RedirectToAction("Become", "Creator");
			}
			bool categoryExists = await this.categoryService.ExistByIdAsync(model.CategoryId);
			if (!categoryExists)
			{
				this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
			}
			if (!ModelState.IsValid)
			{
				model.Categories = await this.categoryService.GetAllCategoriesAsync();
				model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
				return this.View(model);
			}
			try
			{
				string? creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(this.User.GetId()!);
				await this.productService.AddProductAsync(model, creatorId!);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add your new Product! Please try again later or contact administrator!");
				model.Categories = await this.categoryService.GetAllCategoriesAsync();
				model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
				return this.View(model);
			}
			return this.RedirectToAction("Index", "Home");
		}
	}
}
