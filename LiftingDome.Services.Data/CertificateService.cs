namespace LiftingDome.Services.Data
{
	using LiftingDome.Data;
	using LiftingDome.Models;
	using LiftingDome.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System.Threading.Tasks;

	public class CertificateService : ICertificateService
	{
		private readonly LiftingDomeDbContext liftingDomeDbContext;
		public CertificateService(LiftingDomeDbContext liftingDomeDbContext)
		{
			this.liftingDomeDbContext = liftingDomeDbContext;
		}

        public async Task<string?> GetCertificateIdByCertificateNameAsync(string certificateName)
        {
            CoachCertificate? certificate = await this.liftingDomeDbContext
				.Certificates
				.FirstOrDefaultAsync(c => c.Name.ToUpper() == certificateName.ToUpper());

			if (certificate == null)
			{
				return null;
			}

			return certificate.Id.ToString();
        }

        public async Task<bool> IsCertificateNameValidAsync(string certificateName)
		{
			bool result = await this.liftingDomeDbContext
				.Certificates
				.AnyAsync(x => x.Name.ToLower() == certificateName.ToLower());

			return result;
		}
	}
}
