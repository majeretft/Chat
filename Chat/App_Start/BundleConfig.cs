using System.Web.Optimization;

namespace Chat
{
	public class BundleConfig
	{
		public static void Register(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/css/bootstrap.css").Include("~/Content/bootstrap.css"));
			bundles.Add(new StyleBundle("~/css/chat.css").Include("~/Content/chat.css"));
		}
	}
}