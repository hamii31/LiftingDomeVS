namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Services.Data.Models.Statistics;
    using LiftingDome.Services.Data.Models.Workout;

    using LiftingDome.Web.ViewModels.Home;
    using LiftingDome.Web.ViewModels.Workout;

    public interface IWorkoutService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeWorkoutsAsync();
        Task CreateAsync(WorkoutFormModel model, string coachId);
        Task<AllWorkoutsFilteredAndPagedServiceModel> AllAsync(AllWorkoutsQueryModel queryModel);
        Task<IEnumerable<AllWorkoutsViewModel>> AllByCoachIdAsync(string coachId);
        Task<IEnumerable<AllWorkoutsViewModel>> AllByTraineeIdAsync(string traineeId);
        Task<WorkoutDetailsViewModel> GetDetailsByIdAsync(string workoutId);
        Task<bool> ExistsByIdAsync(string workoutId);
        Task<WorkoutFormModel> GetWorkoutForEditByIdAsync(string workoutId);
        Task<bool> IsCoachOwnerOfWorkoutWithIdAsync(string coachId, string workoutId);
        Task EditWorkoutByIdAndFormModelAsync(string workoutId, WorkoutFormModel formModel);
        Task<WorkoutPreDeleteDetailsViewModel> GetWorkoutForDeleteByIdAsync(string workoutId);
        Task DeleteWorkoutByIdAsync(string workoutId);
        Task<bool> WorkoutIsOwnedByIdAsync(string workoutId, string userId);
        Task AddWorkoutToUserAsync(string workoutId, string userid);
        Task RemoveWorkoutByIdAsync(string workoutId);
        Task<StatisticsServiceModel> GetStatisticsAsync();
        Task<bool> IsWorkoutFree(string workoutId);
    }
}
