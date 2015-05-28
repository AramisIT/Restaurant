using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore.BusinessLogic;
using WebCore.Filters;
using WebCore.Security.Principal;

namespace TradeHouseWeb.Controllers
    {
    [Authorize]
    public class AjaxSolutionController : Controller
        {
        private AppBusinessLogic businessLogic;

        public AjaxSolutionController(AppBusinessLogic businessLogic)
            {
            this.businessLogic = businessLogic;
            }
        }
    }