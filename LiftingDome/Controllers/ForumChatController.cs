namespace LiftingDome.Controllers
{
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Services.Data.Models.ForumPost;
	using LiftingDome.Web.ViewModels.Forum;
	using Microsoft.AspNetCore.Mvc;

	public class ForumChatController : Controller
	{
		private readonly IForumChatService forumChatService;
		private readonly IForumCategoryService forumCategoryService;

		public ForumChatController(IForumChatService forumChatService, IForumCategoryService forumCategoryService)
		{
			this.forumChatService = forumChatService;
			this.forumCategoryService = forumCategoryService;
		}
		public async Task<IActionResult> All([FromQuery]AllForumPostQueryModel queryModel)
		{
			try
			{
				AllPostsFilteredAndPagedServiceModel serviceModel = await this.forumChatService.AllAsync(queryModel);
                queryModel.Posts = serviceModel.Posts;
                queryModel.TotalPosts = serviceModel.TotalPosts;
                queryModel.Categories = await this.forumCategoryService.AllCategoryNamesAsync();

                return View(queryModel);
            }
			catch (Exception)
			{
                return this.GeneralError();
            }
		}
        private IActionResult GeneralError()
        {
            this.ModelState.AddModelError(string.Empty, "An unexpected error occured! Please try again later! If the problem persists, please contact an administrator.");
            return RedirectToAction("Index", "Home");
        }
    }
}
