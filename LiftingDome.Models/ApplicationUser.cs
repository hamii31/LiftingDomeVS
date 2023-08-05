namespace LiftingDome.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.AddedWorkouts = new HashSet<Workout>();
            this.Posts = new HashSet<ForumPost>();
        }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
        public virtual ICollection<Workout> AddedWorkouts { get; set; }
        public virtual ICollection<ForumPost> Posts { get; set; }
    }
}
