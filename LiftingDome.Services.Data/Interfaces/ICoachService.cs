using LiftingDome.Web.ViewModels.Coach;

namespace LiftingDome.Services.Data.Interfaces
{
    public interface ICoachService
    {
        Task<bool> CoachExistsByUserIdAsync(string userId);
        Task<bool> CoachExistsByPhoneNumberAsync(string phoneNumber);
        Task Create(string userId, CoachFormModel model);
        Task<string?> GetCoachIdByUserIdAsync(string userId);
        Task<bool> HasWorkoutWithIdAsync(string userId, string workoutId);
        Task<string?> GetCoachNameByCoachId(string coachId);
        Task UpdateInfo(CoachFormModel model, string coachId);
    }
}
