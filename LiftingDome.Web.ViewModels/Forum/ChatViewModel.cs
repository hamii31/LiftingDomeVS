namespace LiftingDome.Web.ViewModels.Forum
{
	public class ChatViewModel
	{
		public ChatViewModel()
		{
			this.Posts = new HashSet<AllForumPostViewModel>();
		}
		public MessageFormModel CurrentPost { get; set; } = null!;
		public IEnumerable<AllForumPostViewModel> Posts { get; set; }
	}
}
