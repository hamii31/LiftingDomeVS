namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Services.Data.Models.ForumPost;
    using LiftingDome.Web.ViewModels.Forum;

    public interface IForumService
    {
        Task CreatePost(PostFormModel model, string userId);
        Task<AllPostsFilteredAndPagedServiceModel> AllAsync(AllForumPostQueryModel queryModel);
        Task<IEnumerable<AllForumPostViewModel>> AllByUserIdAsync(string traineeId);
        Task<bool> IsUserOwnerOfPostWithIdAsync(string userId, string postId);
        Task<PostFormModel> GetPostForEditAsync(string postId);
        Task<bool> ExistsByIdAsync(string postId);
        Task EditPostByIdAndFormModelAsync(string postId, PostFormModel formModel);
        Task<PostPreDeleteDetailsViewModel> GetPostForDeleteByIdAsync(string postId);
        Task DeletePostByIdAsync(string postId);
    }
}
