namespace LiftingDome.Services.Tests.ServiceTests
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
            dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
                .UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
                .Options;

            liftingDomeDbContext = new LiftingDomeDbContext(dbOptions);

            liftingDomeDbContext.Database.EnsureCreated();
            SeedDatabase(liftingDomeDbContext);

            forumService = new ForumService(liftingDomeDbContext);
        }
        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueIfPostExists()
        {
            string existingPostId = Post.Id.ToString();

            bool result = await forumService.ExistsByIdAsync(existingPostId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseIfPostDoesntExist()
        {
            string deletedPostId = SoftDeletedPost.Id.ToString();

            bool result = await forumService.ExistsByIdAsync(deletedPostId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task IsUserOwnerOfPostWithIdAsyncShouldReturnTrueIfPostExists()
        {
            string existingPostId = Post.Id.ToString();
            string existingUserId = TraineeUser.Id.ToString();

            bool result = await forumService.IsUserOwnerOfPostWithIdAsync(existingUserId, existingPostId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task IsUserOwnerOfPostWithIdAsyncShouldReturnFalseIfPostDoesntExist()
        {
            string existingPostId = SoftDeletedPost.Id.ToString();
            string existingUserId = TraineeUser.Id.ToString();

            bool result = await forumService.IsUserOwnerOfPostWithIdAsync(existingUserId, existingPostId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task IsUSerOwnerOfPostWithIdAsyncShouldReturnFalseIfUserIsNotOwner()
        {
            string existingPostId = Post.Id.ToString();
            string existingUserId = CoachUser.Id.ToString();

            bool result = await forumService.IsUserOwnerOfPostWithIdAsync(existingUserId, existingPostId);

            Assert.IsFalse(result);
        }
    }
}
