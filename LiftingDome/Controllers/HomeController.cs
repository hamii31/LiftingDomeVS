namespace LiftingDome.Controllers
{
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using static Common.GeneralApplicationConstants;
    public class HomeController : Controller
    {
        private readonly IWorkoutService workoutService;
		public HomeController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
		}

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Home", new {Area = AdminAreaName});
            }

            IEnumerable<IndexViewModel> viewModel = await this.workoutService.ThreeFreeWorkoutsAsync();
			return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            return View();
        }
    }
}