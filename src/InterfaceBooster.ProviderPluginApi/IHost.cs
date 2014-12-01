using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi
{
    /// <summary>
    /// A host instance is used to communicate with the plugin host and to get runtime information.
    /// </summary>
    public interface IHost
    {
        string CurrentInterfaceDefinitionDirectoryPath { get; set; }
        string RuntimeDirectoryPath { get; set; }
        string ProviderPluginDiretcoryPath { get; set; }
    }
}
