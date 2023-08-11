namespace LiftingDome.Services.Data.Interfaces
{
	public interface ICertificateService
	{
		Task<bool> IsCertificateNameValidAsync(string certificateName);
		Task<string?> GetCertificateIdByCertificateNameAsync(string certificateName);
	}
}
