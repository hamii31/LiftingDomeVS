namespace LiftingDome.Web.ViewModels.Forum
{
    public class AllForumPostViewModel
    {
        public string Id { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string CreatorId { get; set; } = null!;
        public string CreatorEmail { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public DateTime CreatedOn { get; set; } 
        public string? TaggedUser { get; set; }
        public bool HasBeenEdited { get; set; } = false;
    }
}
