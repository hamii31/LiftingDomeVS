namespace LiftingDome.Services.Data.Interfaces
{
	public interface ICertificateService
	{
		Task<bool> IsCertificateNameValid(string certificateName);
		Task<string?> GetCertificateIdByCertificateName(string certificateName);
	}
}
