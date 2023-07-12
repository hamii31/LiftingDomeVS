namespace LiftingDome.Models
{
    using static Common.EntityValidationConstants.Coach;
    using System.ComponentModel.DataAnnotations;
    public class Coach
    {
        public Coach()
        {
            this.Id = Guid.NewGuid();
            this.CreatedWorkouts = new HashSet<Workout>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Workout> CreatedWorkouts { get; set; }
    }
}
