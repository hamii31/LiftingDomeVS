namespace LiftingDome.Controllers
{
    using LiftingDome.Infrastructure.Extensions;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Coach;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NToastNotify;

    [Authorize]
    public class CoachController : Controller
    {
        private readonly ICoachService coachService;
		private readonly IToastNotification _toastNotification;
		public CoachController(ICoachService coachService, IToastNotification toastNotification)
        {
            this.coachService = coachService;
			_toastNotification = toastNotification;
		}

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(userId!);
            if (isCoach)
            {
                _toastNotification.AddErrorToastMessage("You are already a coach!");
				return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Become(BecomeCoachFormModel model)
        {
            string? userId = this.User.GetId();

            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(userId!);
            if (isCoach)
            {
                _toastNotification.AddErrorToastMessage("You are already a coach!");
                return RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.coachService.CoachExistsByPhoneNumberAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(string.Empty, "Phone number unavailable!");
            }
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await this.coachService.Create(userId!, model);
            }
            catch (Exception)
            {
                return this.GeneralError();
			}

            _toastNotification.AddSuccessToastMessage("You have become a coach successfully!");
            return RedirectToAction("All", "Workout");
        }

        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, "An unexpected error occured! Please try again later! If the problem persists, please contact an administrator.");
            return RedirectToAction("Index", "Home");
        }
    }
}
