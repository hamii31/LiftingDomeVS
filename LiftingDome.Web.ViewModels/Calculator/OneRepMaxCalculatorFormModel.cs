﻿namespace LiftingDome.Web.ViewModels.Calculator
{
	using System.ComponentModel.DataAnnotations;
	using static Common.GeneralApplicationConstants;
	public class OneRepMaxCalculatorFormModel
	{
		public OneRepMaxCalculatorFormModel()
		{
			this.MeassurmentId = DefaultMeassurmentIndex;
			this.Meassurments = new HashSet<MeassurmentSystemSelectFormModel>();
			this.OneRepMaxPercentages = new List<double>();	
		}
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
		[Display(Name = "Enter your weight")]
		public double Weight { get; set; }
		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
		[Display(Name = "Enter reps")]
		public int Reps { get; set; }
		public double OneRepMax { get; set; }

		[Display(Name = "Metric or Imperial System")]
		public int MeassurmentId { get; set; }
		public IEnumerable<MeassurmentSystemSelectFormModel> Meassurments { get; set; }
		public IList<double> OneRepMaxPercentages { get; set; }
	}
}
