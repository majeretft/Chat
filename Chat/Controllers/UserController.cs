using System.Web.Mvc;

namespace Chat.Controllers
{
	public class UserController : Controller
	{
		public ViewResult LogIn()
		{
			return View();
		}
	}
}