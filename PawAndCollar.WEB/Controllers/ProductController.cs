using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Creator;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
	using static PawAndCollar.Common.NotificationMessagesConstants;

	[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		private readonly ICategoryService categoryService;
		private readonly IEnumService enumService;
		private readonly ISizeService sizeService;
		private readonly ICreatorService creatorService;
		public ProductController(IProductService productService, ICategoryService categoryService, IEnumService enumService, ISizeService sizeService, ICreatorService creatorService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
			this.enumService = enumService;
			this.sizeService = sizeService;
			this.creatorService = creatorService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All([FromQuery] AllProductsQueryModel queryModel)
		{
			try
			{
				AllProductsFilteredAndPagedServiceModel products = await this.productService.GetAllProductsAsync(queryModel);
				queryModel.Products = products.Products;
				queryModel.TotalProducts = products.TotalProductsCount;
				queryModel.Sizes = await this.sizeService.GetAllSizesAsync();
				queryModel.Categories = await categoryService.AllCategoryNamesAsync();
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

			return View(queryModel);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Search()
		{
			var model = new SearchProductByNameViewModel();
			return View(model);
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Search(SearchProductByNameViewModel model)
		{
			if (ModelState.IsValid)
			{
				var searchedItem = model.SearchedItem;
				var products = await this.productService.SearchProductsByNameAsync(searchedItem);
				model.SearchResults = products;
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(this.User.GetId()!);
			if (!isCreator)
			{
				this.TempData[ErrorMessage] = "You are not a creator!";
				return this.RedirectToAction("Become", "Creator");
			}
			ICollection<ProductHomeViewModel> products = new List<ProductHomeViewModel>();
			string userId = this.User.GetId()!;
			try
			{
				if (isCreator)
				{
					string? creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(userId);
					products = await this.productService.GetAllProductsByCreatorIdAsync(creatorId!);
				}
				else
				{
					return this.RedirectToAction("Index", "Home");
				}
				return this.View(products);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Details(string id)
		{
			bool houseExists = await this.productService.ExistsByIdAsync(id);
			if (!houseExists)
			{
				this.TempData["ErrorMessage"] = "Product does not exist";
				return this.RedirectToAction("Index", "Home");
			}

			try
			{
				ProductDeatailsViewModel? product = await this.productService.GetDetailsByIdAsync(id);
				return View(product);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(this.User.GetId()!);
			if (!isCreator)
			{
				this.TempData[ErrorMessage] = "You are not a creator!";
				return this.RedirectToAction("Become", "Creator");
			}
			try
			{
				AddProductViewModel model = new AddProductViewModel();
				model.Categories = await this.categoryService.GetAllCategoriesAsync();
				model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
				return this.View(model);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

		}

		[HttpPost]
		public async Task<IActionResult> Add(AddProductViewModel model)
		{
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(this.User.GetId()!);
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

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(this.User.GetId()!);
			if (!isCreator)
			{
				this.TempData[ErrorMessage] = "You are not a creator!";
				return this.RedirectToAction("Become", "Creator");
			}
			string? creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(this.User.GetId()!);

			bool isCreatorOfProduct = await this.productService.IsCreatorWithIdOwnerOfProducWithIdAsync(id, creatorId!);
			if (!isCreatorOfProduct)
			{
				this.TempData[ErrorMessage] = "You are not the creator of this product!";
				return this.RedirectToAction("Mine", "Product");
			}
			try
			{
				AddProductViewModel? model = await productService.GetProductByIdAsync(id);
				model.Categories = await this.categoryService.GetAllCategoriesAsync();
				model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
				return this.View(model);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, AddProductViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = await this.categoryService.GetAllCategoriesAsync();
				model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
				return this.View(model);
			}
			bool isCreator = await this.creatorService.CreatorExistByUserIdAsync(this.User.GetId()!);
			if (!isCreator)
			{
				this.TempData[ErrorMessage] = "You are not a creator!";
				return this.RedirectToAction("Become", "Creator");
			}
			string? creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(this.User.GetId()!);
			bool isCreatorOfProduct = await this.productService.IsCreatorWithIdOwnerOfProducWithIdAsync(id, creatorId!);
			if (!isCreatorOfProduct)
			{
				this.TempData[ErrorMessage] = "You are not the creator of this product!";
				return this.RedirectToAction("Mine", "Product");
			}
			bool categoryExists = await this.categoryService.ExistByIdAsync(model.CategoryId);
			if (!categoryExists)
			{
				this.ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
			}
			try
			{
				await this.productService.EditProductAsync(model, creatorId!);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to edit your Product! Please try again later or contact administrator!");
				model.Categories = await this.categoryService.GetAllCategoriesAsync();
				model.SizeList = this.enumService.GetEnumSelectList<SizeTypes>();
				return this.View(model);
			}
			return this.RedirectToAction("Details", "Product", new { id = id });
		}

		private IActionResult GeneralError()
		{
			this.TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact administrator!";
			return this.RedirectToAction("Index", "Home");
		}
	}
}
