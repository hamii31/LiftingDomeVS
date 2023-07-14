namespace LiftingDome.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Calculator;
	public class Calculator
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(NameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
