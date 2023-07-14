namespace LiftingDome.Web.ViewModels.Calculator
{
	using System.ComponentModel.DataAnnotations;
	using static Common.GeneralApplicationConstants;
	public class OneRepMaxCalculatorFormModel
	{
		public OneRepMaxCalculatorFormModel()
		{
			this.MeassurmentId = DefaultMeassurmentIndex;
			this.Meassurments = new HashSet<MeassurmentSystemSelectFormModel>();
		}
		[Required]
		[Display(Name = "Enter your weight")]
		public double Weight { get; set; }
		[Required]
		[Display]
		public int Reps { get; set; }
		public double OneRepMax { get; set; }

		[Display(Name = "Metric or Imperial System")]
		public int MeassurmentId { get; set; }
		public IEnumerable<MeassurmentSystemSelectFormModel> Meassurments { get; set; }
	}
}
