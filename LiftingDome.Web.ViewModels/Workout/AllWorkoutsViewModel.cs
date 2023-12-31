﻿namespace LiftingDome.Web.ViewModels.Workout
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
		public bool IsOwned { get; set; }
		public string CreatorName { get; set; } = null!;
		public string CategoryName { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public bool HasBeenEdited { get; set; } = false;
	}
}
