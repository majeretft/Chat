using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Chat.Logic
{
	[Authorize]
	public class ChatHub : Hub
	{
		private readonly List<User> _connections = new List<User>();

		public void Send(string message)
		{
			var name = Context.User.Identity.Name;

			Clients.All.addChatMessage(name, message);
		}

		public override Task OnConnected()
		{
			var name = Context.User.Identity.Name;

			_connections.Add(new User
			{
				Name = name,
				ConnectionId = Context.ConnectionId
			});

			return base.OnConnected();
		}

		public override Task OnDisconnected(bool stopCalled)
		{
			var user = _connections.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

			if (user == null)
				return base.OnDisconnected(stopCalled);

			_connections.Remove(user);

			return base.OnDisconnected(stopCalled);
		}
	}
}