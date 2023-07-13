﻿namespace LiftingDome.Infrastructure.ModelBinders
{
	using Microsoft.AspNetCore.Mvc.ModelBinding;
	using System.Globalization;

	public class DecimalModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext? bindingContext)
		{
			if (bindingContext == null)
			{
				throw new ArgumentNullException(nameof(bindingContext));
			}

			ValueProviderResult valueResult = bindingContext
				.ValueProvider
				.GetValue(bindingContext.ModelName);
			if (valueResult != ValueProviderResult.None && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
			{
				decimal parsedValue = 0m;
				bool binderSucceeded = false;

				try
				{
					string formDecimalValue = valueResult.FirstValue;
					formDecimalValue = formDecimalValue.Replace(",",
						CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					formDecimalValue = formDecimalValue.Replace(".",
						CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					parsedValue = Convert.ToDecimal(formDecimalValue);
					binderSucceeded = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}
				if (binderSucceeded)
				{
					bindingContext.Result = ModelBindingResult.Success(parsedValue);
				}
			}

			return Task.CompletedTask;
		}
	}
}
