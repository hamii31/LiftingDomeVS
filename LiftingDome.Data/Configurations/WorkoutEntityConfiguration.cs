namespace LiftingDome.Data.Configurations
{   
    using LiftingDome.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WorkoutEntityConfiguration : IEntityTypeConfiguration<Workout>
    {
        public void Configure(EntityTypeBuilder<Workout> builder)
        {
            builder
                .Property(w => w.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(w => w.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(n => n.Category)
                .WithMany(n => n.Workouts)
                .HasForeignKey(n => n.WorkoutCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(n => n.Coach)
                .WithMany(n => n.CreatedWorkouts)
                .HasForeignKey(n => n.CoachId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateWorkout());
        }

        private Workout[] GenerateWorkout()
        {
            ICollection<Workout> workouts = new HashSet<Workout>();

            Workout workout;

            workout = new Workout()
            {
                Title = "The 5X5 Method for size and strength",
                Description = "Probably the best way to build strength and size simultaneously. Either use 70-85% of your 1RM for all 5 sets or gradually warm up to a heavy top set of five.",
                ImageURL = "https://global.discourse-cdn.com/tnation/original/4X/3/0/8/30832fc6dfb5cb54e95c9323e45720c3f7476d87.jpeg",
                Price = 0,
                WorkoutCategoryId = 2,
                CoachId = Guid.Parse("09CD637A-3447-4F2F-BBF0-5BA9CB561209"), //CoachId
                TraineeId = Guid.Parse("BADF1763-A2F6-4844-3189-08DB7FB398C0") //TraineeId
            };
            workouts.Add(workout);

            workout = new Workout()
            {
                Title = "3X3 at 90% for pure strength",
                Description = "The best way for beginner and intermediate strength athletes to build strength.",
                ImageURL = "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2013/08/Best-Set-and-Rep-Scheme-for-Your-Goal.jpg",
                Price = 0,
                WorkoutCategoryId = 1,
                CoachId = Guid.Parse("09CD637A-3447-4F2F-BBF0-5BA9CB561209"),
                TraineeId = Guid.Parse("BADF1763-A2F6-4844-3189-08DB7FB398C0")
            };
            workouts.Add(workout);

            workout = new Workout()
            {
                Title = "The 4x8 rep scheme for unmatched muscle mass!",
                Description = "Boring, bland, but effective! The straight-forward 4x8 is another training protocol that bodybuilders have relied on for over 40 years. If it’s stuck around for that long, there’s good reason. It’s not flashy, but the basics never let you down. Doing 4 sets of 8, with each set getting you close to failure, is a decent way to stimulate growth, especially for beginners.",
                ImageURL = "https://global.discourse-cdn.com/tnation/original/4X/4/e/c/4ec55b74a7a3a0795248ead7c9b155df540ee97f.jpeg",
                Price = 0,
                WorkoutCategoryId = 2,
                CoachId = Guid.Parse("09CD637A-3447-4F2F-BBF0-5BA9CB561209"),
                TraineeId = Guid.Parse("BADF1763-A2F6-4844-3189-08DB7FB398C0")
            };
            workouts.Add(workout);

            workout = new Workout()
            {
                Title = "CrossFit for Meatheads",
                Description = "Easiest way for strong people to do Metcon workouts without losing all of their strength gains is doing Zercher Cycles with heavy weight for a period of time. Deadlift the barbell off the ground, squat down and place it on your legs. Grab it in a zercher position and stand up. Squat down, place the barbell on your legs again, grab it with your hands and stand up. Lower the barbell down to the ground. That's one rep. Do 15-20 with some good weight on the barbell.",
                ImageURL = "https://d3h9ln6psucegz.cloudfront.net/wp-content/uploads/2017/09/CrossFit-for-Meatheads.jpg",
                Price = 20,
                WorkoutCategoryId = 3,
                CoachId = Guid.Parse("09CD637A-3447-4F2F-BBF0-5BA9CB561209"),
                TraineeId = Guid.Parse("BADF1763-A2F6-4844-3189-08DB7FB398C0")
            };
            workouts.Add(workout);

            return workouts.ToArray();
        }
    }
}
