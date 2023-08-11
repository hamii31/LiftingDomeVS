namespace LiftingDome.Services.Tests
{
	using LiftingDome.Data;
	using LiftingDome.Services.Data;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;

	public class ForumServiceTests
	{
		private DbContextOptions<LiftingDomeDbContext> dbOptions;
		private LiftingDomeDbContext liftingDomeDbContext;
		private IForumService forumService;

		[OneTimeSetUp]
		public void OneTimeSetUp() 
		{
			this.dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
				.UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.liftingDomeDbContext = new LiftingDomeDbContext(this.dbOptions);

			this.liftingDomeDbContext.Database.EnsureCreated();
			SeedDatabase(this.liftingDomeDbContext);

			this.forumService = new ForumService(this.liftingDomeDbContext);
		}
		[Test]
		public async Task ExistsByIdAsyncShouldReturnTrueIfPostExists()
		{
			string existingPostId = Post.Id.ToString();

			bool result = await this.forumService.ExistsByIdAsync(existingPostId);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task ExistsByIdAsyncShouldReturnFalseIfPostDoesntExist()
		{
			string deletedPostId = DeletedPost.Id.ToString();

			bool result = await this.forumService.ExistsByIdAsync(deletedPostId);

			Assert.IsFalse(result);
		}
		[Test]
	    public async Task IsUserOwnerOfPostWithIdAsyncShouldReturnTrueIfPostExists()
		{
			string existingPostId = Post.Id.ToString();
			string existingUserId = TraineeUser.Id.ToString();

			bool result = await this.forumService.IsUserOwnerOfPostWithIdAsync(existingUserId, existingPostId);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsUserOwnerOfPostWithIdAsyncShouldReturnFalseIfPostDoesntExist()
		{
			string existingPostId = DeletedPost.Id.ToString();
			string existingUserId = TraineeUser.Id.ToString();

			bool result = await this.forumService.IsUserOwnerOfPostWithIdAsync(existingUserId, existingPostId);

			Assert.IsFalse(result);
		}
		[Test]
		public async Task IsUSerOwnerOfPostWithIdAsyncShouldReturnFalseIfUserIsNotOwner()
		{
			string existingPostId = Post.Id.ToString();
			string existingUserId = CoachUser.Id.ToString();

			bool result = await this.forumService.IsUserOwnerOfPostWithIdAsync(existingUserId, existingPostId);

			Assert.IsFalse(result);
		}
	}
}
