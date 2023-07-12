namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Web.ViewModels.Home;
    using LiftingDome.Web.ViewModels.Workout;

    public interface IWorkoutService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeWorkoutsAsync();

        Task CreateAsync(AddWorkoutFormModel model, string coachId);
    }
}
