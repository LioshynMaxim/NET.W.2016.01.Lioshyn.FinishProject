using System.Web.Optimization;

namespace MvcPL
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                      "~/Scripts/jquery.lightbox.js",
                      "~/Scripts/templatemo_custom.js",
                      "~/Scripts/jquery.*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/other/animate.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/other/templatemo_misc.css",
                      "~/Content/other/templatemo_style.css"));

            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                    "~/Content/administrator/admin.bootstrap.min.css",
                    "~/Content/administrator/font-awesome.min.css",
                    "~/Content/administrator/styles.css",
                    "~/Content/administrator/bootstrap-glyphicons.css"));

            bundles.Add(new ScriptBundle("~/adminjs").Include(
                "~/Scripts/administrator/scripts.js",
                "~/Scripts/administrator/bootstrap.min.js",
                "~/Scripts/administrator/jquery.min.js"));

        }
    }
}
