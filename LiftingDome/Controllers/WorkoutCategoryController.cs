namespace LiftingDome.Controllers
{
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Web.ViewModels.WorkoutCategory;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	public class WorkoutCategoryController : Controller
	{
		private readonly IWorkoutCategoryService workoutCategoryService;

		public WorkoutCategoryController(IWorkoutCategoryService workoutCategoryService)
		{
			this.workoutCategoryService = workoutCategoryService;
		}

		public async Task<IActionResult> All()
		{
			IEnumerable<AllWorkoutCategoryViewModel> formModel = 
				await this.workoutCategoryService
				.AllCategoriesForListAsync();

 			return View(formModel);
		}
		public async Task<IActionResult> Details(int id, string information)
		{
			return this.Ok();
		}
	}
}
