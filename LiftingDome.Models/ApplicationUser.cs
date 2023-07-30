namespace LiftingDome.Models
{
    using Microsoft.AspNetCore.Identity;
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.AddedWorkouts = new HashSet<Workout>();
            this.Posts = new HashSet<ForumPost>();
        }
        public virtual ICollection<Workout> AddedWorkouts { get; set; }
        public virtual ICollection<ForumPost> Posts { get; set; }
    }
}
