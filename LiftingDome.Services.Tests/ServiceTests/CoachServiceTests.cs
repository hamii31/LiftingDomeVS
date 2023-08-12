namespace LiftingDome.Services.Tests.ServiceTests
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
            dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
                .UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
                .Options;

            liftingDomeDbContext = new LiftingDomeDbContext(dbOptions);

            liftingDomeDbContext.Database.EnsureCreated();
            SeedDatabase(liftingDomeDbContext);

            coachService = new CoachService(liftingDomeDbContext);
        }

        [Test]
        public async Task CoachExistsByUserIdAsyncShouldReturnTrueIfExists()
        {
            string existingCoachUserId = CoachUser.Id.ToString();

            bool result = await coachService.CoachExistsByUserIdAsync(existingCoachUserId);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task CoachExistsByUserIdAsyncShouldReturnFalseIfDoesntExist()
        {
            string existingTraineeUserId = TraineeUser.Id.ToString();

            bool result = await coachService.CoachExistsByUserIdAsync(existingTraineeUserId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task CoachExistsByEmailAsyncShouldReturnTrueIfExists()
        {
            string existingUserEmail = CoachUser.Email.ToString();

            bool result = await coachService.CoachExistsByEmailAsync(existingUserEmail);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task CoachExistsByEmailAsyncShouldReturnFalseIfNotExisting()
        {
            string existingUserEmail = TraineeUser.Email.ToString();

            bool result = await coachService.CoachExistsByEmailAsync(existingUserEmail);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task CoachExistsByPhoneNumberAsyncShouldReturnTrueIfExisting()
        {
            string existingCoachPhoneNumber = Coach.PhoneNumber.ToString();

            bool result = await coachService.CoachExistsByPhoneNumberAsync(existingCoachPhoneNumber);

            Assert.IsTrue(result);
        }
        [Test]
        public async Task GetCoachIdByUserIdAsyncShouldReturnCoachIdIfExists()
        {
            string existingCoachUserId = CoachUser.Id.ToString();

            string result = await coachService.GetCoachIdByUserIdAsync(existingCoachUserId);

            Assert.IsNotNull(result);
        }
        [Test]
        public async Task GetCoachIdByUserIdAsyncShouldReturnNullIfDoesntExist()
        {
            string existingUserId = TraineeUser.Id.ToString();

            string result = await coachService.GetCoachIdByUserIdAsync(existingUserId);

            Assert.IsNull(result);
        }
        [Test]
        public async Task GetCoachNameBYCoachEmailAsyncShouldReturnCoachNameIfExists()
        {
            string existingCoachEmail = CoachUser.Email.ToString();

            string result = await coachService.GetCoachNameBYCoachEmailAsync(existingCoachEmail);

            Assert.IsNotEmpty(result);
        }
        [Test]
        public async Task GetCoachNameBYCoachEmailAsyncShouldReturnEmptyStringIfDoesntExist()
        {
            string existingUserEmail = TraineeUser.Email.ToString();

            string result = await coachService.GetCoachNameBYCoachEmailAsync(existingUserEmail);

            Assert.IsEmpty(result);
        }
        [Test]
        public async Task GetCoachNameByCoachIdAsyncShouldReturnNameIfExists()
        {
            string existingCoachId = CoachUser.Id.ToString();

            string result = await coachService.GetCoachNameByCoachIdAsync(existingCoachId);

            Assert.IsNotEmpty(result);
        }
        [Test]
        public async Task GetCoachNameByCoachIdAsyncShouldReturnStringEmptyIfDoesntExist()
        {
            string existingUserId = TraineeUser.Id.ToString();

            string result = await coachService.GetCoachNameByCoachIdAsync(existingUserId);

            Assert.IsEmpty(result);
        }
        [Test]
        public async Task GetCoachPhoneNumberByCoachIdAsyncShouldReturnPhoneNumberIfExists()
        {
            string existingCoachId = CoachUser.Id.ToString();

            string result = await coachService.GetCoachPhoneNumberByCoachIdAsync(existingCoachId);

            Assert.IsNotEmpty(result);
        }
        [Test]
        public async Task GetCoachPhoneNumberByCoachIdAsyncShouldReturnSameCoachPhoneNumber()
        {
            string existingCoachId = CoachUser.Id.ToString();

            string result = await coachService.GetCoachPhoneNumberByCoachIdAsync(existingCoachId);

            Assert.That(CoachUser.PhoneNumber.ToString(), Is.EqualTo(result));
        }
        [Test]
        public async Task GetCoachPhoneNumberByCoachIdAsyncShouldReturnEmptyStringIfDoesntExist()
        {
            string existingUserId = TraineeUser.Id.ToString();

            string result = await coachService.GetCoachPhoneNumberByCoachIdAsync(existingUserId);

            Assert.IsEmpty(result);
        }
        [Test]
        public async Task TotalWorkoutsByCoachEmailAsyncShouldReturnZeroIfIdIsNotOfACoach()
        {
            string existingUserId = TraineeUser.Id.ToString();

            int result = await coachService.TotalWorkoutsByCoachEmailAsync(existingUserId);

            Assert.That(result, Is.Zero);
        }
    }
}