using System.Web.Optimization;

namespace SeguridadWebv2
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
            /*Javascript*/
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery.js",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                      "~/Scripts/moment-with-locales.js"));

            bundles.Add(new ScriptBundle("~/bundles/typeahead").Include(
                      "~/Scripts/typeahead.bundle.js",
                      "~/Scripts/handlebars.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminPanelJs").Include(
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/jquery.dcjqaccordion.2.7.js",
                     "~/Scripts/SeguridadDashboard.js"));

            bundles.Add(new ScriptBundle("~/bundles/VideoConfJs").Include(
                   "~/Scripts/adapter.js",
                   "~/Scripts/knockout-2.2.1.js",
                   "~/Scripts/knockout.mapping-latest.js",
                   "~/Scripts/alertify.js",
                   "~/Scripts/alertify.min.js",
                   "~/Scripts/webrtcdemo/viewModel.js",
                   "~/Scripts/webrtcdemo/connectionManager.js",
                   "~/Scripts/webrtcdemo/app.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                    "~/Scripts/jquery.signalR-{version}.js"
            ));

            /*Estilos*/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome/css/font-awesome.css",
                      "~/Content/bootstrap.css",
                      "~/Content/typeaheadjs.css",
                      "~/Content/SeguridadStyle.css",
                      "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new StyleBundle("~/Content/adminPanel").Include(
                 "~/Content/font-awesome/css/font-awesome.css",
                 "~/Content/bootstrap.css",
                  "~/Content/SeguridadDashboard.css",
                   "~/Content/SeguridadResponsiveDash.css"
                ));

            bundles.Add(new StyleBundle("~/Content/VideoConf").Include(
                 "~/Content/icomoon/style.css",
                 "~/Content/VideoConf.css", 
                 "~/Content/bootstrap/css/bootstrap.min.css",
                 "~/Content/alertify/alertify.bootstrap.css",
                 "~/Content/alertify/alertify.core.css",
                 "~/Content/alertify/alertify.default.css"
                ));
        }
    }
}