using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aramis.Attributes;
using Aramis.Core;
using Catalogs;
using Documents;

namespace TradeHouse.DatabaseObjects
    {
    public class SolutionRoles : AramisRoles
        {
        [DataField(Description = "Бухгалтер")]
        public static bool Accounter
            {
            get
                {
                return checkRole(() => Accounter);
                }
            }

        [DataField(Description = "Топ менеджер")]
        public static bool TopManager
            {
            get { return checkRole(() => TopManager); }
            }

        public override void AddPermissionsToNotAuthorizedRoles(AramisRoleDefinition role)
            {
            }

        public override void AddPermissionsToSuperAdmin(AramisRoleDefinition role)
            {
            role.AddPermission<Users>(PermissionsFullRight);
            }
        }
    }
