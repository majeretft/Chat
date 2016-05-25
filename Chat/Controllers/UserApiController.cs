using System;
using System.Linq;
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
			var users = UsersData.Instance.Users;

			var user = users.FirstOrDefault(x => string.Equals(x.Name, model.Login, StringComparison.InvariantCultureIgnoreCase));

			return user != null && string.Equals(user.Password, model.Password, StringComparison.InvariantCultureIgnoreCase);
		}

		[HttpPost, Authorize]
		public void LogOut()
		{
			throw new NotImplementedException();
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
