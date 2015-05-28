using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;
using Documents;
using WebCore.Models;

namespace TradeHouseWeb.App_Start
    {
    public class BundleConfig
        {
        public static void RegisterBundles(BundleCollection bundles)
            {
            bundles.Add(new ScriptBundle("~/bundles/aramis-solution").Include(
                        "~/Scripts/modernizr-2.6.2.js",
                        "~/Scripts/table-edit.js",
                        "~/Scripts/aramis.js"));

            bundles.Add(new ScriptBundle("~/bundles/jQuery").Include(
                       "~/Scripts/jquery-2.1.4.js",
                       "~/Scripts/jquery.unobtrusive-ajax.js",
                       "~/Scripts/jquery.dataTables.js",
                       "~/Scripts/jquery.mobile.custom.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/Content/aramis.css",
                "~/Content/bootstrap.css"));

            ItemViewFrontEnd.GetInstance().RegisterTypes(getItemsTypes()).Foreach(itemName =>
                bundles.Add(new StyleBundle("~/bundles/ItemView/" + itemName).Include("~/Scripts/items.views/" + itemName + ".js")));
            }

        private static IEnumerable<Type> getItemsTypes()
            {
            return new Type[] { };
            }
        }
    }
