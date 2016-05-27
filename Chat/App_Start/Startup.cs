using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Chat.Startup))]

namespace Chat
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = "ApplicationCookie",
				LoginPath = new PathString("/Chat/Index")
			});
		}
	}
}
