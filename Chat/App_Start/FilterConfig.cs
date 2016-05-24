using System.Web.Mvc;

namespace Chat
{
	public class FilterConfig
	{
		public static void Register(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new AuthorizeAttribute());
		}
	}
}