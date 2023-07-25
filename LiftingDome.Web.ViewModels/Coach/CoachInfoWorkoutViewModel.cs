namespace LiftingDome.Web.ViewModels.Coach
{
    using System.ComponentModel.DataAnnotations;
    public class CoachInfoWorkoutViewModel
    {
        public string Email { get; set; } = null!;
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;
    }
}
