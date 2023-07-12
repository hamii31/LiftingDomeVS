using LiftingDome.Web.ViewModels.Coach;

namespace LiftingDome.Services.Data.Interfaces
{
    public interface ICoachService
    {
        Task<bool> CoachExistsByUserIdAsync(string userId);
        Task<bool> CoachExistsByPhoneNumberAsync(string phoneNumber);
        Task<bool> UserHasWorkoutsByUserIdAsync(string userId);
        Task Create(string userId, BecomeCoachFormModel model);
    }
}
