namespace LiftingDome.Models
{
	using System.ComponentModel.DataAnnotations;
	public class CoachCertificate
	{
		public CoachCertificate()
		{
			this.Id = Guid.NewGuid();
		}
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; } = null!;
	}
}
