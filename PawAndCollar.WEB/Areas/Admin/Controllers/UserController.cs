namespace PawAndCollar.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using PawAndCollar.Web.ViewModels.User;
	using PawAndCollarServices.Interfaces;
    using static Common.NotificationMessagesConstants;

    public class UserController : BaseAdminController
	{
		private readonly IApplicationUserService userService;
		public UserController(IApplicationUserService userService)
		{
			this.userService = userService;
		}

		[Route("User/All")]
		public async Task<IActionResult> All()
		{
			IEnumerable<ApplicationUserViewModel> usersViewModel = await this.userService.AllAsync();

			return this.View(usersViewModel);
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
