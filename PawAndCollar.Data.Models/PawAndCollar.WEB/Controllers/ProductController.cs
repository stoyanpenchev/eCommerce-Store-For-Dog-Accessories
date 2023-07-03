using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Web.ViewModels.Product;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await this.productService.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Search()
        {
            var model = new SearchProductByNameViewModel();
            return View(model);
        }

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
