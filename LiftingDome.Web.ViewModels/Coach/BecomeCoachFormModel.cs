﻿namespace LiftingDome.Web.ViewModels.Coach
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Coach;

	public class BecomeCoachFormModel
	{
		[Required]
		[StringLength(NumberMaxLength, MinimumLength = NumberMinLength,
			ErrorMessage = "Phone number length is not correct!")]
		[Phone]
		[Display(Name = "Phone")]
		public string PhoneNumber { get; set; } = null!;
		public static string Email { get; set; } = null!;
	}
}
