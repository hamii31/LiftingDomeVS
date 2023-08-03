namespace LiftingDome.Infrastructure.Extensions
{
	using LiftingDome.Web.ViewModels.WorkoutCategory.Interfaces;
	public static class ViewModelsExtensions
	{
		public static string GetUrlInfo(this IWorkoutCategoryDetailsModel model)
		{
			return model.Name.Replace("-", " ");
		}
	}
}
