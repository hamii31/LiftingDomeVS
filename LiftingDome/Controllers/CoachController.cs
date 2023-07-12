namespace LiftingDome.Controllers
{
    using LiftingDome.Infrastructure.Extensions;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Coach;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class CoachController : Controller
    {
        private readonly ICoachService coachService;
        public CoachController(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(userId);
            if (isCoach)
            {
				this.TempData["message"] = "You are already an agent!";
				return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeCoachFormModel model)
        {
            string? userId = this.User.GetId();

            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(userId);
            if (isCoach)
            {
                this.TempData["message"] = "You are already an agent!";
                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.coachService.CoachExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number unavailable!");
            }
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await this.coachService.Create(userId, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "An unexpected error occured while registering you as a coach! Please try again later! If the problem persists, please contact an administrator.");
				return RedirectToAction("Index", "Home");
			}

            return RedirectToAction("All", "Workout");
        }
    }
}
