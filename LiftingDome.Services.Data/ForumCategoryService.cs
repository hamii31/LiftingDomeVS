namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Web.ViewModels.ForumCategories;
    using LiftingDome.Web.ViewModels.WorkoutCategory;
    using Microsoft.EntityFrameworkCore;

    public class ForumCategoryService : IForumCategoryService
    {
        private readonly LiftingDomeDbContext liftingDomeDbContext;
        public ForumCategoryService(LiftingDomeDbContext liftingDomeDbContext)
        {
            this.liftingDomeDbContext = liftingDomeDbContext;
        }
        public async Task<IEnumerable<ForumCategorySelectFormModel>> AllCategoriesAsync()
        {
            IEnumerable<ForumCategorySelectFormModel> allCategories = await this.liftingDomeDbContext
                .PostCategories
                .AsNoTracking()
                .Select(c => new ForumCategorySelectFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.liftingDomeDbContext
                 .PostCategories
                 .Select(c => c.Name)
                 .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await this.liftingDomeDbContext
                .PostCategories
                .AnyAsync(c => c.Id == id);

            return result;
        }
    }
}
