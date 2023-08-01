namespace LiftingDome.Controllers
{
    using LiftingDome.Infrastructure.Extensions;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Services.Data.Models.Workout;
    using LiftingDome.Web.ViewModels.Workout;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NToastNotify;

    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutCategoryService workoutCategoryService;
        private readonly ICoachService coachService;
        private readonly IWorkoutService workoutService;
		private readonly IToastNotification _toastNotification;
		public WorkoutController(IWorkoutCategoryService workoutCategoryService, ICoachService coachService, IWorkoutService workoutService, IToastNotification toastNotification)
        {
            this.workoutCategoryService = workoutCategoryService;
            this.coachService = coachService;
            this.workoutService = workoutService;
			_toastNotification = toastNotification;
		}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllWorkoutsQueryModel queryModel)
        {
            try
            {
                AllWorkoutsFilteredAndPagedServiceModel serviceModel = await this.workoutService.AllAsync(queryModel);

                queryModel.Workouts = serviceModel.Workouts;
                queryModel.TotalWorkouts = serviceModel.TotalWorkoutsCount;
                queryModel.Categories = await this.workoutCategoryService.AllCategoryNamesAsync();

                return View(queryModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isCoach = await this.coachService.CoachExistsByUserIdAsync(this.User.GetId()!);

            if (!isCoach)
            {
                _toastNotification.AddErrorToastMessage("You must be a coach in order to add a workout!");
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
                return this.GeneralError();
            }

			return View(formModel);
		}

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutFormModel model)
        {
			bool isCoach = await this.coachService.CoachExistsByUserIdAsync(this.User.GetId()!);

			if (!isCoach)
			{
                _toastNotification.AddErrorToastMessage("You must be a coach in order to add a workout!");
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
                    return this.GeneralError();
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
            _toastNotification.AddSuccessToastMessage("Workout added successfully!");
            return RedirectToAction("All", "Workout");
		}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool existsById = await this.workoutService.ExistsByIdAsync(id);
            
            if (!existsById)
            {
                _toastNotification.AddErrorToastMessage("Workout with the provided Id does not exist!");
                return RedirectToAction("All", "Workout");
            }
            try
            {
                WorkoutDetailsViewModel model = await this.workoutService.GetDetailsByIdAsync(id);

                return View(model);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
                _toastNotification.AddErrorToastMessage("Workout with the provided Id does not exist!");
				return RedirectToAction("All", "Workout");
			}

            bool isCoach = await this.coachService
                .CoachExistsByUserIdAsync(this.User.GetId()!);

            if (!isCoach)
            {
                _toastNotification.AddErrorToastMessage("You must be a Coach in order to edit this information!");
                return RedirectToAction("Become", "Coach");
            }

            string? coachId = await this.coachService.GetCoachIdByUserIdAsync(this.User.GetId()!);

			bool isCoachOwner = await this.workoutService
                .IsCoachOwnerOfWorkoutWithIdAsync(coachId!, id);

            if (!isCoachOwner)
            {
                _toastNotification.AddErrorToastMessage("You are not the owner of this workout!");
                return RedirectToAction("Mine", "Workout");
            }

            try
            {
                WorkoutFormModel formModel = await this.workoutService
                .GetWorkoutForEditByIdAsync(id);

                formModel.Categories = await this.workoutCategoryService.AllCategoriesAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        
		}
        [HttpPost]
        public async Task<IActionResult> Edit(string id, WorkoutFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.workoutCategoryService.AllCategoriesAsync();
                return View(model);
            }

			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
				_toastNotification.AddErrorToastMessage("Workout with the provided Id does not exist!");
				return RedirectToAction("All", "Workout");
			}

			bool isCoach = await this.coachService
				.CoachExistsByUserIdAsync(this.User.GetId()!);

			if (!isCoach)
			{
				_toastNotification.AddErrorToastMessage("You must be a Coach in order to edit this information!");
				return RedirectToAction("Become", "Coach");
			}

			string? coachId = await this.coachService.GetCoachIdByUserIdAsync(this.User.GetId()!);

			bool isCoachOwner = await this.workoutService
				.IsCoachOwnerOfWorkoutWithIdAsync(coachId!, id);

			if (!isCoachOwner)
			{
				_toastNotification.AddErrorToastMessage("You are not the owner of this workout!");
				return RedirectToAction("Mine", "Workout");
			}


			try
			{
                await this.workoutService.EditWorkoutByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while saving the changes to your workout. Please try again later or contact administrator");
                model.Categories = await this.workoutCategoryService.AllCategoriesAsync();
                return View(model);
            }
            _toastNotification.AddSuccessToastMessage("Workout changes saved successfully!");
            return RedirectToAction("Details", "Workout", new { id });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
				_toastNotification.AddErrorToastMessage("Workout with the provided Id does not exist!");
				return RedirectToAction("All", "Workout");
			}

			bool isCoach = await this.coachService
				.CoachExistsByUserIdAsync(this.User.GetId()!);

			if (!isCoach)
			{
				_toastNotification.AddErrorToastMessage("You must be a Coach in order to edit this information!");
				return RedirectToAction("Become", "Coach");
			}

			string? coachId = await this.coachService.GetCoachIdByUserIdAsync(this.User.GetId()!);

			bool isCoachOwner = await this.workoutService
				.IsCoachOwnerOfWorkoutWithIdAsync(coachId!, id);

			if (!isCoachOwner)
			{
				_toastNotification.AddErrorToastMessage("You are not the owner of this workout!");
				return RedirectToAction("Mine", "Workout");
			}

            try
            {
                WorkoutPreDeleteDetailsViewModel formModel = await this.workoutService.GetWorkoutForDeleteByIdAsync(id);

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
		}
        [HttpPost]
        public async Task<IActionResult> Delete(string id, WorkoutPreDeleteDetailsViewModel model)
        {
			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
				_toastNotification.AddErrorToastMessage("Workout with the provided Id does not exist!");
				return RedirectToAction("All", "Workout");
			}

			bool isCoach = await this.coachService
				.CoachExistsByUserIdAsync(this.User.GetId()!);

			if (!isCoach)
			{
				_toastNotification.AddErrorToastMessage("You must be a Coach in order to edit this information!");
				return RedirectToAction("Become", "Coach");
			}

			string? coachId = await this.coachService.GetCoachIdByUserIdAsync(this.User.GetId()!);

			bool isCoachOwner = await this.workoutService
				.IsCoachOwnerOfWorkoutWithIdAsync(coachId!, id);

			if (!isCoachOwner)
			{
				_toastNotification.AddErrorToastMessage("You are not the owner of this workout!");
				return RedirectToAction("Mine", "Workout");
			}

            try
            {
                await this.workoutService.DeleteWorkoutByIdAsync(id);
                _toastNotification.AddWarningToastMessage("Workout successfully deleted!");
                return RedirectToAction("Mine", "Workout");
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
		}
        [HttpPost]
        public async Task<IActionResult> Get(string id)
        {
			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
				_toastNotification.AddErrorToastMessage("Workout with the provided Id does not exist!");
				return RedirectToAction("All", "Workout");
			}

            bool workoutIsOwned = await this.workoutService.WorkoutIsOwnedByIdAsync(id, this.User.GetId()!);

			if (workoutIsOwned)
			{
				_toastNotification.AddErrorToastMessage("Workout with the provided Id is already owned!");
				return RedirectToAction("Mine", "Workout");
			}

			bool isUserCoach = await this.coachService
				.CoachExistsByUserIdAsync(this.User.GetId()!);

			if (isUserCoach)
			{
				_toastNotification.AddErrorToastMessage("You can't get a workout as a Coach! Register as a trainee or contact the owner of the workout!");
				return RedirectToAction("Index", "Home");
			}

            try
            {
                await this.workoutService.AddWorkoutToUserAsync(id, this.User.GetId()!);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            _toastNotification.AddSuccessToastMessage("Workout successfully added to your collection!");
            return RedirectToAction("Mine", "Workout");
		}
        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
			bool workoutExists = await this.workoutService.ExistsByIdAsync(id);

			if (!workoutExists)
			{
				_toastNotification.AddErrorToastMessage("Workout does not exist!");
				return RedirectToAction("All", "Workout");
			}

			bool workoutIsOwned = await this.workoutService.WorkoutIsOwnedByIdAsync(id, this.User.GetId()!);

			if (!workoutIsOwned)
			{
				_toastNotification.AddErrorToastMessage("Workout is not owned by the user!");
				return RedirectToAction("Mine", "Workout");
			}

            try
            {
                await this.workoutService.RemoveWorkoutByIdAsync(id);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }

            _toastNotification.AddWarningToastMessage("Workout successfully removed!");
            return RedirectToAction("Mine", "Workout");
		}

		[HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<AllWorkoutsViewModel> myWorkouts = new List<AllWorkoutsViewModel>();

            string userId = this.User.GetId()!;

            bool IsCoach = await this.coachService.CoachExistsByUserIdAsync(userId);

            try
            {
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
