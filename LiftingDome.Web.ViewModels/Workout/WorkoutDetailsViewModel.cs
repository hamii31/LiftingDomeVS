using LiftingDome.Web.ViewModels.Coach;

namespace LiftingDome.Web.ViewModels.Workout
{
    public class WorkoutDetailsViewModel : AllWorkoutsViewModel
    {
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public CoachInfoWorkoutViewModel Coach { get; set; } = null!;
    }
}
