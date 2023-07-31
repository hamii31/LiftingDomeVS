namespace LiftingDome.Controllers
{
	using LiftingDome.Infrastructure.Extensions;
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Services.Data.Models.ForumPost;
	using LiftingDome.Web.ViewModels.Forum;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using NToastNotify;

	public class ForumChatController : Controller
	{
		private readonly IForumChatService forumChatService;
		private readonly IForumCategoryService forumCategoryService;
		private readonly ICoachService coachService;
		private readonly IToastNotification _toastNotification;

		public ForumChatController(IForumChatService forumChatService, IForumCategoryService forumCategoryService, ICoachService coachService, IToastNotification toastNotification)
		{
			this.forumChatService = forumChatService;
			this.forumCategoryService = forumCategoryService;
			this.coachService = coachService;
			_toastNotification = toastNotification;
		}
		[HttpGet]
		[AllowAnonymous]
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
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			bool isLoggedUser = await this.coachService.UserExistsByUserIdAsync(this.User.GetId()!);

			if (!isLoggedUser)
			{
				_toastNotification.AddErrorToastMessage("You must be a logged user in order to create a post!");
				return View("Index", "Home");
			}

			PostFormModel formModel;
			try
			{
				formModel = new PostFormModel()
				{
					Categories = await this.forumCategoryService.AllCategoriesAsync()
				};
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
			return View(formModel);
		}
		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			bool isLoggedUser = await this.coachService.UserExistsByUserIdAsync(this.User.GetId()!);

			if (!isLoggedUser)
			{
				_toastNotification.AddErrorToastMessage("You must be a logged user in order to create a post!");
				return View("Index", "Home");
			}

			bool categoryExists = await this.forumCategoryService.ExistsByIdAsync(model.CategoryId);

			if (!categoryExists)
			{
				this.ModelState.AddModelError(nameof(model.CategoryId), "The category does not exist!");
			}

			if (!this.ModelState.IsValid)
			{
				try
				{
					model.Categories = await this.forumCategoryService.AllCategoriesAsync();
				}
				catch (Exception)
				{
					return this.GeneralError();
				}
				return View(model);
			}

			try
			{
				await this.forumChatService.CreatePost(model, this.User.GetId()!);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "An unexpected error occured while adding your workout! Please try again later! If the problem persists, please contact an administrator.");
				model.Categories = await this.forumCategoryService.AllCategoriesAsync();
				return View(model);
			}
			_toastNotification.AddSuccessToastMessage("Post added successfully!");
			return RedirectToAction("All", "ForumChat");
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			List<AllForumPostViewModel> myPosts = new List<AllForumPostViewModel>();

            string userId = this.User.GetId()!;

            bool userExists = await this.coachService.UserExistsByUserIdAsync(userId);

			if (!userExists)
			{
				_toastNotification.AddErrorToastMessage("Only logged users can have posts!");
				return RedirectToAction("All", "Index");
			}

			try
			{
                myPosts.AddRange(await this.forumChatService.AllByUserIdAsync(userId!));

				return View(myPosts);
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
