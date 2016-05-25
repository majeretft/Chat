using System.Web.Mvc;

namespace Chat.Controllers
{
	public class ChatController : Controller
	{
		[AllowAnonymous]
		public ActionResult Index()
		{
			return View();
		}
	}
}