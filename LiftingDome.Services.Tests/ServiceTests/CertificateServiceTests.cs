namespace LiftingDome.Services.Tests.ServiceTests
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
            dbOptions = new DbContextOptionsBuilder<LiftingDomeDbContext>()
                .UseInMemoryDatabase("LiftingDomeInMemory" + Guid.NewGuid().ToString())
                .Options;

            liftingDomeDbContext = new LiftingDomeDbContext(dbOptions);

            liftingDomeDbContext.Database.EnsureCreated();
            SeedDatabase(liftingDomeDbContext);

            certificateService = new CertificateService(liftingDomeDbContext);
        }

        [Test]
        public async Task GetCertificateIdByCertificateNameAsyncShouldReturnCertificateIdIfExists()
        {
            string certificateName = Certificate.Name;

            string result = await certificateService.GetCertificateIdByCertificateNameAsync(certificateName);

            Assert.IsNotNull(result);
        }
        [Test]
        public async Task GetCertificateIdByCertificateNameAsyncShouldReturnNullIfCertificateDoesntExist()
        {
            string certificateName = "Not Certificate Name";

            string result = await certificateService.GetCertificateIdByCertificateNameAsync(certificateName);

            Assert.IsNull(result);
        }
        [Test]
        public async Task IsCertificateNameValidAsyncShouldReturnTrueIfCertificateIsValid()
        {
            string certificateName = Certificate.Name;

            bool result = await certificateService.IsCertificateNameValidAsync(certificateName);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsCertificateNameValidAsyncShouldReturnFalseIfCertificateDoesntExist()
        {
            string certificateName = "Not Certificate Name";

            bool result = await certificateService.IsCertificateNameValidAsync(certificateName);

            Assert.IsFalse(result);
        }
    }
}
