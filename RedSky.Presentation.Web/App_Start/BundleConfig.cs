using System.Web.Optimization;

namespace RedSky.Presentation.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.4.1.js",
                "~/Scripts/jquery.blockUI.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/umd/popper.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/jquery.mask.js",
                "~/Scripts/moment.js"));

            var bundle = new ScriptBundle("~/bundles/jqueryval") { Orderer = new AsIsBundleOrderer() };
            bundle
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery.validate-vsdoc.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobstrusive.js");
                //.Include("~/Scripts/cldr.js")
                //.Include("~/Scripts/globalize.js")
                //.Include("~/Scripts/jquery.validate.globalize.js");
            bundles.Add(bundle);

            bundles.Add(new ScriptBundle("~/bundles/kopernik")
                .Include("~/Scripts/kopernik/site.js"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
        }
    }
}