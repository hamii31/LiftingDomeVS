namespace LiftingDome.Areas.Admin.Controllers
{
	using LiftingDome.Areas.Admin.Services.Interfaces;
	using LiftingDome.Web.ViewModels.User;
	using Microsoft.AspNetCore.Mvc;
	public class AdminController : BaseAdminController
	{
		private readonly IAdministratorService adminService;

		public AdminController(IAdministratorService administratorService)
		{
			this.adminService = administratorService;
		}

		public async Task<IActionResult> All()
		{
			List<AllUsersViewModel> allUsers = new List<AllUsersViewModel>();
			try
			{
				allUsers.AddRange(await this.adminService.GetAllUsersAsync());

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
