namespace LiftingDome.Web.ViewModels.Forum
{
    using LiftingDome.Web.ViewModels.Forum.Enums;
    using System.ComponentModel.DataAnnotations;
    using static Common.GeneralApplicationConstants;
    public class AllForumPostQueryModel
    {
        public AllForumPostQueryModel()
        {
            this.CurrentPage = DefaultPageIndex;
            this.PostsPerPage = EntitiesPerPage;
            this.Categories = new HashSet<string>();
            this.Posts = new HashSet<AllForumPostViewModel>();
        }
        public string? Category { get; set; }

        [Display(Name = "Search by keyword")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Posts By")]
        public ForumPostSorting PostSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Posts Per Page")]
        public int PostsPerPage { get; set; }

        public int TotalPosts { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;
        public IEnumerable<AllForumPostViewModel> Posts { get; set; }
    }
}
