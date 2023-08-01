﻿namespace LiftingDome.Services.Data
{
    using LiftingDome.Data;
    using LiftingDome.Models;
    using LiftingDome.Services.Data.Interfaces;
    using LiftingDome.Services.Data.Models.ForumPost;
    using LiftingDome.Web.ViewModels.Forum;
    using LiftingDome.Web.ViewModels.Forum.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using static LiftingDome.Common.EntityValidationConstants;

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
                .OrderBy(w => w.CreatedOn),

                ForumPostSorting.Oldest => postsQuery
                .OrderByDescending(w => w.CreatedOn)
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
                    CreatorName = p.User.Email.ToString(),
                    CategoryName = p.Category.Name
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
               .Where(w => w.IsActive && w.UserId.ToString() == userId)
               .Select(w => new AllForumPostViewModel
               {
                   Id = w.Id.ToString(),
                   Text = w.Text,
                   CreatorId = w.UserId.ToString(),
                   CreatorName = w.User.Email,
                   CategoryName = w.Category.Name
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
            await this.liftingDomeDbContext.Posts.AddAsync(post);
            await this.liftingDomeDbContext.SaveChangesAsync();
        }

        public async Task EditPostByIdAndFormModelAsync(string postId, PostFormModel formModel)
        {
            ForumPost workout = await this.liftingDomeDbContext
                .Posts
                .Where(w => w.IsActive)
                .FirstAsync(w => w.Id.ToString() == postId);

            workout.Text = formModel.Text;
            workout.CategoryId = formModel.CategoryId;

            await this.liftingDomeDbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string postId)
        {
             bool result = await this.liftingDomeDbContext
                .Posts
                .Where(w => w.IsActive)
                .AnyAsync(w => w.Id.ToString() == postId);
             
             return result;
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
                CategoryId = post.CategoryId
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
