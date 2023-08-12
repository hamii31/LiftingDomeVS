namespace LiftingDome.Services.Tests.ServiceTests
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
            dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
                .UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
                .Options;

            liftingDomeDbContext = new LiftingDomeDbContext(dbOptions);

            liftingDomeDbContext.Database.EnsureCreated();
            SeedDatabase(liftingDomeDbContext);

            workoutService = new WorkoutService(liftingDomeDbContext);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueIfExists()
        {
            string existingWorkoutId = Workout.Id.ToString();

            bool result = await workoutService.ExistsByIdAsync(existingWorkoutId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseIfItsDeleted()
        {
            string existingWorkoutId = SoftDeletedWorkout.Id.ToString();

            bool result = await workoutService.ExistsByIdAsync(existingWorkoutId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task IsCoachOwnerOfWorkoutWithIdAsyncShouldReturnTrueIfIdIsOfOwner()
        {
            string existingCoachId = CoachUser.Id.ToString();
            string existingWorkoutId = Workout.Id.ToString();

            bool result = await workoutService.IsCoachOwnerOfWorkoutWithIdAsync(existingCoachId, existingWorkoutId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task IsCoachOwnerOfWorkoutWithIdAsyncShouldReturnFalseIfIdIsNotOfOwner()
        {
            string existingUserId = TraineeUser.Id.ToString();
            string exisitngWorkoutId = Workout.Id.ToString();

            bool result = await workoutService.IsCoachOwnerOfWorkoutWithIdAsync(existingUserId, exisitngWorkoutId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task WorkoutIsOwnedByIdAsyncShouldReturnTrueIfIdIsOfOwner()
        {
            string existingUserId = TraineeUser.Id.ToString();
            string existingWorkoutId = Workout.Id.ToString();

            bool result = await workoutService.WorkoutIsOwnedByIdAsync(existingWorkoutId, existingUserId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task WorkoutIsOwnedByIdAsyncShouldReturnFalseIfIdIsOfCoach()
        {
            string existingCoachId = CoachUser.Id.ToString();
            string existingWorkoutId = Workout.Id.ToString();

            bool result = await workoutService.WorkoutIsOwnedByIdAsync(existingWorkoutId, existingCoachId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task IsWorkoutFreeShouldReturnTrueIfWorkoutIsFree()
        {
            string existingWorkoutId = FreeWorkout.Id.ToString();

            bool result = await workoutService.IsWorkoutFree(existingWorkoutId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task IsWorkoutFreeShouldReturnFalseIfWorkoutIsNotFree()
        {
            string existingWorkoutId = Workout.Id.ToString();

            bool result = await workoutService.IsWorkoutFree(existingWorkoutId);

            Assert.IsFalse(result);
        }
    }
}
