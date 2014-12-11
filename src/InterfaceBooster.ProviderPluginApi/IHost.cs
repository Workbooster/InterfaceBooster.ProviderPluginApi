using System;
using System.Collections.Generic;
using System.Globalization;
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
        /// <summary>
        /// Gets or sets the culture the user fronted uses.
        /// </summary>
        CultureInfo FrontendCulture { get; set; }

        /// <summary>
        /// Gets or sets the absolute path to the main directory of the interface definition currently is execued.
        /// </summary>
        string CurrentInterfaceDefinitionDirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the absolute path to the main directory of the Interface Booster runtime (exe).
        /// </summary>
        string RuntimeDirectoryPath { get; set; }

        /// <summary>
        /// Gets or sets the absolute path to the main directory of this provider plugin.
        /// </summary>
        string ProviderPluginDiretcoryPath { get; set; }
    }
}
