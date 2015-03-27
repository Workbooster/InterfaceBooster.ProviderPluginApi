using InterfaceBooster.ProviderPluginApi.Data.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    /// <summary>
    /// Specifies a resource that has a FilterDefinitions property.
    /// </summary>
    public interface IResourceWithFilterDefinition
    {
        IList<FilterDefinition> FilterDefinitions { get; set; }
    }
}
