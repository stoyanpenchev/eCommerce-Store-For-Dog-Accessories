using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Services.Data.Models.Product;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]AllProductsQueryModel queryModel)
        {
            AllProductsFilteredAndPagedServiceModel products = await this.productService.GetAllProductsAsync(queryModel);
            queryModel.Products = products.Products;
            queryModel.TotalProducts = products.TotalProductsCount;
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
    }
}
