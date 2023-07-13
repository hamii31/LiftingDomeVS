namespace LiftingDome.Web.ViewModels.Workout
{
	using LiftingDome.Web.ViewModels.WorkoutCategory;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Workout;

	public class AddWorkoutFormModel
	{
		public AddWorkoutFormModel()
		{
			this.Categories = new HashSet<WorkoutCategorySelectFormModel>();
		}

		[Required]
		[StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
		[Display(Name = "Workout Title")]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		[Display(Name = "Workout Details")]
		public string Description { get; set; } = null!;

		[Required]
		[StringLength(ImageURLMaxLength)]
		[Display(Name = "Image Link")]
		public string ImageUrl { get; set; } = null!;

		[Required]
		[Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
		[Display(Name = "Workout Price")]
		public decimal Price { get; set; }

		[Display(Name = "Category")] 
		public int CategoryId { get; set; }
		public IEnumerable<WorkoutCategorySelectFormModel> Categories { get; set; } 
	}
}
