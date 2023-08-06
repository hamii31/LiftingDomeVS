namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;
    using LiftingDome.Models;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Services.Data.Models.ForumPost;
    using LiftingDome.Web.ViewModels.Forum;
    using LiftingDome.Web.ViewModels.Forum.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ForumChatService : IForumChatService
    {
        private readonly LiftingDomeDbContext liftingDomeDbContext;
        public ForumChatService(LiftingDomeDbContext liftingDomeDbContext)
        {
            this.liftingDomeDbContext = liftingDomeDbContext;
        }
        
        public async Task<AllPostsFilteredAndPagedServiceModel> AllAsync(AllForumPostQueryModel queryModel)
        {
            IQueryable<ForumPost> postsQuery = this.liftingDomeDbContext
                .Posts
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                postsQuery = postsQuery
                    .Where(w => w.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                postsQuery = postsQuery
                    .Where(w => EF.Functions.Like(w.Text, wildCard) ||
                                EF.Functions.Like(w.User.Email, wildCard));
            }

            postsQuery = queryModel.PostSorting switch
            {
                ForumPostSorting.Newest => postsQuery
                .OrderByDescending(w => w.CreatedOn),

                ForumPostSorting.Oldest => postsQuery
                .OrderBy(w => w.CreatedOn)
            };
            IEnumerable<AllForumPostViewModel> allPosts = await postsQuery
                .Where(p => p.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.PostsPerPage)
                .Take(queryModel.PostsPerPage)
                .Select(p => new AllForumPostViewModel()
                {
                    Id = p.Id.ToString(),
                    Text = p.Text,
                    CreatorId = p.UserId.ToString(),
                    CreatorEmail = p.User.Email.ToString(),
                    CategoryName = p.Category.Name,
                    CreatedOn = p.CreatedOn,
                    TaggedUser = p.TaggedUser,
                    HasBeenEdited = p.HasBeenEdited

                }).ToArrayAsync();
                  
            int totalPosts = postsQuery.Count();
             
            return new AllPostsFilteredAndPagedServiceModel()
            {
                TotalPosts = totalPosts,
                Posts = allPosts
            };
        }

        public async Task<IEnumerable<AllForumPostViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<AllForumPostViewModel> allTraineePosts = await this.liftingDomeDbContext
               .Posts
               .Where(p => p.IsActive && p.UserId.ToString() == userId)
               .Select(p => new AllForumPostViewModel
               {
                   Id = p.Id.ToString(),
                   Text = p.Text,
                   CreatorId = p.UserId.ToString(),
                   CreatorEmail = p.User.Email,
                   CategoryName = p.Category.Name,
                   CreatedOn = p.CreatedOn,
                   TaggedUser = p.TaggedUser,
                   HasBeenEdited = p.HasBeenEdited
               })
               .ToArrayAsync();

            return allTraineePosts;
        }

        public async Task CreatePost(PostFormModel model, string userId)
        {
            ForumPost post = new ForumPost()
            {
                Text = model.Text,
                CategoryId = model.CategoryId,
                UserId = Guid.Parse(userId)
            };
            if (model.TaggedUser != null)
            {
                post.TaggedUser = model.TaggedUser;
            }
			await this.liftingDomeDbContext.Posts.AddAsync(post);
            await this.liftingDomeDbContext.SaveChangesAsync();
        }

		public async Task DeletePostByIdAsync(string postId)
		{
            ForumPost postToDelete = await this.liftingDomeDbContext
                .Posts
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == postId);

            postToDelete.IsActive = false;

            await this.liftingDomeDbContext.SaveChangesAsync();
		}

		public async Task EditPostByIdAndFormModelAsync(string postId, PostFormModel formModel)
        {
            ForumPost post = await this.liftingDomeDbContext
                .Posts
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == postId);

            post.Text = formModel.Text;
            post.CategoryId = formModel.CategoryId;
            post.CreatedOn = formModel.EditedOn;
            post.HasBeenEdited = true;

            if (formModel.TaggedUser != null)
            {
                post.TaggedUser = formModel.TaggedUser;
            }

            await this.liftingDomeDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string postId)
        {
             bool result = await this.liftingDomeDbContext
                .Posts
                .Where(p => p.IsActive)
                .AnyAsync(p => p.Id.ToString() == postId);
             
             return result;
        }

		public async Task<PostPreDeleteDetailsViewModel> GetPostForDeleteByIdAsync(string postId)
		{
			ForumPost post = await this.liftingDomeDbContext
                .Posts
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == postId);

            return new PostPreDeleteDetailsViewModel()
            {
                Text = post.Text
            };
		}

		public async Task<PostFormModel> GetPostForEditAsync(string postId)
        {
            ForumPost post = await this.liftingDomeDbContext
               .Posts
               .Include(w => w.Category)
               .Where(w => w.IsActive)
               .FirstAsync(w => w.Id.ToString() == postId);

            return new PostFormModel()
            {
                Text = post.Text,
                CategoryId = post.CategoryId,
                TaggedUser = post.TaggedUser
            };
        }

        public async Task<bool> IsUserOwnerOfPostWithIdAsync(string userId, string postId)
        {
            ForumPost post = await this.liftingDomeDbContext
                .Posts
                .Where(p => p.IsActive)
                .FirstAsync(p => p.Id.ToString() == postId);
            
            return post.UserId.ToString() == userId;
        }
    }
}
