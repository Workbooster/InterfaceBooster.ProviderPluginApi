using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    public abstract class FilterCondition : Filter
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the definition of the value or the field that is used for the comparison.
        /// </summary>
        public FilterDefinition Definition { get; set; }

        #endregion

        #region PUBLIC METHODS

        public FilterCondition(FilterTypeEnum filterType, FilterDefinition definition)
            : base(filterType)
        {
            Definition = definition;
        }

        #endregion
    }
}
