﻿namespace LiftingDome.Controllers
{
    using LiftingDome.Infrastructure.Extensions;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Workout;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return View();
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

            AddWorkoutFormModel formModel;
            try
            {
                formModel = new AddWorkoutFormModel()
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
        public async Task<IActionResult> Add(AddWorkoutFormModel model)
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
	}
}
