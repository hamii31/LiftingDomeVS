﻿namespace LiftingDome.Controllers
{
	using LiftingDome.Infrastructure.Extensions;
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Services.Data.Models.ForumPost;
	using LiftingDome.Web.ViewModels.Forum;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using NToastNotify;

	public class ForumController : Controller
	{
		private readonly IForumService forumChatService;
		private readonly IForumCategoryService forumCategoryService;
		private readonly ICoachService coachService;
		private readonly IUserService userSerivce;
		private readonly IToastNotification _toastNotification;

		public ForumController(IForumService forumChatService, IForumCategoryService forumCategoryService, ICoachService coachService, IUserService userService, IToastNotification toastNotification)
		{
			this.forumChatService = forumChatService;
			this.forumCategoryService = forumCategoryService;
			this.coachService = coachService;
			this.userSerivce = userService;
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
			bool isLoggedUser = await this.userSerivce.UserExistsByUserIdAsync(this.User.GetId()!);

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
					Categories = await this.forumCategoryService.AllCategoriesAsync(),
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
			bool isLoggedUser = await this.userSerivce.UserExistsByUserIdAsync(this.User.GetId()!);

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

			if (model.TaggedUser != null)
			{
				bool taggedUserExists = await this.userSerivce.UserExistsByUserNameAsync(model.TaggedUser);

				if (!taggedUserExists)
				{
					_toastNotification.AddErrorToastMessage("Tagged user does not exist!");
					return View(model);
				}
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
			return RedirectToAction("All", "Forum");
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			List<AllForumPostViewModel> myPosts = new List<AllForumPostViewModel>();

            string userId = this.User.GetId()!;

            bool userExists = await this.userSerivce.UserExistsByUserIdAsync(userId);

			if (!userExists)
			{
				_toastNotification.AddErrorToastMessage("Log in in order to have posts!");
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

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
            bool isLogged = await this.userSerivce.UserExistsByUserIdAsync(this.User.GetId()!);
            if (!isLogged)
            {
                _toastNotification.AddErrorToastMessage("You must be a logged user in order to edit posts!");
                return RedirectToAction("Index", "Home");
            }

            bool postExists = await this.forumChatService.ExistsByIdAsync(id);
            if (!postExists)
            {
                _toastNotification.AddErrorToastMessage("Post with the provided Id does not exist!");
                return RedirectToAction("All", "Forum");
            }

			bool IsUserOwner = await this.forumChatService.IsUserOwnerOfPostWithIdAsync(this.User.GetId()!, id);
			if (!IsUserOwner && !this.User.IsAdmin())
			{
				_toastNotification.AddErrorToastMessage("You must be the owner of the post in order to edit it!");
				return RedirectToAction("Mine", "Forum");
			}

            try
            {
                PostFormModel formModel = await this.forumChatService
                .GetPostForEditAsync(id);

                formModel.Categories = await this.forumCategoryService.AllCategoriesAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return this.GeneralError();
            }
        }
		[HttpPost]
		public async Task<IActionResult> Edit(string id, PostFormModel model)
		{
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.forumCategoryService.AllCategoriesAsync();
                return View(model);
            }

            bool isLogged = await this.userSerivce.UserExistsByUserIdAsync(this.User.GetId()!);
            if (!isLogged)
            {
                _toastNotification.AddErrorToastMessage("You must be a logged user in order to edit posts!");
                return RedirectToAction("Index", "Home");
            }

            bool postExists = await this.forumChatService.ExistsByIdAsync(id);
            if (!postExists)
            {
                _toastNotification.AddErrorToastMessage("Post with the provided Id does not exist!");
                return RedirectToAction("All", "Forum");
            }

            bool IsUserOwner = await this.forumChatService.IsUserOwnerOfPostWithIdAsync(this.User.GetId()!, id);
            if (!IsUserOwner && !this.User.IsAdmin())
            {
                _toastNotification.AddErrorToastMessage("You must be the owner of the post in order to edit it!");
                return RedirectToAction("Mine", "Forum");
            }

			if (model.TaggedUser != null)
			{
				bool taggedUserExists = await this.userSerivce.UserExistsByUserNameAsync(model.TaggedUser);

				if (!taggedUserExists)
				{
					_toastNotification.AddErrorToastMessage("Tagged user does not exist!");
					model.Categories = await this.forumCategoryService.AllCategoriesAsync();
					return View(model);
				}
			}

			try
            {
                await this.forumChatService.EditPostByIdAndFormModelAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while saving the changes to your post. Please try again later or contact administrator");
                model.Categories = await this.forumCategoryService.AllCategoriesAsync();
                return View(model);
            }
            _toastNotification.AddSuccessToastMessage("Post changes saved successfully!");
            return RedirectToAction("Mine", "Forum");
        }
		[HttpGet]
		public async Task<IActionResult> Delete(string id)
		{
			string userId = this.User.GetId()!;

			bool isLoggedUser = await this.userSerivce.UserExistsByUserIdAsync(userId);

			if (!isLoggedUser && !this.User.IsAdmin())
			{
				_toastNotification.AddErrorToastMessage("You must be a logged user in order to delete posts!");
				return RedirectToAction("All", "Index");
			}

			bool postExists = await this.forumChatService.ExistsByIdAsync(id);

			if (!postExists)
			{
				_toastNotification.AddErrorToastMessage("Post with the provided Id does not exist!");
				return RedirectToAction("All", "Forum");
			}

			bool userIsOwner = await this.forumChatService.IsUserOwnerOfPostWithIdAsync(userId, id);

			if (!userIsOwner && !this.User.IsAdmin())
			{
				_toastNotification.AddErrorToastMessage("You must be the owner of the post in order to delete it!");
				return RedirectToAction("Mine", "Forum");
			}

			try
			{
				PostPreDeleteDetailsViewModel formModel = await this.forumChatService.GetPostForDeleteByIdAsync(id);
				return View(formModel);
			}
			catch (Exception)
			{
				return this.GeneralError();
			}
		}
		[HttpPost]
		public async Task<IActionResult> Delete(string id, PostPreDeleteDetailsViewModel model)
		{
			string userId = this.User.GetId()!;

			bool isLoggedUser = await this.userSerivce.UserExistsByUserIdAsync(userId);

			if (!isLoggedUser && !this.User.IsAdmin())
			{
				_toastNotification.AddErrorToastMessage("You must be a logged user in order to delete posts!");
				return RedirectToAction("All", "Index");
			}

			bool postExists = await this.forumChatService.ExistsByIdAsync(id);

			if (!postExists)
			{
				_toastNotification.AddErrorToastMessage("Post with the provided Id does not exist!");
				return RedirectToAction("All", "Forum");
			}

			bool userIsOwner = await this.forumChatService.IsUserOwnerOfPostWithIdAsync(userId, id);

			if (!userIsOwner && !this.User.IsAdmin())
			{
				_toastNotification.AddErrorToastMessage("You must be the owner of the post in order to delete it!");
				return RedirectToAction("Mine", "Forum");
			}
			try
			{
				await this.forumChatService.DeletePostByIdAsync(id);
				_toastNotification.AddWarningToastMessage("Post successfully deleted!");
				return RedirectToAction("Mine", "Forum");
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
