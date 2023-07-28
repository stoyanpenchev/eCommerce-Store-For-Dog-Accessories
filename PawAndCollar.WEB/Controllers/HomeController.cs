namespace PawAndCollar.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PawAndCollarServices.Interfaces;
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
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
                
            return View();
        }
    }
}