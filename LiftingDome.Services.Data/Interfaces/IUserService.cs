namespace LiftingDome.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<bool> UserHasWorkoutsByUserIdAsync(string userId);
		Task<string?> GetUserEmailByUserIdAsync(string userId);
		Task<bool> UserHasWorkoutsWithId(string userId, string workoutId);
		Task<bool> UserExistsByUserIdAsync(string userId);
		Task<bool> UserExistsByUserNameAsync(string userName);
		Task<string> GetFullNameByEmailAsync(string email);
		Task<int> TotalWorkoutsByUserIdAsync(string userId);
	}
}
