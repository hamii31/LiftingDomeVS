namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Web.ViewModels.ForumCategories;

    public interface IForumCategoryService
    {
        Task<IEnumerable<ForumCategorySelectFormModel>> AllCategoriesAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
