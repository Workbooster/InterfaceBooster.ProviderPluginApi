using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    /// <summary>
    /// This is the base class for a list of combined filters that are linked by a logical operator (e.g. AND / OR)
    /// </summary>
    public abstract class FilterGroup : Filter
    {
        #region PROPERTIES

        public IList<Filter> FilterItems { get; set; }

        #endregion

        #region PUBLIC METHODS

        public FilterGroup(FilterTypeEnum filterType)
            : base(filterType)
        {
            FilterItems = new List<Filter>();
        }

        #endregion
    }
}
