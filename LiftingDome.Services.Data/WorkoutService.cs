namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.Home;
    using Microsoft.EntityFrameworkCore;

    public class WorkoutService : IWorkoutService
    {
        private readonly LiftingDomeDbContext liftingDomeDbContext;
        public WorkoutService(LiftingDomeDbContext liftingDomeDbContext)
        {
            this.liftingDomeDbContext = liftingDomeDbContext;
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
