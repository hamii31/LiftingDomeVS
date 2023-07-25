namespace LiftingDome.Controllers
{
    using LiftingDome.Infrastructure.Extensions;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Services.Data.Models.Workout;
    using LiftingDome.Web.ViewModels.Calculator;
    using LiftingDome.Web.ViewModels.Workout;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static LiftingDome.Common.NotificationMessages;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutCategoryService workoutCategoryService;
        private readonly ICoachService coachService;
        private readonly IWorkoutService workoutService;
        public WorkoutController(IWorkoutCategoryService workoutCategoryService, ICoachService coachService, IWorkoutService workoutService)
        {
            this.workoutCategoryService = workoutCategoryService;
            this.coachService = coachService;
            this.workoutService = workoutService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllWorkoutsQueryModel queryModel)
        {
            AllWorkoutsFilteredAndPagedServiceModel serviceModel = 
                await this.workoutService.AllAsync(queryModel);

            queryModel.Workouts = serviceModel.Workouts;
            queryModel.TotalWorkouts = serviceModel.TotalWorkoutsCount;
            queryModel.Categories = await this.workoutCategoryService.AllCategoryNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(this.User.GetId()!);

            if (!isCoach)
            {
                this.TempData["message"] = "You must be a coach in order to add a workout!";
                return RedirectToAction("Become", "Coach");
            }

            WorkoutFormModel formModel;
            try
            {
                formModel = new WorkoutFormModel()
				{
					Categories = await this.workoutCategoryService.AllCategoriesAsync(),
				};

			}
            catch (Exception)
            {
				this.ModelState.AddModelError(nameof(formModel.Categories), "An unexpected error occured while fetching the categories! Please try again later! If the problem persists, please contact an administrator.");
				return RedirectToAction("Index", "Home");
			}

			return View(formModel);
		}

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutFormModel model)
        {
			bool isCoach = await this.coachService.CoachExistsByUserIdAsync(this.User.GetId()!);

			if (!isCoach)
			{
				this.TempData["message"] = "You must be a coach in order to add a workout!";
				return RedirectToAction("Become", "Coach");
			}

            bool categoryExists = await this.workoutCategoryService.ExistsByIdAsync(model.CategoryId);

            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "The category does not exist!");
            }

            if (!this.ModelState.IsValid)
            {
                try
                {
					model.Categories = await this.workoutCategoryService.AllCategoriesAsync();
				}
                catch (Exception)
                {
					this.ModelState.AddModelError(nameof(model.Categories), "An unexpected error occured while re-fetching the categories! Please try again later! If the problem persists, please contact an administrator.");
					return RedirectToAction("Index", "Home");
				}
                return View(model);
            }

            try
            {
                string? coachId = await this.coachService.GetCoachIdByUserIdAsync(this.User.GetId()!);

                await this.workoutService.CreateAsync(model, coachId!);
            }
            catch (Exception)
            {
				this.ModelState.AddModelError(string.Empty, "An unexpected error occured while adding your workout! Please try again later! If the problem persists, please contact an administrator.");
				model.Categories = await this.workoutCategoryService.AllCategoriesAsync();
				return View(model);
            }

            return RedirectToAction("All", "Workout");
		}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool existsById = await this.workoutService.ExistsByIdAsync(id);
            
            if (!existsById)
            {
                this.TempData["ErrorMessage"] = "Workout with the provided Id does not exist!";

                return RedirectToAction("All", "Workout");
            }

			WorkoutDetailsViewModel model = await this.workoutService.GetDetailsByIdAsync(id);

			return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
				this.TempData["ErrorMessage"] = "Workout with the provided Id does not exist!";

				return RedirectToAction("All", "Workout");
			}

            bool isCoach = await this.coachService
                .CoachExistsByUserIdAsync(this.User.GetId()!);

            if (!isCoach)
            {
                this.TempData[ErrorMessage] = "You must be a Coach in ordere to edit this information!";

                return RedirectToAction("Become", "Coach");
            }

            string? coachId = await this.coachService.GetCoachIdByUserIdAsync(this.User.GetId()!);

			bool isCoachOwner = await this.workoutService
                .IsCoachOwnerOfWorkoutWithId(coachId!, id);

            if (!isCoachOwner)
            {
                this.TempData["ErrorMessage"] = "You are not the owner of this workout!";

                return RedirectToAction("Mine", "Workout");
            }

            WorkoutFormModel formModel = await this.workoutService
                .GetWorkoutForEditByIdAsync(id);

            formModel.Categories = await this.workoutCategoryService.AllCategoriesAsync();

            return View(formModel);
		}

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<AllWorkoutsViewModel> myWorkouts = new List<AllWorkoutsViewModel>();

            string userId = this.User.GetId()!;

            bool IsCoach = await this.coachService.CoachExistsByUserIdAsync(userId);

            if (IsCoach)
            {
                string? coachId = await this.coachService.GetCoachIdByUserIdAsync(userId);

                myWorkouts.AddRange(await this.workoutService.AllByCoachIdAsync(coachId!));
            }
            else
            {
                myWorkouts.AddRange(await this.workoutService.AllByTraineeIdAsync(userId));
            }

            return View(myWorkouts);
        }
    }
}
