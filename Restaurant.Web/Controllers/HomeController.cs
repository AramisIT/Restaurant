using System.Web.Mvc;
using System.Web.Routing;
using Aramis.SystemConfigurations;
using Catalogs;
using WebCore;

namespace TradeHouseWeb.Controllers
    {
    [Authorize]
    public class HomeController : Controller
        {
        // GET: /Home/
        public ActionResult Index()
            {
            ViewBag.CurrentRoute = RouteNameConstants.Default;

            return View();
            }
        }
    }