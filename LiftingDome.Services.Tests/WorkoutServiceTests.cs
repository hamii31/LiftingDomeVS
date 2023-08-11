namespace LiftingDome.Services.Tests
{	
	using LiftingDome.Data;
	using LiftingDome.Services.Data;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;
	public class WorkoutServiceTests
	{
		private DbContextOptions<LiftingDomeDbContext> dbOptions;
		private LiftingDomeDbContext liftingDomeDbContext;
		private IWorkoutService workoutService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
				.UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.liftingDomeDbContext = new LiftingDomeDbContext(this.dbOptions);

			this.liftingDomeDbContext.Database.EnsureCreated();
			SeedDatabase(this.liftingDomeDbContext);

			this.workoutService = new WorkoutService(this.liftingDomeDbContext);
		}

		[Test]
		public async Task ExistsByIdAsyncShouldReturnTrueIfExists()
		{
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.workoutService.ExistsByIdAsync(existingWorkoutId);

			Assert.IsTrue(result);
		}

		[Test]
		public async Task ExistsByIdAsyncShouldReturnFalseIfItsDeleted()
		{
			string existingWorkoutId = SoftDeletedWorkout.Id.ToString();

			bool result = await this.workoutService.ExistsByIdAsync(existingWorkoutId);

			Assert.IsFalse(result);
		}
		[Test]
		public async Task IsCoachOwnerOfWorkoutWithIdAsyncShouldReturnTrueIfIdIsOfOwner()
		{
			string existingCoachId = CoachUser.Id.ToString();
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.workoutService.IsCoachOwnerOfWorkoutWithIdAsync(existingCoachId, existingWorkoutId);
			
			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsCoachOwnerOfWorkoutWithIdAsyncShouldReturnFalseIfIdIsNotOfOwner()
		{
			string existingUserId = TraineeUser.Id.ToString();
			string exisitngWorkoutId = Workout.Id.ToString();

			bool result = await this.workoutService.IsCoachOwnerOfWorkoutWithIdAsync(existingUserId, exisitngWorkoutId);

			Assert.IsFalse(result);
		}
		[Test]
		public async Task WorkoutIsOwnedByIdAsyncShouldReturnTrueIfIdIsOfOwner()
		{
			string existingUserId = TraineeUser.Id.ToString();
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.workoutService.WorkoutIsOwnedByIdAsync(existingWorkoutId, existingUserId);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task WorkoutIsOwnedByIdAsyncShouldReturnFalseIfIdIsOfCoach()
		{
			string existingCoachId = CoachUser.Id.ToString();
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.workoutService.WorkoutIsOwnedByIdAsync(existingWorkoutId, existingCoachId);

			Assert.IsFalse(result);
		}
		[Test]
		public async Task IsWorkoutFreeShouldReturnTrueIfWorkoutIsFree()
		{
			string existingWorkoutId = FreeWorkout.Id.ToString();

			bool result = await this.workoutService.IsWorkoutFree(existingWorkoutId);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task IsWorkoutFreeShouldReturnFalseIfWorkoutIsNotFree()
		{
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.workoutService.IsWorkoutFree(existingWorkoutId);

			Assert.IsFalse(result);
		}
	}
}
