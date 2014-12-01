using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi
{
    /// <summary>
    /// One implementation of the ProviderPlugin. There may be multiple implementations of IProviderPluginInstance.
    /// Multiple implementations allow to differentiate between different behviours and versions of the plugin.
    /// </summary>
    public interface IProviderPluginInstance
    {
        /// <summary>
        /// Gets the interface to the plugin host.
        /// </summary>
        IHost Host { get; }

        /// <summary>
        /// Creates a connection according to the given settings.
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        IProviderConnection CreateProviderConnection(ConnectionSettings settings);
    }
}
