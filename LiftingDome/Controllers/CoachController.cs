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
        private readonly ICertificateService certificateService;
		private readonly IToastNotification _toastNotification;
		public CoachController(ICoachService coachService, ICertificateService certificateService, IToastNotification toastNotification)
        {
            this.coachService = coachService;
            this.certificateService = certificateService;
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
        public async Task<IActionResult> Become(CoachFormModel model)
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
                _toastNotification.AddErrorToastMessage("Phone number is taken!");
                return View(model);
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
        [HttpGet]
        public async Task<IActionResult> Update()
        {
            string? userId = this.User.GetId();

            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(userId!);
            if (!isCoach)
            {
                _toastNotification.AddErrorToastMessage("You must be a coach in order to update your certification!");
                return RedirectToAction("Index", "Home");
            }

            return View();
		}
        [HttpPost]
        public async Task<IActionResult> Update(CoachFormModel model)
        {
            string? userId = this.User.GetId();

            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(userId!);
            if (!isCoach)
            {
                _toastNotification.AddErrorToastMessage("You must be a coach in order to update your certification!");
                return RedirectToAction("Index", "Home");
            }

            bool isCertificateNameValid = await this.certificateService.IsCertificateNameValid(model.Certification);
            if (!isCertificateNameValid)
            {
                _toastNotification.AddErrorToastMessage("Certificate is not valid!");
                return View(model);
            }

            string? certificateId = await this.certificateService.GetCertificateIdByCertificateName(model.Certification);

            if (string.IsNullOrEmpty(certificateId))
            {
                this.ModelState.AddModelError(string.Empty, "Certificate does not exist");
            }

            if (!this.ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await this.coachService.UpdateInfo(model, userId!);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

			_toastNotification.AddSuccessToastMessage("You have updated your information successfully!");
			return RedirectToAction("All", "Workout");
		}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {

            List<AllCoachesViewModel> allCoaches = new List<AllCoachesViewModel>();

            try
            {
                allCoaches.AddRange(await this.coachService.GetAllCoachesAsync());

                return View(allCoaches);
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
