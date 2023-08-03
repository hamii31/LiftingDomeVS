namespace LiftingDome.Services.Data
{
	using LiftingDome.Data;

	using LiftingDome.Services.Data.Interfaces;

	using LiftingDome.Web.ViewModels.WorkoutCategory;

	using Microsoft.EntityFrameworkCore;

	public class WorkoutCategoryService : IWorkoutCategoryService
	{
		private readonly LiftingDomeDbContext liftingDomeDbContext;
		public WorkoutCategoryService(LiftingDomeDbContext liftingDomeDbContext)
		{
			this.liftingDomeDbContext = liftingDomeDbContext;
		}

		public async Task<IEnumerable<WorkoutCategorySelectFormModel>> AllCategoriesAsync()
		{
			IEnumerable<WorkoutCategorySelectFormModel> allCategories = await this.liftingDomeDbContext
				.WorkoutCategories
				.AsNoTracking()
				.Select(c => new WorkoutCategorySelectFormModel()
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToArrayAsync();

			return allCategories;
		}

		public async Task<IEnumerable<AllWorkoutCategoryViewModel>> AllCategoriesForListAsync()
		{
			IEnumerable<AllWorkoutCategoryViewModel> allCategories = await this.liftingDomeDbContext
				.WorkoutCategories
				.AsNoTracking()
				.Select(c => new AllWorkoutCategoryViewModel()
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToArrayAsync();

			return allCategories;
		}

		public async Task<IEnumerable<string>> AllCategoryNamesAsync()
		{
			IEnumerable<string> allNames = await this.liftingDomeDbContext
				.WorkoutCategories
				.Select(c => c.Name)
				.ToArrayAsync();

			return allNames;
		}

		public async Task<bool> ExistsByIdAsync(int id)
		{
			bool result = await this.liftingDomeDbContext
				.WorkoutCategories
				.AnyAsync(c => c.Id == id);

			return result;
		}
	}
}
