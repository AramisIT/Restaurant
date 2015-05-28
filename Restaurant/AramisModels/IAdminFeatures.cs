using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aramis.Core;
using Documents;

namespace TradeHouse.AramisModels
    {
    public interface IAdminFeatures : IAramisModel
        {
        }

    public class AdminFeaturesBehaviour : Behaviour<IAdminFeatures>
        {
        public AdminFeaturesBehaviour(IAdminFeatures item)
            : base(item) { }

        public void UpdateAllDocumentsAfterWaresChanging()
            {
            var success = true;
            A.Query(@"select Id from Acceptance where deleted = 0 order by [date]").SelectToList<long>().ForEach(id =>
                {
                    var item = A.New<IAcceptance>(id);
                    item.GetBehaviour<AcceptanceBehaviour>().UpdateWaresTable();
                    success = item.Write().IsSuccess() && success;
                });

            A.Query(@"select Id from Shipment where deleted = 0 order by [date]").SelectToList<long>().ForEach(id =>
            {
                var item = A.New<IShipment>(id);
                foreach (var row in item.Wares)
                    {
                    var mainWare = row.Ware.Item.GetRef("MainWare");
                    if (mainWare == 0 || mainWare == row.Ware.Id) continue;

                    row.Ware.Id = mainWare;
                    }
                if (item.IsTableModified<IShipmentRow>())
                    {
                    success = item.Write().IsSuccess() && success;
                    }
            });

            if (success)
                {
                "Все обновлено успешно!".NotifyToUser();
                }

            }
        }
    }
