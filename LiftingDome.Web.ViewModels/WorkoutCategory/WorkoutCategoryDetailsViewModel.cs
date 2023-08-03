namespace LiftingDome.Web.ViewModels.WorkoutCategory
{
	using LiftingDome.Web.ViewModels.WorkoutCategory.Interfaces;
	public class WorkoutCategoryDetailsViewModel : IWorkoutCategoryDetailsModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; } = null!;
	}
}
