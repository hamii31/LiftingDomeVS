namespace LiftingDome.Data.Configurations
{   
    using LiftingDome.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WorkoutCategoryEntityConfiguration : IEntityTypeConfiguration<WorkoutCategory>
    {
        public void Configure(EntityTypeBuilder<WorkoutCategory> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private WorkoutCategory[] GenerateCategories()
        {
            ICollection<WorkoutCategory> categories = new HashSet<WorkoutCategory>();

            WorkoutCategory category;

            category = new WorkoutCategory()
            {
                Id = 1,
                Name = "Powerlifting"
            };
            categories.Add(category);

            category = new WorkoutCategory()
            {
                Id = 2,
                Name = "Bodybuilding"
            };
            categories.Add(category);

            category = new WorkoutCategory()
            {
                Id = 3,
                Name = "CrossFit"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
