namespace LiftingDome.Services.Data.Interfaces
{
	using LiftingDome.Web.ViewModels.Admin;
	public interface IAdministratorService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
	}
}
