namespace LiftingDome.Data.Configurations
{
	using LiftingDome.Models;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	public class CalculatorMeassurmentSystemConfiguration : IEntityTypeConfiguration<Calculator>
	{
		public void Configure(EntityTypeBuilder<Calculator> builder)
		{
			builder.HasData(this.GenerateMeassurmentSystems());
		}
		private Calculator[] GenerateMeassurmentSystems()
		{
			ICollection<Calculator> meassurments = new HashSet<Calculator>();

			Calculator meassurment;

			meassurment = new Calculator
			{
				Id = 1,
				Name = "Metric"
			};
			meassurments.Add(meassurment);

			meassurment = new Calculator
			{
				Id = 2,
				Name = "Imperial"
			};
			meassurments.Add(meassurment);

			return meassurments.ToArray();
		}
	}
}
