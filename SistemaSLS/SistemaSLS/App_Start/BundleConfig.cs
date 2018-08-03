using System.Web;
using System.Web.Optimization;

namespace SistemaSLS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
               "~/Content/Theme/plugins/jquery/jquery.min.js",
                        "~/Content/Theme/plugins/bootstrap/js/bootstrap.js",
                        "~/Content/Theme/plugins/bootstrap-select/js/bootstrap-select.js",
                        "~/Content/Theme/plugins/jquery-slimscroll/jquery.slimscroll.js",
                        "~/Content/Theme/plugins/node-waves/waves.js",
                        "~/Content/Theme/plugins/jquery-countto/jquery.countTo.js",
                        "~/Content/Theme/plugins/raphael/raphael.min.js",
                        "~/Content/Theme/plugins/morrisjs/morris.js",
                        "~/Content/Theme/plugins/chartjs/Chart.bundle.js",
                        "~/Content/Theme/plugins/flot-charts/jquery.flot.js",
                        "~/Content/Theme/plugins/flot-charts/jquery.flot.resize.js",
                        "~/Content/Theme/plugins/flot-charts/jquery.flot.pie.js",
                        "~/Content/Theme/plugins/flot-charts/jquery.flot.categories.js",
                        "~/Content/Theme/plugins/flot-charts/jquery.flot.time.js",
                        "~/Content/Theme/plugins/jquery-sparkline/jquery.sparkline.js",
                        "~/Content/Theme/js/admin.js",
                        "~/Content/Theme/js/pages/index.js"));

    

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/Theme/css/style.css",  
                       "~/Content/Theme/css/themes/all-themes.css"));

            //"~/Content/bootstrap.css","~/Content/site.css",
            bundles.Add(new StyleBundle("~/bundles/plugins").Include(
                     "~/Content/Theme/plugins/bootstrap/css/bootstrap.css",
                     "~/Content/Theme/plugins/node-waves/waves.css",
                     "~/Content/Theme/plugins/animate-css/animate.css",
                      "~/Content/Theme/plugins/morrisjs/morris.css"));
        }
    }
}
