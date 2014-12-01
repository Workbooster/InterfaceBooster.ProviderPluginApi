using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    /// <summary>
    /// Represents a list of combined filters connected by a logical AND operator.
    /// </summary>
    public class AndFilterGroup : FilterGroup
    {
        #region PUBLIC METHODS

        public AndFilterGroup() : base(FilterType.AndGroup) { }

        #endregion
    }
}
