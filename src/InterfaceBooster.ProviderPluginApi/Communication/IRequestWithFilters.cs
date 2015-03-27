using InterfaceBooster.ProviderPluginApi.Data.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    /// <summary>
    /// Specifies a Request that may contain some filters.
    /// </summary>
    public interface IRequestWithFilters
    {
        /// <summary>
        /// Gets or sets a Filter according to the available FilterDefinitions from the Resource.
        /// </summary>
        Filter Filters { get; set; }
    }
}
