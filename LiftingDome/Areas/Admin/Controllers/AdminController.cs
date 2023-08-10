namespace LiftingDome.Areas.Admin.Controllers
{
	using LiftingDome.Areas.Admin.Services.Interfaces;
	using LiftingDome.Web.ViewModels.User;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;

	using static Common.GeneralApplicationConstants;

	public class AdminController : BaseAdminController
	{
		private readonly IAdministratorService adminService;
		private readonly IMemoryCache memoryCache;

		public AdminController(IAdministratorService administratorService, IMemoryCache memoryCache)
		{
			this.adminService = administratorService;
			this.memoryCache = memoryCache;
		}

		public async Task<IActionResult> All()
		{

            IEnumerable<AllUsersViewModel> allUsers =
                    this.memoryCache.Get<IEnumerable<AllUsersViewModel>>(UserCacheKey);
            try
			{
				
				if (allUsers == null)
				{
					allUsers = await this.adminService.GetAllUsersAsync();

					MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions()
						.SetAbsoluteExpiration(TimeSpan
							.FromMinutes(UserCacheDurationMinutes));

					this.memoryCache.Set(UserCacheKey, allUsers, memoryCacheEntryOptions);
				}

                return View(allUsers);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}

		private IActionResult GeneralError()
		{
			this.ModelState.AddModelError(string.Empty, "An unexpected error occured! Please try again later! If the problem persists, please contact an administrator.");
			return RedirectToAction("Index", "Home");
		}
	}
}
