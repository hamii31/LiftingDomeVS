
namespace LiftingDome.Data.Configurations
{
	using LiftingDome.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(u => u.FirstName)
				.HasDefaultValue("Test");

			builder.Property(u => u.LastName)
				.HasDefaultValue("Testov");
		}
	}
}
