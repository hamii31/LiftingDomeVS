namespace LiftingDome.Data.Configurations
{
	using LiftingDome.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	public class ForumEntityConfiguration : IEntityTypeConfiguration<ForumPost>
	{
		public void Configure(EntityTypeBuilder<ForumPost> builder)
		{
			builder
				.Property(f => f.CreatedOn)
				.HasDefaultValueSql("GETDATE()");

			builder
			  .Property(f => f.IsActive)
			  .HasDefaultValue(true);

			builder
				.HasOne(f => f.Category)
				.WithMany(f => f.Posts)
				.HasForeignKey(f => f.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(f => f.User)
				.WithMany(f => f.Posts)
				.HasForeignKey(f =>f.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasData(this.GenerateWorkout());
		}
		private ForumPost[] GenerateWorkout()
		{
			ICollection<ForumPost> posts = new HashSet<ForumPost>();

			ForumPost post;

			post = new ForumPost()
			{
				Text = "Welcome to The Lifting Dome! The No.1 place for fitness and health! Feel free to browse through the published workouts and try some out, or become a coach yourself and create new workouts!",
				CategoryId = 4,
				UserId = Guid.Parse("D659B40A-2C01-417F-A452-19B194B2C081")
			};
			posts.Add(post);

			post = new ForumPost()
			{
				Text = "Hi! I don't understand how to do the 5/3/1 workout. Can a coach instruct me how to do it?",
				CategoryId = 1,
				UserId = Guid.Parse("199850BC-EA29-43B0-B342-A11A7FC6CC8C")
			};
			posts.Add(post);

			return posts.ToArray();
		}
	}
}
