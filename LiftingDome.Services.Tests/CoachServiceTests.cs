namespace LiftingDome.Services.Tests
{
	using LiftingDome.Data;
	using LiftingDome.Services.Data;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;

	public class CoachServiceTests
	{
		private DbContextOptions<LiftingDomeDbContext> dbOptions;
		private LiftingDomeDbContext liftingDomeDbContext;
		private ICoachService coachService;

		[OneTimeSetUp]
		public void OneTimeSetUp() 
		{
			this.dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
				.UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.liftingDomeDbContext = new LiftingDomeDbContext(this.dbOptions);

			this.liftingDomeDbContext.Database.EnsureCreated();
			SeedDatabase(this.liftingDomeDbContext);

			this.coachService = new CoachService(this.liftingDomeDbContext);
		}

		[Test]
		public async Task CoachExistsByUserIdAsyncShouldReturnTrueIfExists()
		{
			string existingCoachUserId = CoachUser.Id.ToString();

			bool result = await this.coachService.CoachExistsByUserIdAsync(existingCoachUserId);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task CoachExistsByUserIdAsyncShouldReturnFalseIfDoesntExist()
		{
			string existingTraineeUserId = TraineeUser.Id.ToString();

			bool result = await this.coachService.CoachExistsByUserIdAsync(existingTraineeUserId);

			Assert.IsFalse(result);
		}
	}
}