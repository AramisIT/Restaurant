using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebCore;

namespace TradeHouseWeb
    {
    public class RouteConfig
        {
        public static void RegisterRoutes(RouteCollection routes)
            {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(RouteNameConstants.SignIn, "signin", new { controller = "Account", action = "SignIn" });
            routes.MapRoute(RouteNameConstants.SignOut, "signout", new { controller = "Account", action = "SignOut" });

            routes.MapRoute(RouteNameConstants.Reports, "report/{id}/{action}", new { controller = "Reports", action = "Index" });

            routes.MapRoute("ItemData", "AddData/{action}", new { controller = "AjaxSolution" });

            routes.MapRoute(RouteNameConstants.ItemsList, "ItemsList/{tableName}/{startDate}", new { controller = "ItemView", action = "List", startDate = UrlParameter.Optional });

            routes.MapRoute(RouteNameConstants.ItemsListSettings, "ItemsListSettings/{tableName}", new { controller = "Settings", action = "SaveDocumentPeriod" });

            routes.MapRoute(RouteNameConstants.ItemViewSave, "SaveItemView/{tableName}", new { controller = "ItemView", action = "SaveItem" });

            routes.MapRoute(
                name: RouteNameConstants.ItemView,
                url: "ItemView/{tableName}/{id}",
                defaults: new { controller = "ItemView", action = "Show", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: RouteNameConstants.PrintForm,
                url: "PrintForm/{tableName}/{formid}/{id}",
                defaults: new { controller = "Reports", action = "Pdf" }
            );

            routes.MapRoute(RouteNameConstants.ItemViewGetTable, "ItemView/Table/{tableName}/{id}/{subtableName}/{tableParameters}",
                new { controller = "ItemView", action = "GetTable", tableParameters = UrlParameter.Optional });

            routes.MapRoute(RouteNameConstants.UIajax, "UIajax/{action}", new { controller = "UIajax" });

            routes.MapRoute(
                name: RouteNameConstants.Default,
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            }
        }
    }
