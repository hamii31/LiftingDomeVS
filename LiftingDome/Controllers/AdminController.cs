namespace LiftingDome.Controllers
{
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Web.ViewModels.Admin;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using static Common.GeneralApplicationConstants;
	public class AdminController : Controller
	{
		private readonly IAdministratorService adminService;
		public AdminController(IAdministratorService adminService)
		{
			this.adminService = adminService;
		}

		[Authorize(Roles = AdminRoleName)]
		[HttpGet]
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
