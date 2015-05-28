using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aramis.Core;
using WebCore.BusinessLogic;
using WebCore.Filters;
using WebCore.Infostructure.Attributes;
using WebCore.Models.Models.ParametersModels;
using WebCore.Security.Principal;

namespace TradeHouseWeb.Controllers
    {
    public class AdditionalServicesController : Controller
        {
        private AppBusinessLogic businessLogic;

        public AdditionalServicesController(AppBusinessLogic businessLogic)
            {
            this.businessLogic = businessLogic;
            }
        }
    }