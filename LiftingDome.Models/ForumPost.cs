namespace LiftingDome.Models
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.Post;

	public class ForumPost
	{
		public ForumPost()
		{
			this.Id = Guid.NewGuid();
		}
		[Key]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(TextMaxLength)]
		public string Text { get; set; } = null!;
		public DateTime CreatedOn { get; set; }
		public bool IsActive { get; set; }
		public int CategoryId { get; set; }  
		public virtual ForumCategory Category { get; set; } = null!;
		public Guid UserId { get; set; }
		public virtual ApplicationUser User { get; set; } = null!;
		public string? TaggedUser { get; set; }
		public bool HasBeenEdited { get; set; } = false;
	}
}
