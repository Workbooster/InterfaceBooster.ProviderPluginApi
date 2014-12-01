using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi
{
    /// <summary>
    /// The entry point of a Provider Plugin. Only one instance per plugin is allowed.
    /// </summary>
    public interface IProviderPlugin
    {
        /// <summary>
        /// Creates a ProviderPluginInstance according to the given GUID.
        /// The GUID allows to differentiate between different implementations or versions of the plugin.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        IProviderPluginInstance CreateProviderPluginInstance(Guid id, IHost host);
    }
}
