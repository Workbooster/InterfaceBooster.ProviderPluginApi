using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    /// <summary>
    /// This is the base class for all kind of filters (Conditions, FilterGroups etc.).
    /// The FilterType specifies what kind of filter this is and allows an easy type-casting.
    /// </summary>
    public abstract class Filter
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the filter type. This allows an easy type-casting.
        /// </summary>
        public FilterTypeEnum FilterType { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public Filter(FilterTypeEnum filterType)
        {
            FilterType = filterType;
        }

        #endregion
    }
}
