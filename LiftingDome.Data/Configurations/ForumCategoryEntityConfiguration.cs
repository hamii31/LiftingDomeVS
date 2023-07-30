namespace LiftingDome.Data.Configurations
{	
	using LiftingDome.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	public class ForumCategoryEntityConfiguration : IEntityTypeConfiguration<ForumCategory>
	{
		public void Configure(EntityTypeBuilder<ForumCategory> builder)
		{
			builder.HasData(this.GenerateCategories());
		}

		private ForumCategory[] GenerateCategories()
		{
			ICollection<ForumCategory> categories = new HashSet<ForumCategory>();

			ForumCategory category;

			category = new ForumCategory()
			{
				Id = 1,
				Name = "Powerlifting"
			};
			categories.Add(category);

			category = new ForumCategory()
			{
				Id = 2,
				Name = "Bodybuilding"
			};
			categories.Add(category);

			category = new ForumCategory()
			{
				Id = 3,
				Name = "CrossFit"
			};
			categories.Add(category);

			category = new ForumCategory()
			{
				Id = 4,
				Name = "General"
			};
			categories.Add(category);

			return categories.ToArray();
		}
	}
}
