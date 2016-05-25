using System;
using System.Web.Http;
using Chat.Models;

namespace Chat.Controllers
{
	public class UserApiController : ApiController
	{
		[HttpPost, AllowAnonymous]
		public void LogIn(LogInModel model)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public void LogOut()
		{
			throw new NotImplementedException();
		}

		[HttpPost, AllowAnonymous]
		public bool Register(RegisterModel model)
		{
			throw new NotImplementedException();
		}
	}
}
