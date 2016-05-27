using System.Web.Optimization;

namespace Chat
{
	public class BundleConfig
	{
		public static void Register(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/css/bootstrap.css").Include("~/Content/bootstrap.css"));
			bundles.Add(new StyleBundle("~/css/chat.css").Include("~/Content/chat.css"));

			bundles.Add(new ScriptBundle("~/js/jquery.js").Include("~/Scripts/jquery-{version}.js"));
			bundles.Add(new ScriptBundle("~/js/bootstrap.js").Include("~/Scripts/bootstrap.js"));
			bundles.Add(new ScriptBundle("~/js/knockout.js").Include("~/Scripts/knockout-{version}.js"));
			bundles.Add(new ScriptBundle("~/js/chat.js").Include("~/Scripts/chat.js"));
			bundles.Add(new ScriptBundle("~/js/signalr.js").Include("~/Scripts/jquery.signalR-{version}.js"));
		}
	}
}