namespace LiftingDome.Services.Data.Models.ForumPost
{
    using LiftingDome.Web.ViewModels.Forum;
    public class AllPostsFilteredAndPagedServiceModel
    {
        public AllPostsFilteredAndPagedServiceModel()
        {
            this.Posts = new HashSet<AllForumPostViewModel>();
        }
        public int TotalPosts { get; set; }
        public IEnumerable<AllForumPostViewModel> Posts { get; set; }
    }
}
