namespace LiftingDome.Services.Data.Interfaces
{
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
        Task<bool> IsCoachOwnerOfWorkoutWithId(string coachId, string workoutId);
    }
}
