using System.Web.Mvc;
using System.Web.Routing;

namespace Chat
{
	public class RouteConfig
	{
		public static void Register(RouteCollection routes)
		{
			routes.MapRoute(null, "{controller}/{action}", new { controller = "Chat", action = "Index" });
		}
	}
}