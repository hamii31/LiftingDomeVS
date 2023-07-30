namespace LiftingDome.Models
{
	using System.ComponentModel.DataAnnotations;
	public class ForumCategory
	{
		public ForumCategory()
		{
			this.Posts = new HashSet<ForumPost>();
		}
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = null!;
		[Required]
		public virtual IEnumerable<ForumPost> Posts { get; set; }
	}
}
