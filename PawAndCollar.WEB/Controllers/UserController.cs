namespace PawAndCollar.Web.Controllers
{
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using PawAndCollar.Data.Models.Models;
	using ViewModels.User;
	using static Common.GeneralApplicationConstants;

	using static Common.NotificationMessagesConstants;
	using Griesoft.AspNetCore.ReCaptcha;

	public class UserController : Controller
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;

		public UserController(SignInManager<ApplicationUser> signInManager,
							  UserManager<ApplicationUser> userManager,
							  RoleManager<IdentityRole<Guid>> roleManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			if (this.User.Identity.IsAuthenticated)
			{
				this.TempData[ErrorMessage] = "You are already registered!";
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpPost]
		[ValidateRecaptcha(Action = nameof(Register),
			ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (this.User.Identity.IsAuthenticated)
			{
				this.TempData[ErrorMessage] = "You are already registered!";
				return RedirectToAction("Index", "Home");
			}
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			ApplicationUser user = new ApplicationUser()
			{

			};
			if (!await this.roleManager.RoleExistsAsync(UserRoleName))
			{
				var role = new IdentityRole<Guid>(UserRoleName);
				await this.roleManager.CreateAsync(role);
			}

			await userManager.SetEmailAsync(user, model.Email);
			await userManager.SetUserNameAsync(user, model.Email);

			IdentityResult result =
				await userManager.CreateAsync(user, model.Password);

			if (user.Email != DevelopmentAdminEmail)
			{
				await userManager.AddToRoleAsync(user, UserRoleName);
			}
			if (!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				return View(model);
			}

			await signInManager.SignInAsync(user, false);

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> Login(string? returnUrl = null)
		{
			if (this.User.Identity.IsAuthenticated)
			{
				this.TempData[ErrorMessage] = "You are already logged in!";
				return RedirectToAction("Index", "Home");
			}
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			LoginFormModel model = new LoginFormModel()
			{
				ReturnUrl = returnUrl
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model)
		{
			if (this.User.Identity.IsAuthenticated)
			{
				this.TempData[ErrorMessage] = "You are already logged in!";
				return RedirectToAction("Index", "Home");
			}
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result =
				await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

			if (!result.Succeeded)
			{
				TempData[ErrorMessage] =
					"There was an error while logging you in! Please try again later or contact an administrator.";

				return View(model);
			}

			return Redirect(model.ReturnUrl ?? "/Home/Index");
		}
	}
}
