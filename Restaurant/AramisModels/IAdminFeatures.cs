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
        }
    }
