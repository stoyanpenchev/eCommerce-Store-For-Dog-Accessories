using Microsoft.AspNetCore.Mvc;
using PawAndCollar.Web.Areas.Admin.Services.Interfaces;
using PawAndCollar.Web.Areas.Admin.ViewModels.Product;
using PawAndCollarServices.Interfaces;

namespace PawAndCollar.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseAdminController
    {
        private readonly IUserBuyedProductsService productService;
        public ProductController(IUserBuyedProductsService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> MostBuyed()
        {
            IEnumerable<MostBuyedProductsViewModel> products = await this.productService.GetMostBuyedProductsAsync();
            return this.View(products);
        }
    }
}
