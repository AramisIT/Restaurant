using System.Web.Optimization;
using Aramis.Platform;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using Catalogs;
using TradeHouseWeb.App_Start;
using Unity.Mvc5;
using WebCore.Infostructure;
using Microsoft.Practices.Unity;

namespace TradeHouseWeb
    {
    public class MvcApplication : System.Web.HttpApplication
        {
        protected void Application_Start()
            {
            HostingEnvironment.RegisterVirtualPathProvider(new AssemblyVirtualPathProvider());

            SystemAramis.SystemStart(new WebUserInterfaceEngine(typeof(Users).Assembly));

            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityConfig.RegisterComponents();
            }
        }


    }


