namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Services.Data.Models.ForumPost;
    using LiftingDome.Web.ViewModels.Forum;

    public interface IForumChatService
    {
        Task CreatePost(PostFormModel model, string userId);
        Task<AllPostsFilteredAndPagedServiceModel> AllAsync(AllForumPostQueryModel queryModel);
    }
}
