namespace LiftingDome.Services.Data
{
	using LiftingDome.Data;
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Web.ViewModels.Calculator;
	using Microsoft.EntityFrameworkCore;

	public class CalculatorService : ICalculatorService
	{
		private readonly LiftingDomeDbContext liftingDomeDbContext;
		public CalculatorService(LiftingDomeDbContext liftingDomeDbContext)
		{
			this.liftingDomeDbContext = liftingDomeDbContext;
		}

		public Task<double> Calculate(OneRepMaxCalculatorFormModel model)
		{
			//weight / ( 1.0278 – 0.0278 × reps )

			double oneRepMax = model.Weight / (1.0278 - 0.0278 * model.Reps);

			return Task.FromResult(oneRepMax);
		}

		public Task<IList<double>> CalculatePercentages(OneRepMaxCalculatorFormModel model)
		{
			IList<double> percentages = new List<double>();
			double max = model.OneRepMax;
			double percentage = 0.5;
			for (int i = 0; i < 7; i++)
			{
				percentages.Add(max * percentage);
				if (i < 3)
				{
					percentage += 0.1;
				}
				else
				{
					percentage += 0.05;
				}
			}
			return Task.FromResult(percentages);
		}

		public async Task<bool> ExistsByIdAsync(int id)
		{
			bool result = await this.liftingDomeDbContext
				.CalculatorMeassurments
				.AnyAsync(m => m.Id == id);

			return result;
		}

		public async Task<IEnumerable<MeassurmentSystemSelectFormModel>> GetAllMeassurmentSystemsAsync()
		{
			IEnumerable<MeassurmentSystemSelectFormModel> allMeassurmentSystems = await this.liftingDomeDbContext
				.CalculatorMeassurments
				.AsNoTracking()
				.Select(m => new MeassurmentSystemSelectFormModel
				{
					Id = m.Id,
					Name = m.Name
				})
				.ToArrayAsync();

			return allMeassurmentSystems;
		}
	}
}
