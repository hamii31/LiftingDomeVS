namespace LiftingDome.WebAPI.Controllers
{
	using LiftingDome.Services.Data.Interfaces;
	using LiftingDome.Services.Data.Models.Statistics;

	using Microsoft.AspNetCore.Mvc;

	[Route("api/statistics")]
	[ApiController]
	public class StatisticsApiController : ControllerBase
	{
		private readonly IWorkoutService workoutService;
		public StatisticsApiController(IWorkoutService workoutService)
		{
			this.workoutService = workoutService;
		}

		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(200,Type = typeof(StatisticsServiceModel))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetStatistics()
		{
			try
			{
				StatisticsServiceModel serviceModel = 
					await this.workoutService.GetStatisticsAsync();

				return this.Ok(serviceModel);
			}
			catch (Exception)
			{
				return this.BadRequest();
			}
		}
	}
}
