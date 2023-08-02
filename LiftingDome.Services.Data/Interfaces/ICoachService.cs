using LiftingDome.Web.ViewModels.Coach;

namespace LiftingDome.Services.Data.Interfaces
{
    public interface ICoachService
    {
        Task<bool> CoachExistsByUserIdAsync(string userId);
        Task<bool> CoachExistsByPhoneNumberAsync(string phoneNumber);
        Task Create(string userId, BecomeCoachFormModel model);
        Task<string?> GetCoachIdByUserIdAsync(string userId);
        Task<bool> HasWorkoutWithIdAsync(string userId, string workoutId);
    }
}
