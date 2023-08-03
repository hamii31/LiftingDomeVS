namespace LiftingDome.Data
{
    using LiftingDome.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class LiftingDomeDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public LiftingDomeDbContext(DbContextOptions<LiftingDomeDbContext> options)
            : base(options)
        {

        }

        public DbSet<WorkoutCategory> WorkoutCategories { get; set; } = null!;
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<Coach> Coaches { get; set; } = null!;
        public DbSet<Calculator> CalculatorMeassurments { get; set; } = null!;
        public DbSet<ForumPost> Posts { get; set; } = null!;
        public DbSet<ForumCategory> PostCategories { get; set; } = null!;
        public DbSet<CoachCertificate> Certificates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(LiftingDomeDbContext)) ?? 
                                        Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}