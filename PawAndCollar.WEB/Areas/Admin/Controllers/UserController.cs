namespace PawAndCollar.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using PawAndCollar.Web.ViewModels.User;
	using PawAndCollarServices.Interfaces;
    using static Common.NotificationMessagesConstants;
	using static Common.GeneralApplicationConstants;

    public class UserController : BaseAdminController
	{
		private readonly IApplicationUserService userService;
		private readonly IMemoryCache memoryCache;
		public UserController(IApplicationUserService userService, IMemoryCache memoryCache)
		{
			this.memoryCache = memoryCache;
			this.userService = userService;
		}

		[Route("User/All")]
		//[ResponseCache(Duration = 30, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> All()
		{
			IEnumerable<ApplicationUserViewModel> users = this.memoryCache.Get<IEnumerable<ApplicationUserViewModel>>(UsersCacheKey);
			if(users == null)
			{
				users = await this.userService.AllAsync();

				MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
					.SetAbsoluteExpiration(TimeSpan.FromSeconds(UsersCacheDurationsSec));

				this.memoryCache.Set(UsersCacheKey, users, cacheOptions);
			}

			return this.View(users);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
		{
			
			ApplicationUserViewModel? user = await this.userService.GetUserByIdAsync(Guid.Parse(id));
			if(user == null)
			{
				this.TempData[ErrorMessage] = "User not found!";
				return this.RedirectToAction("All");
			}
			if (user.OpenOrders == false)
			{
				await this.userService.DeleteUserAsync(Guid.Parse(id));
				this.TempData[SuccessMessage] = "User deleted!";
				memoryCache.Remove(UsersCacheKey);
				return this.RedirectToAction("All");
			}
			else
			{
				this.TempData[ErrorMessage] = "User have open orders!";
				return this.RedirectToAction("All");
            }
		}
	}
}
