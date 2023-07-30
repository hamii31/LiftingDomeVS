namespace LiftingDome.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class ForumChatController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
