using System.Web.Mvc;

namespace Chat.Controllers
{
	public class ChatController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public PartialViewResult Window()
		{
			return PartialView();
		}
	}
}