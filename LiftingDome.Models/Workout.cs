namespace LiftingDome.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Workout;
    public class Workout
    {
        public Workout()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageURLMaxLength)]
        public string ImageURL { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public int WorkoutCategoryId { get; set; }

        public virtual WorkoutCategory Category { get; set; } = null!;

        public Guid CoachId { get; set; }
        public virtual Coach Coach { get; set; } = null!;
        public Guid? TraineeId { get; set; }
        public virtual ApplicationUser? Trainee { get; set; }
		public bool HasBeenEdited { get; set; } = false;
	}
}
