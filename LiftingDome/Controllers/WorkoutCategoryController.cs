namespace LiftingDome.Controllers
{
	using LiftingDome.Infrastructure.Extensions;
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Web.ViewModels.WorkoutCategory;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using NToastNotify;

	[Authorize]
	public class WorkoutCategoryController : Controller
	{
		private readonly IWorkoutCategoryService workoutCategoryService;
		private readonly IToastNotification _toastNotification;

		public WorkoutCategoryController(IWorkoutCategoryService workoutCategoryService, IToastNotification toastNotification)
		{
			this.workoutCategoryService = workoutCategoryService;
			this._toastNotification = toastNotification;
		}
		[HttpGet]
		public async Task<IActionResult> All()
		{
			IEnumerable<AllWorkoutCategoryViewModel> formModel = 
				await this.workoutCategoryService
				.AllCategoriesForListAsync();

 			return View(formModel);
		}
		[HttpGet]
		public async Task<IActionResult> Details(int id, string information)
		{
			bool categoryExists = await this.workoutCategoryService.ExistsByIdAsync(id);

			if (!categoryExists)
			{
				return this.NotFound();
			}

			WorkoutCategoryDetailsViewModel viewModel =
				await this.workoutCategoryService.GetDetailsForCategoryWithIdAsync(id);

			if (viewModel.GetUrlInfo() != information)
			{
				return this.NotFound();
			}

			return View(viewModel);
			
		}
	}
}
