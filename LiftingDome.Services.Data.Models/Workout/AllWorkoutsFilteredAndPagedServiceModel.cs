namespace LiftingDome.Services.Data.Models.Workout
{
	using LiftingDome.Web.ViewModels.Workout;
	public class AllWorkoutsFilteredAndPagedServiceModel
	{
		public AllWorkoutsFilteredAndPagedServiceModel()
		{
			this.Workouts = new HashSet<AllWorkoutsViewModel>();
		}
		public int TotalWorkoutsCount { get; set; }
		public IEnumerable<AllWorkoutsViewModel> Workouts { get; set; }
	}
}
