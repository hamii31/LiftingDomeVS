namespace LiftingDome.Services.Data.Interfaces
{
	using LiftingDome.Web.ViewModels.WorkoutCategory;

	public interface IWorkoutCategoryService
	{
		Task<IEnumerable<WorkoutCategorySelectFormModel>> AllCategoriesAsync();
		Task<IEnumerable<AllWorkoutCategoryViewModel>> AllCategoriesForListAsync();
		Task<bool> ExistsByIdAsync(int id);
		Task<IEnumerable<string>> AllCategoryNamesAsync();
	}
}
