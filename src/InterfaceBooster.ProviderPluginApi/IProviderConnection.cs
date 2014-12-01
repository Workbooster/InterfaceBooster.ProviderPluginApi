using InterfaceBooster.ProviderPluginApi.Data;
using InterfaceBooster.ProviderPluginApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi
{
    /// <summary>
    /// Represents a connection to the foreign system or the file. The endpoints are used to communicate with the plugin and to import/export data.
    /// </summary>
    public interface IProviderConnection
    {
        ConnectionSettings Settings { get; }
        IEnumerable<IEndpoint> Endpoints { get; }
    }
}
