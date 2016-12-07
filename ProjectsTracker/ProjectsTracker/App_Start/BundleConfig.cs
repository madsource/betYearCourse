using System.Web;
using System.Web.Optimization;

namespace ProjectsTracker
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Content/vendors/fastclick/lib/fastclick.js",
                        "~/Content/vendors/nprogress/nprogress.js",
                        "~/Content/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                        "~/Content/vendors/echarts/dist/echarts.min.js",
                        "~/Content/vendors/Chart.js/dist/Chart.min.js",
                        "~/Content/vendors/jquery-sparkline/dist/jquery.sparkline.min.js",                  
                        "~/Scripts/theme.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Content/vendors/iCheck/icheck.min.js",
                        "~/Content/vendors/moment/min/moment.min.js",
                        "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.js",
                        "~/Content/vendors/jquery-knob/dist/jquery.knob.min.js"
                        ));

              // Use the development version of Modernizr to develop with and learn from. Then, when you're
              // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
              bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/vendors/bootstrap/dist/css/bootstrap.css",
                      "~/Content/vendors/font-awesome/css/font-awesome.css",
                      "~/Content/vendors/nprogress/nprogress.css",
                      "~/Content/vendors/iCheck/skins/flat/green.css",
                      "~/Content/vendors/animate.css/animate.min.css",
                      "~/Content/vendors/bootstrap-daterangepicker/daterangepicker.css",
                      "~/Content/css/theme.css",
                      "~/Content/css/site.css"));
        }
    }
}