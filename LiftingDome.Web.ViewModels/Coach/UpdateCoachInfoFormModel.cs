namespace LiftingDome.Web.ViewModels.Coach
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Coach;
	public class UpdateCoachInfoFormModel
	{
		[StringLength(NumberMaxLength, MinimumLength = NumberMinLength,
			ErrorMessage = "Phone number length is not correct!")]
		public string? PhoneNumber { get; set; }
		public string? Certification { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
