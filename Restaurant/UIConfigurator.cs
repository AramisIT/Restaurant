using Aramis.Platform;
using Aramis.SystemConfigurations;
using Aramis.UI.DBObjectsListFilter;
using Catalogs;
using Documents;
using TradeHouse.DatabaseObjects;

namespace PlatformTest
    {
    class UIConfigurator : Configurator
        {
        public override void SetFiltersForItemsLists()
            {
            SetFilter<IContractor>(item => item.SalePoint, (condition) =>
                {
                    condition.Locked = true;
                    condition.AddValue(0);
                    var currentUserSalePoint = SalePointExtentions.GetSalePointIdForUser();
                    if (currentUserSalePoint > 0)
                        {
                        condition.AddValue(currentUserSalePoint);
                        }
                });

            SetFilter<IAcceptance>(item => item.Entity, (condition) =>
                {
                    if (SolutionRoles.TopManager)
                        {
                        condition.Active = false;
                        return;
                        }

                    condition.Locked = true;
                    condition.AddValue(EntityBehaviour.GetIdForCurrentUser());
                });

            SetFilter<IShipment>(item => item.SalePoint, (condition) =>
            {
                if (SolutionRoles.TopManager)
                    {
                    condition.Active = false;
                    return;
                    }

                condition.Locked = true;
                condition.AddValue(SalePointExtentions.GetSalePointIdForUser());
            });


            SetFilter<IExpenses>(item => item.SalePoint, (condition) =>
            {
                if (SolutionRoles.TopManager)
                    {
                    condition.Active = false;
                    return;
                    }

                condition.Locked = true;
                condition.AddValue(SalePointExtentions.GetSalePointIdForUser());
            });

            SetFilter<IInventory>(item => item.SalePoint, (condition) =>
            {
                if (SolutionRoles.TopManager)
                    {
                    condition.Active = false;
                    return;
                    }

                condition.Locked = true;
                condition.AddValue(SalePointExtentions.GetSalePointIdForUser());
            });
            }

        public void SetNesessaryRoles()
            {

            }
        }
    }
