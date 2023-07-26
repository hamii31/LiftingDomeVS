namespace LiftingDome.Web.ViewModels.Workout
{
	using System.ComponentModel.DataAnnotations;
	public class WorkoutPreDeleteDetailsViewModel
	{
		public string Title { get; set; } = null!;
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

	}
}
