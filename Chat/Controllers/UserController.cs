using System.Web.Mvc;

namespace Chat.Controllers
{
	public class UserController : Controller
	{
		public PartialViewResult LogIn()
		{
			return PartialView();
		}

		public PartialViewResult Register()
		{
			return PartialView();
		}
	}
}