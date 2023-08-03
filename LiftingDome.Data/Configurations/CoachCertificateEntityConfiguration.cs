namespace LiftingDome.Data.Configurations
{
	using LiftingDome.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class CoachCertificateEntityConfiguration : IEntityTypeConfiguration<CoachCertificate>
	{
		public void Configure(EntityTypeBuilder<CoachCertificate> builder)
		{
			builder.HasData(this.GenerateCertificates());
		}
		private CoachCertificate[] GenerateCertificates()
		{
			ICollection<CoachCertificate> certificates = new HashSet<CoachCertificate>();

			CoachCertificate certificate;

			certificate = new CoachCertificate()
			{
				Name = "ACSM"
			};
			certificates.Add(certificate);

			certificate = new CoachCertificate()
			{
				Name = "NSCA"
			};
			certificates.Add(certificate);

			certificate = new CoachCertificate()
			{
				Name = "NASM"
			};
			certificates.Add(certificate);

			certificate = new CoachCertificate()
			{
				Name = "ACE"
			};
			certificates.Add(certificate);

			certificate = new CoachCertificate()
			{
				Name = "ISSA"
			};
			certificates.Add(certificate);

			certificate = new CoachCertificate()
			{
				Name = "AFPA"
			};
			certificates.Add(certificate);

			certificate = new CoachCertificate()
			{
				Name = "NFPT"
			};
			certificates.Add(certificate);

			return certificates.ToArray();
		}
	}
}
