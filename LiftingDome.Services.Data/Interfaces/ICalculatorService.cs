namespace LiftingDome.Services.Data.Interfaces
{
	using LiftingDome.Web.ViewModels.Calculator;

	public interface ICalculatorService
	{
		Task<IEnumerable<MeassurmentSystemSelectFormModel>> GetAllMeassurmentSystemsAsync();
		Task<bool> ExistsByIdAsync(int id);
		Task<double> Calculate(OneRepMaxCalculatorFormModel model);
		Task<IList<double>> CalculatePercentages(OneRepMaxCalculatorFormModel model);
	}
}
