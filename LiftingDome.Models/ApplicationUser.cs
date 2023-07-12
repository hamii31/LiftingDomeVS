namespace LiftingDome.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.AddedWorkouts = new HashSet<Workout>();
        }
        public virtual ICollection<Workout> AddedWorkouts { get; set; }
    }
}
