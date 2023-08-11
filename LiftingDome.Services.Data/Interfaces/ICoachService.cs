namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Web.ViewModels.Coach;
    public interface ICoachService
    {
        Task<bool> CoachExistsByUserIdAsync(string userId);
        Task<bool> CoachExistsByPhoneNumberAsync(string phoneNumber);
        Task<bool> CoachExistsByEmailAsync(string email);
        Task Create(string userId, CoachFormModel model);
        Task<string?> GetCoachIdByUserIdAsync(string userId);
        Task<bool> HasWorkoutWithIdAsync(string userId, string workoutId);
        Task<string> GetCoachNameByCoachIdAsync(string coachId);
        Task<string> GetCoachNameBYCoachEmailAsync(string coachEmail);
        Task UpdateInfo(CoachFormModel model, string coachId);
        Task<IEnumerable<AllCoachesViewModel>> GetAllCoachesAsync(); 
        Task<int> TotalWorkoutsByCoachEmailAsync(string email);
        Task<string> GetCoachPhoneNumberByCoachIdAsync(string coachId);
    }
}
