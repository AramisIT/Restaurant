using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aramis.Core;
using Catalogs;
using Documents;
using TradeHouseWeb.Models.BusinessModels;
using WebCore.Models.Models.JavaScriptModels;
using WebCore.Security.Principal;

namespace TradeHouseWeb
    {
    public class AppBusinessLogic
        {
        public class TareOfProduct
            {
            public long WareId { get; set; }
            public List<tareModel> TareList { get; set; }
            }
        }
    }
