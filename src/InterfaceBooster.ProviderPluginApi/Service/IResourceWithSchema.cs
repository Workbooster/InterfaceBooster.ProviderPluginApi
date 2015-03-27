using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    /// <summary>
    /// Specifies a resource that has a Schema property.
    /// </summary>
    public interface IResourceWithSchema
    {
        Schema Schema { get; set; }
    }
}
