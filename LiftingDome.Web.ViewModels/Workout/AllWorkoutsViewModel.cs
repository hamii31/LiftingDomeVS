namespace LiftingDome.Web.ViewModels.Workout
{
	using System.ComponentModel.DataAnnotations;

	public class AllWorkoutsViewModel
	{
		public string Id { get; set; } = null!;
		public string Title { get; set; } = null!;

		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

		[Display(Name = "Workout Price")]
		public decimal Price { get; set; }
	}
}
