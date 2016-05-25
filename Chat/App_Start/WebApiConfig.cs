using System.Web.Http;

namespace Chat
{
	public class WebApiConfig
	{
		public static void Register(HttpConfiguration configuration)
		{
			configuration.Routes.MapHttpRoute(null, "api/{controller}");
		}
	}
}