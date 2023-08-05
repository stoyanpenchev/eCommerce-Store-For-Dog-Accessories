using Microsoft.AspNetCore.Mvc;

namespace PawAndCollar.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
