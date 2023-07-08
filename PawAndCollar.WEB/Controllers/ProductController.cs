using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Data.Models.Enums;
using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.Infrastructure.Extensions;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
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
        public async Task<IActionResult> All([FromQuery]AllProductsQueryModel queryModel)
        {
            AllProductsFilteredAndPagedServiceModel products = await this.productService.GetAllProductsAsync(queryModel);
            queryModel.Products = products.Products;
            queryModel.TotalProducts = products.TotalProductsCount;
            queryModel.Sizes = await this.sizeService.GetAllSizesAsync();
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();

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
            ICollection<ProductHomeViewModel> products = new List<ProductHomeViewModel>();
            string userId = this.User.GetId()!;
            bool isCreator = await this.creatorService.AgentExistByUserIdAsync(userId);
            if(isCreator)
            {
                string creatorId = await this.creatorService.GetCreatorIdByUserIdAsync(userId);
				products = await this.productService.GetAllProductsByCreatorIdAsync(creatorId);
			}
            else
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View(products);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            ProductDeatailsViewModel? product = await this.productService.GetDetailsByIdAsync(id);
            if(product == null)
            {
                this.TempData["ErrorMessage"] = "Product does not exist";
				return this.RedirectToAction("Index", "Home");
			}
            return View(product);
        }
    }
}
