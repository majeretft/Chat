using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Chat.Logic;
using Chat.Models;

namespace Chat.Controllers
{
	public class UserApiController : ApiController
	{
		[HttpPost]
		public bool LogIn([FromBody] LogInModel model)
		{
			if (!ModelState.IsValid)
				return false;

			var users = UsersData.Instance.Users;

			var user = users.FirstOrDefault(x =>
				string.Equals(x.Name, model.Login, StringComparison.InvariantCultureIgnoreCase)
				&& string.Equals(x.Password, model.Password, StringComparison.InvariantCultureIgnoreCase));

			if (user == null)
				return false;

			var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Name) }, "ApplicationCookie");

			var ctx = Request.GetOwinContext();
			var authManager = ctx.Authentication;

			authManager.SignIn(identity);

			return true;
		}

		[HttpPost, Authorize]
		public void LogOut()
		{
			var ctx = Request.GetOwinContext();
			var authManager = ctx.Authentication;

			authManager.SignOut("ApplicationCookie");
		}

		[HttpPost]
		public bool Register([FromBody] RegisterModel model)
		{
			var users = UsersData.Instance.Users;

			if (users.Any(x => string.Equals(x.Name, model.Name, StringComparison.InvariantCultureIgnoreCase)))
				return false;

			users.Add(new User
			{
				Password = model.Password,
				Name = model.Name,
				Email = model.Email
			});

			return true;
		}
	}
}
