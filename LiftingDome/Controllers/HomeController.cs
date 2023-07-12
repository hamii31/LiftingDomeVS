namespace LiftingDome.Controllers
{
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        private readonly IWorkoutService workoutService;

        public HomeController(IWorkoutService workoutService)
        {
            this.workoutService = workoutService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await this.workoutService.LastThreeWorkoutsAsync();

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}