namespace LiftingDome.Controllers
{
	using LiftingDome.Models;
	using LiftingDome.Web.ViewModels.User;
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;
	using NToastNotify;
	using static Common.GeneralApplicationConstants;
	public class UserController : Controller
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IMemoryCache memoryCache;
		private readonly IToastNotification _toastNotification;

		public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache, IToastNotification toastNotification)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.memoryCache = memoryCache;
			this._toastNotification = toastNotification;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			ApplicationUser user = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
			};

			await this.userManager.SetEmailAsync(user, model.Email);
			await this.userManager.SetUserNameAsync(user, model.Email);

			IdentityResult result = 
				await this.userManager.CreateAsync(user, model.Password);

			if (!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}

				return View(model);
			}

            await this.signInManager.SignInAsync(user, false);
			this.memoryCache.Remove(UserCacheKey);

			_toastNotification.AddSuccessToastMessage("Successfully registered!");
            return RedirectToAction("Index", "Home");
        }

		[HttpGet]
		public async Task<IActionResult> Login(string? returnUrl = null)
		{
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			LoginFormModel formModel = new LoginFormModel()
			{
				ReturnUrl = returnUrl
			};
			return View(formModel);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = 
				await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
				_toastNotification.AddErrorToastMessage("There was an error while logging you in! Please try again later or contact an administrator if the problem persists!");
                return View(model);
            }

            _toastNotification.AddSuccessToastMessage("Successfully logged in!");
            return RedirectToAction("Index", "Home");
		}
	}
}
