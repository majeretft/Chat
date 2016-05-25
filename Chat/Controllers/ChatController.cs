using System.Web.Mvc;

namespace Chat.Controllers
{
	public class ChatController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
	}
}