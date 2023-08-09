namespace LiftingDome.Areas.Admin.Services.Interfaces
{
	using LiftingDome.Web.ViewModels.User;

	public interface IAdministratorService
	{
		Task<IEnumerable<AllUsersViewModel>> GetAllUsersAsync();
		Task<int> TotalWorkoutsByUserIdAsync(string userId);
		Task<int> TotalWorkoutsByCoachEmailAsync(string email);
	}
}
