namespace LiftingDome.Web.ViewModels.Forum
{
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.ForumPost;

	public class MessageViewModel
	{
		[Required]
		public string Sender { get; set; } = null!;

		[Required]
		[MaxLength(MessageMaxLength)]
		public string MessageText { get; set; } = null!;
	}
}
