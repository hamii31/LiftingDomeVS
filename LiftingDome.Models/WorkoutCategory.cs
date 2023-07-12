namespace LiftingDome.Models
{
    using static LiftingDome.Common.EntityValidationConstants.WorkoutCategory;
    using System.ComponentModel.DataAnnotations;
    public class WorkoutCategory
    {
        public WorkoutCategory()
        {
            this.Workouts = new HashSet<Workout>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}