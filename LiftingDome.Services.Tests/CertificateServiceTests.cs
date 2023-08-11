namespace LiftingDome.Services.Tests
{
	using LiftingDome.Data;
	using LiftingDome.Services.Data;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using static DatabaseSeeder;
	public class CertificateServiceTests
	{
		private DbContextOptions<LiftingDomeDbContext> dbOptions;
		private LiftingDomeDbContext liftingDomeDbContext;
		private ICertificateService certificateService;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
				.UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
				.Options;

			this.liftingDomeDbContext = new LiftingDomeDbContext(this.dbOptions);

			this.liftingDomeDbContext.Database.EnsureCreated();
			SeedDatabase(this.liftingDomeDbContext);

			this.certificateService = new CertificateService(this.liftingDomeDbContext);
		}

		[Test]
		public async Task GetCertificateIdByCertificateNameAsyncShouldReturnCertificateIdIfExists()
		{
			string certificateName = Certificate.Name;

			string result = await this.certificateService.GetCertificateIdByCertificateNameAsync(certificateName);

			Assert.IsNotNull(result);
		}
	}
}
