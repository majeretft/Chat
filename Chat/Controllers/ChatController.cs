using System.Web.Mvc;

namespace Chat.Controllers
{
	public class ChatController : Controller
	{
		[HttpGet, AllowAnonymous]
		public ActionResult Index()
		{
			return View();
		}
	}
}