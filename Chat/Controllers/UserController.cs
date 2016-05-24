using System.Web.Mvc;

namespace Chat.Controllers
{
	[AllowAnonymous]
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