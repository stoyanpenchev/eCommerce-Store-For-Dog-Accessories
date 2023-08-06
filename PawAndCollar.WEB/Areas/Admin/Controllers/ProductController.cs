using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PawAndCollar.Web.Areas.Admin.Services.Interfaces;
using PawAndCollar.Web.Areas.Admin.ViewModels.Product;

namespace PawAndCollar.Web.Areas.Admin.Controllers
{
    using static Common.GeneralApplicationConstants;
    public class ProductController : BaseAdminController
    {
        private readonly IUserBuyedProductsService productService;
        private readonly IMemoryCache memoryCache;
        public ProductController(IUserBuyedProductsService productService, IMemoryCache memoryCache)
        {
            this.productService = productService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [ResponseCache(Duration = 90, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> MostBuyed()
        {
            IEnumerable<MostBuyedProductsViewModel> products = this.memoryCache.Get<IEnumerable<MostBuyedProductsViewModel>>(MostBuyedProductsCacheKey);

            if(products == null)
            {
                	products = await this.productService.GetMostBuyedProductsAsync();

				MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
					.SetAbsoluteExpiration(TimeSpan.FromMinutes(MostBuyedProductsCacheDurationsMinutes));

				this.memoryCache.Set(MostBuyedProductsCacheKey, products, cacheOptions);
            }
            return this.View(products);
        }
    }
}
