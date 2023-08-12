namespace LiftingDome.Services.Tests.ServiceTests
{	
	using LiftingDome.Data;
	using LiftingDome.Services.Data;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;
	public class UserServiceTests
	{
		private DbContextOptions<LiftingDomeDbContext> dbOptions;
		private LiftingDomeDbContext liftingDomeDbContext;
		private IUserService userService;

		[OneTimeSetUp]
		public void OneTimeSetup() 
		{
			dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
			   .UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
			   .Options;

			liftingDomeDbContext = new LiftingDomeDbContext(dbOptions);

			liftingDomeDbContext.Database.EnsureCreated();
			SeedDatabase(liftingDomeDbContext);

			this.userService = new UserService(this.liftingDomeDbContext);
		}
		[Test]
		public async Task GetFullNameByEmailAsyncShouldReturnNameIfUserEmailExists()
		{
			string existingUserEmail = TraineeUser.Email;

			string result = await this.userService.GetFullNameByEmailAsync(existingUserEmail);

			Assert.IsNotEmpty(result);
		}
		[Test]
		public async Task GetFullNameByEmailAsyncShouldReturnEmptyIfUserEmailExists()
		{
			string nonExistingUserEmail = "idontexist@users.com";

			string result = await this.userService.GetFullNameByEmailAsync(nonExistingUserEmail);

			Assert.IsEmpty(result);
		}
		[Test]
		public async Task GetUserEmailByUserIdAsyncShouldReturnEmailIfUserIdExists()
		{
			string existingUserId = CoachUser.Id.ToString();

			string? result = await this.userService.GetUserEmailByUserIdAsync(existingUserId);

			Assert.IsNotNull(result);
		}
		[Test]
		public async Task GetUserEmailByUserIdAsyncShouldReturnNullIfUserIdDoesntExist()
		{
			string nonExistingUserId = "27a92d38-d51f-4d6d-b2df-cfcdbfa1e5ad";

			string? result = await this.userService.GetUserEmailByUserIdAsync(nonExistingUserId);

			Assert.IsNull(result);
		}
		[Test]
		public async Task TotalWorkoutsByUserIdAsyncShouldReturnCountIfUserIdExists()
		{
			string existingUserId = TraineeUser.Id.ToString();

			int result = await this.userService.TotalWorkoutsByUserIdAsync(existingUserId);

			Assert.That(result != 0);
		}
		[Test]
		public async Task TotalWorkoutsByUserIdAsyncShouldReturnZeroIfUserIsCoach()
		{
			string existignCoachId = CoachUser.Id.ToString();

			int result = await this.userService.TotalWorkoutsByUserIdAsync(existignCoachId);

			Assert.That(result == 0);
		}
		[Test]
		public async Task TotalWorkoutsByUserIdAsyncShouldReturnZeroIfUserDoesntExist()
		{
			string nonExistingUserId = "27a92d38-d51f-4d6d-b2df-cfcdbfa1e5ad";

			int result = await this.userService.TotalWorkoutsByUserIdAsync(nonExistingUserId);

			Assert.That(result == 0);
		}
		[Test]
		public async Task UserExistsByUserIdAsyncShouldReturnTrueIfUserExists()
		{
			string existingUserId = TraineeUser.Id.ToString();

			bool result = await this.userService.UserExistsByUserIdAsync(existingUserId);

			Assert.That(result, Is.True);
		}
		[Test]
		public async Task UserExistsByUserIdAsyncShouldReturnFalseIfUserDoesntExist()
		{
			string nonExistingUserId = "27a92d38-d51f-4d6d-b2df-cfcdbfa1e5ad";

			bool result = await this.userService.UserExistsByUserIdAsync(nonExistingUserId);

			Assert.That(result, Is.False);
		}
		[Test]
		public async Task UserExistsByUserNameAsyncShouldReturnTrueIfUserExists()
		{
			string existingUserUsername = CoachUser.UserName;

			bool result = await this.userService.UserExistsByUserNameAsync(existingUserUsername);

			Assert.That(result, Is.True);
		}
		[Test]
		public async Task UserExistsByUserNameAsyncShouldReturnFalseIfUserDoesntExist()
		{
			string nonExistingUserUsername = "NonExistingUser";

			bool result = await this.userService.UserExistsByUserNameAsync(nonExistingUserUsername);

			Assert.That(result, Is.False);
		}
		[Test]
		public async Task UserHasWorkoutsByUserIdAsyncShouldReturnTrueIfUserIsTrainee()
		{
			string existingUserId = TraineeUser.Id.ToString();

			bool result = await this.userService.UserHasWorkoutsByUserIdAsync(existingUserId);

			Assert.That(result, Is.True);
		}
		[Test]
		public async Task UserHasWorkoutsByUserIdAsyncShouldReturnFalseIfUserIsCoach()
		{
			string existingCoachId = CoachUser.Id.ToString();

			bool result = await this.userService.UserHasWorkoutsByUserIdAsync(existingCoachId);

			Assert.That(result, Is.False);
		}
		[Test]
		public async Task UserHasWorkoutsByUserIdAsyncShouldReturnFalseIfUserDoesntExist()
		{
			string nonExistingUserId = "27a92d38-d51f-4d6d-b2df-cfcdbfa1e5ad";

			bool result = await this.userService.UserHasWorkoutsByUserIdAsync(nonExistingUserId);

			Assert.That(result, Is.False);
		}
		[Test]
		public async Task UserHasWorkoutsWithIdAsyncdShouldReturnTrueIfUserIsTrainee()
		{
			string existingTraineeId = TraineeUser.Id.ToString();
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.userService.UserHasWorkoutsWithIdAsync(existingTraineeId, existingWorkoutId);

			Assert.That(result, Is.True);
		}
		[Test]
		public async Task UserHasWorkoutsWithIdAsyncShouldReturnFalseIfUserIsCoach()
		{
			string existingCoachId = CoachUser.Id.ToString();
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.userService.UserHasWorkoutsWithIdAsync(existingCoachId, existingWorkoutId);

			Assert.That(result, Is.False);
		}
		[Test]
		public async Task UserHasWorkoutsWithIdAsyncShouldReturnFalseIfUserDoesntExist()
		{
			string nonExistingUserId = "27a92d38-d51f-4d6d-b2df-cfcdbfa1e5ad";
			string existingWorkoutId = Workout.Id.ToString();

			bool result = await this.userService.UserHasWorkoutsWithIdAsync(nonExistingUserId, existingWorkoutId);

			Assert.That(result, Is.False);
		}
		[Test]
		public async Task UserHasWorkoutsWithIdAsyncShouldReturnFalseIfWorkoutDoesntExist()
		{
			string existingTraineeId = TraineeUser.Id.ToString();
			string nonExistingWorkoutId = SoftDeletedWorkout.Id.ToString();

			bool result = await this.userService.UserHasWorkoutsWithIdAsync(existingTraineeId, nonExistingWorkoutId);

			Assert.That(result, Is.False);
		}
	}
}
