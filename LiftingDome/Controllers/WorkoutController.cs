namespace LiftingDome.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [Authorize]
    public class WorkoutController : Controller
    {

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
        }
    }
}
