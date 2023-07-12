namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;
    using LiftingDome.Models;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Home;
    using LiftingDome.Web.ViewModels.Workout;
    using Microsoft.EntityFrameworkCore;

    public class WorkoutService : IWorkoutService
    {
        private readonly LiftingDomeDbContext liftingDomeDbContext;
        public WorkoutService(LiftingDomeDbContext liftingDomeDbContext)
        {
            this.liftingDomeDbContext = liftingDomeDbContext;
        }

		public async Task CreateAsync(AddWorkoutFormModel model, string coachId)
		{
			Workout workout = new Workout()
            {
                Title = model.Title,
                Description = model.Description,
                ImageURL = model.ImageUrl,
                Price = model.Price,
                WorkoutCategoryId = model.CategoryId,
                CoachId = Guid.Parse(coachId) 
            };

            await this.liftingDomeDbContext.Workouts.AddAsync(workout);
            await this.liftingDomeDbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<IndexViewModel>> LastThreeWorkoutsAsync()
        {
            IEnumerable<IndexViewModel> lastThreeWorkouts = await this.liftingDomeDbContext
                .Workouts
                .OrderByDescending(w => w.CreatedOn)
                .Take(3)
                .Select(w => new IndexViewModel
                {
                    Id = w.Id.ToString(),
                    Title = w.Title,
                    ImageUrl = w.ImageURL
                })
                .ToArrayAsync();

            return lastThreeWorkouts;
        }
    }
}
