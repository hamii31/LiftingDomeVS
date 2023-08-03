namespace LiftingDome.Web.ViewModels.WorkoutCategory
{
	using LiftingDome.Web.ViewModels.WorkoutCategory.Interfaces;
	public class WorkoutCategoryDetailsViewModel : IWorkoutCategoryDetailsModel
	{
		public int Id { get; set; } 
		public string Name { get; set; } = null!;
	}
}
