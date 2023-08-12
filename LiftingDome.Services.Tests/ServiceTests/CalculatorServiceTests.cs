namespace LiftingDome.Services.Tests.ServiceTests
{	
	using LiftingDome.Data;
	using LiftingDome.Services.Data;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System.Security.Cryptography.X509Certificates;
	using static DatabaseSeeder;
	public class CalculatorServiceTests
	{
		private DbContextOptions<LiftingDomeDbContext> dbOptions;
		private LiftingDomeDbContext liftingDomeDbContext;
		private ICalculatorService calculatorService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
				.UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
				.Options;

			liftingDomeDbContext = new LiftingDomeDbContext(dbOptions);

			liftingDomeDbContext.Database.EnsureCreated();
			SeedDatabase(liftingDomeDbContext);

			this.calculatorService = new CalculatorService(this.liftingDomeDbContext);
		}
		[Test]
		public async Task ExistsByIdAsyncShouldReturnTrueIfMeassurmentIdExists()
		{
			int existingMeassurmentId = Meassurment.Id;

			bool result = await this.calculatorService.ExistsByIdAsync(existingMeassurmentId);

			Assert.IsTrue(result);
		}
		[Test]
		public async Task ExistsByIdAsyncShouldReturnFalseIfMeassurmentIdDoesntExist()
		{
			int existingMeassurmentId = Meassurment.Id - 1;

			bool result = await this.calculatorService.ExistsByIdAsync(existingMeassurmentId);

			Assert.IsFalse(result);
		}
	}
}
