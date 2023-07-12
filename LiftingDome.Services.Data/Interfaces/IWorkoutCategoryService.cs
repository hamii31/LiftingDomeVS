namespace LiftingDome.Services.Data.Interfaces
{
	using LiftingDome.Web.ViewModels.WorkoutCategory;

	public interface IWorkoutCategoryService
	{
		Task<IEnumerable<WorkoutCategorySelectFormModel>> AllCategoriesAsync();
		Task<bool> ExistsByIdAsync(int id);
	}
}
