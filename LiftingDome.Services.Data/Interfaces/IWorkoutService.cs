namespace LiftingDome.Services.Data.Interfaces
{
    using LiftingDome.Web.ViewModels.Home;

    public interface IWorkoutService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeWorkoutsAsync();
    }
}
