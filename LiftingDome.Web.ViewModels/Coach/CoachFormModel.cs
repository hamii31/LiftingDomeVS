namespace LiftingDome.Web.ViewModels.Coach
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Coach;

	public class CoachFormModel
	{
		[Required]
		[StringLength(NumberMaxLength, MinimumLength = NumberMinLength,
			ErrorMessage = "Phone number length is not correct!")]
		[Phone]
		[Display(Name = "Phone")]
		public string PhoneNumber { get; set; } = null!;
		public static string Email { get; set; } = null!;
		[Required]
		public string Certification { get; set; } = null!;
		public string ImageURL { get; set; } = null!;
		[Display(Name = "First Name")]
		public string FirstName { get; set; } = null!;
		[Display(Name = "Last Name")]
		public string LastName { get; set; } = null!;
	}
}
