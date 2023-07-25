namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;
    using LiftingDome.Models;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Services.Data.Models.Workout;
    using LiftingDome.Web.ViewModels.Home;
    using LiftingDome.Web.ViewModels.Coach;
    using LiftingDome.Web.ViewModels.Workout;
    using LiftingDome.Web.ViewModels.Workout.Enums;
    using Microsoft.EntityFrameworkCore;

    public class WorkoutService : IWorkoutService
    {
        private readonly LiftingDomeDbContext liftingDomeDbContext;
        public WorkoutService(LiftingDomeDbContext liftingDomeDbContext)
        {
            this.liftingDomeDbContext = liftingDomeDbContext;
        }

		public async Task<AllWorkoutsFilteredAndPagedServiceModel> AllAsync(AllWorkoutsQueryModel queryModel)
		{
            IQueryable<Workout> workoutsQuery = this.liftingDomeDbContext
                .Workouts
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                workoutsQuery = workoutsQuery
                    .Where(w => w.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                workoutsQuery = workoutsQuery
                    .Where(w => EF.Functions.Like(w.Title, wildCard) ||
                                EF.Functions.Like(w.Description, wildCard) ||
                                EF.Functions.Like(w.Coach.Email, wildCard));
            }

            workoutsQuery = queryModel.WorkoutSorting switch
            {
                WorkoutSorting.Newest => workoutsQuery
                .OrderBy(w => w.CreatedOn),

                WorkoutSorting.Oldest => workoutsQuery
                .OrderByDescending(w => w.CreatedOn),

                WorkoutSorting.PriceAscending => workoutsQuery
                .OrderBy(w => w.Price),

                WorkoutSorting.PriceDescending => workoutsQuery
                .OrderByDescending(w => w.Price)
            };

            IEnumerable<AllWorkoutsViewModel> allWorkouts = await workoutsQuery
                .Where(w => w.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.WorkoutPerPage)
                .Take(queryModel.WorkoutPerPage)
                .Select(w => new AllWorkoutsViewModel
                {
                    Id = w.Id.ToString(),
                    Title = w.Title,
                    ImageUrl = w.ImageURL,
                    Price = w.Price
                }).ToArrayAsync();

            int totalWorkouts = workoutsQuery.Count();

            return new AllWorkoutsFilteredAndPagedServiceModel()
            {
                TotalWorkoutsCount = totalWorkouts,
                Workouts = allWorkouts
            };
		}

        public async Task<IEnumerable<AllWorkoutsViewModel>> AllByCoachIdAsync(string coachId)
        {
            IEnumerable<AllWorkoutsViewModel> allCoachWorkouts = await this.liftingDomeDbContext
                .Workouts
                .Where(w => w.IsActive && w.CoachId.ToString() == coachId)
                .Select(w => new AllWorkoutsViewModel 
                { 
                    Id = w.Id.ToString(),
                    Title = w.Title,
                    ImageUrl = w.ImageURL,
                    Price = w.Price
                })
                .ToArrayAsync();

            return allCoachWorkouts;
        }

        public async Task<IEnumerable<AllWorkoutsViewModel>> AllByTraineeIdAsync(string traineeId)
        {
            IEnumerable<AllWorkoutsViewModel> allTraineeWorkouts = await this.liftingDomeDbContext
                .Workouts
				.Where(w => w.IsActive && w.TraineeId.ToString() == traineeId)
                .Select(w => new AllWorkoutsViewModel
                {
                    Id = w.Id.ToString(),
                    Title = w.Title,
                    ImageUrl = w.ImageURL,
                    Price = w.Price
                })
                .ToArrayAsync();

            return allTraineeWorkouts ;
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

        public async Task<WorkoutDetailsViewModel?> GetDetailsByIdAsync(string workoutId)
        {
            Workout? workout = await this.liftingDomeDbContext
                .Workouts
                .Include(w => w.Category)
                .Include(w => w.Coach)
                .ThenInclude(c => c.User)
                .Where(w => w.IsActive)
                .FirstOrDefaultAsync(w => w.Id.ToString() == workoutId);

            if (workout == null)
            {
                return null;
            }

            return new WorkoutDetailsViewModel
            {
                Id = workout.Id.ToString(),
                Title = workout.Title,
                Description = workout.Description,
                ImageUrl = workout.ImageURL,
                Price = workout.Price,
                Category = workout.Category.Name,
                Coach = new CoachInfoWorkoutViewModel()
                {
                    Email = workout.Coach.User.Email,
                    PhoneNumber = workout.Coach.PhoneNumber
                }
            };
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeWorkoutsAsync()
        {
            IEnumerable<IndexViewModel> lastThreeWorkouts = await this.liftingDomeDbContext
                .Workouts
                .Where(w => w.IsActive)
                .OrderBy(w => w.CreatedOn)
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
