namespace LiftingDome.Web.ViewModels.Coach
{
    public class AllCoachesViewModel
    {
        public string? ImageURL { get; set; } 
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CertificateName { get; set; } = null!;
        public int WorkoutCount { get; set; } 
    }
}
