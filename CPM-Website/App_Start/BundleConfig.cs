﻿using System.Web.Optimization;

namespace CPM_Website
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region CSS
            bundles.Add(new StyleBundle("~/css/common")
                            .Include("~/Content/Common/bootstrap.min.css")
                            .Include("~/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css")
                            .Include("~/vendors/bootstrap-daterangepicker/daterangepicker.css")
                            .Include("~/Content/Common/font-glyphicons.css", new CssRewriteUrlTransform())
                            .Include("~/Content/Common/font-awesome.css", new CssRewriteUrlTransform())
                            .Include("~/vendors/nprogress/nprogress.css")
                            .Include("~/vendors/iCheck/skins/flat/green.css", new CssRewriteUrlTransform())
                            .Include("~/Content/Common/custom.css")
                        );

            bundles.Add(new StyleBundle("~/css/pnotify")
                            .Include("~/vendors/pnotify/dist/pnotify.css")
                            .Include("~/vendors/pnotify/dist/pnotify.buttons.css")
                            .Include("~/vendors/pnotify/dist/pnotify.nonblock.css")
                        );

            #endregion

            #region JS
            bundles.Add(new ScriptBundle("~/js/common")
                            .Include("~/Scripts/Common/jquery/jquery-1.12.4.min.js")
                            .Include("~/Scripts/Common/bootstrap/bootstrap.min.js")
                            .Include("~/Scripts/Common/angularJS/angular.min.js")
                            .Include("~/Scripts/Common/angularJS/app.js")
                            .Include("~/vendors/nprogress/nprogress.js")
                            .Include("~/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js")
                            .Include("~/vendors/iCheck/icheck.min.js")
                            .Include("~/vendors/DateJS/build/date.js")
                            .Include("~/vendors/moment/min/moment.min.js")
                            .Include("~/vendors/bootstrap-daterangepicker/daterangepicker.js")
                            .Include("~/Scripts/Common/custom.js")
                        );



            bundles.Add(new ScriptBundle("~/js/fastClick")
                            .Include("~/vendors/fastclick/lib/fastclick.js")
                        );

            bundles.Add(new ScriptBundle("~/js/chart")
                            .Include("~/vendors/Chart.js/dist/Chart.min.js")
                            .Include("~/vendors/Flot/jquery.flot.js")
                            .Include("~/vendors/Flot/jquery.flot.pie.js")
                            .Include("~/vendors/Flot/jquery.flot.time.js")
                            .Include("~/vendors/Flot/jquery.flot.stack.js")
                            .Include("~/vendors/Flot/jquery.flot.resize.js")
                            .Include("~/vendors/flot.orderbars/js/jquery.flot.orderBars.js")
                            .Include("~/vendors/flot-spline/js/jquery.flot.spline.min.js")
                            .Include("~/vendors/flot.curvedlines/curvedLines.js")
                            .Include("~/vendors/gauge.js/dist/gauge.min.js")
                        );

            bundles.Add(new ScriptBundle("~/js/Skycons")
                            .Include("~/vendors/skycons/skycons.js")
                        );

            bundles.Add(new ScriptBundle("~/js/pnotify")
                            .Include("~/vendors/pnotify/dist/pnotify.js")
                            .Include("~/vendors/pnotify/dist/pnotify.buttons.js")
                            .Include("~/vendors/pnotify/dist/pnotify.nonblock.js")
                        );
            #endregion
        }
    }
}