using System.Web;
using System.Web.Optimization;

namespace Quali_T_Repair_and_Services
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/bootstrap-timepicker.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-min.css",
                      "~/Content/site.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/font-awesome.min.css",
                      //"~/Content/css/endless.min.css",
                      "~/Content/css/endless-skin.css",
                      "~/Content/css/pace.css",
                      "~/Content/css/fullcalendar.css",
                      "~/Content/css/pace.css",
                      "~/Content/css/prettify.css",
                      "~/Content/css/datepicker.css"));
        }
    }
}
