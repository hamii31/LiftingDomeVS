namespace LiftingDome.Web.ViewModels.Workout
{
	using LiftingDome.Web.ViewModels.Workout.Enums;
	using System.ComponentModel.DataAnnotations;
	using static Common.GeneralApplicationConstants;
	public class AllWorkoutsQueryModel
	{
		public AllWorkoutsQueryModel()
		{
			this.CurrentPage = DefaultPageIndex;
			this.WorkoutPerPage = EntitiesPerPage;
			this.Categories = new HashSet<string>();
			this.Workouts = new HashSet<AllWorkoutsViewModel>();
		}
		public string? Category { get; set; }

		[Display(Name = "Search by keyword")]
		public string? SearchString { get; set; }

		[Display(Name = "Sort Workouts By")]
		public WorkoutSorting WorkoutSorting { get; set; }

		public int CurrentPage { get; set; }

		[Display(Name = "Workouts Per Page")]
		public int WorkoutPerPage { get; set; }

		public int TotalWorkouts { get; set; }

		public IEnumerable<string> Categories { get; set; } = null!;

		public IEnumerable<AllWorkoutsViewModel> Workouts { get; set; }
	}
}
