﻿namespace LiftingDome.Controllers
{
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Web.ViewModels.Calculator;
	using Microsoft.AspNetCore.Mvc;
	using NToastNotify;

	public class CalculatorController : Controller
	{
		private readonly ICalculatorService calculatorService;
        private readonly IToastNotification _toastNotification;
        public CalculatorController(ICalculatorService calculatorService, IToastNotification toastNotification)
		{
			this.calculatorService = calculatorService;
			this._toastNotification = toastNotification;
		}
		public IActionResult Result(OneRepMaxCalculatorFormModel model)
		{
			return View(model.OneRepMax);
		}

		[HttpGet]
		public async Task<IActionResult> Calculate()
		{
			OneRepMaxCalculatorFormModel formModel;

			try
			{
				formModel = new OneRepMaxCalculatorFormModel()
				{
					Meassurments = await this.calculatorService.GetAllMeassurmentSystemsAsync()
				};
			}
			catch (Exception)
			{
				return this.GeneralError();
			}

			return View(formModel);
		}
		[HttpPost]
		public async Task<IActionResult> Calculate(OneRepMaxCalculatorFormModel model)
		{
			bool MeassurmentSystemExists = await this.calculatorService.ExistsByIdAsync(model.MeassurmentId);

			if (!MeassurmentSystemExists)
			{
				_toastNotification.AddErrorToastMessage("This meassurment system does not figure in the database!");
				return View(model);
			}

			if (!this.ModelState.IsValid)
			{
                try
				{
					model.Meassurments = await this.calculatorService.GetAllMeassurmentSystemsAsync();
				}
				catch (Exception)
				{
					return this.GeneralError();
				}
                return View(model);
			}

			try
			{
				model.OneRepMax = await this.calculatorService.Calculate(model);
				model.OneRepMaxPercentages = await this.calculatorService.CalculatePercentages(model);
			}
			catch (Exception)
			{
				this.ModelState.AddModelError(string.Empty, "An unexpected error occured while calculating your one rep max! Please try again later! If the problem persists, please contact an administrator.");
				model.Meassurments = await this.calculatorService.GetAllMeassurmentSystemsAsync();
				return View(model);
			}
			return View(model);
		}
		private IActionResult GeneralError()
		{
			this.ModelState.AddModelError(string.Empty, "An unexpected error occured! Please try again later! If the problem persists, please contact an administrator.");
			return RedirectToAction("Index", "Home");
		}
	}
}
