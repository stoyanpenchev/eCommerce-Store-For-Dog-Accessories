namespace PawAndCollar.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PawAndCollar.Web.ViewModels.Home;
    using PawAndCollar.Web.ViewModels.Product;
    using PawAndCollarServices.Interfaces;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await this.productService.GetHomePageProductsAsync();
            return View(models);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}