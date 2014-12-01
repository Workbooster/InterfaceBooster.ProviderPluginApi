using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    /// <summary>
    /// Is used to communicate with the plugin and to import/export data.
    /// </summary>
    public interface IEndpoint
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the name of the endpoint used in Synery.
        /// It may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of strings which build a path to this endpoint used in Synery.
        /// The strings may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        string[] Path { get; set; }

        /// <summary>
        /// Gets or sets an user friendly and localizable description about this Endpoint. 
        /// </summary>
        LocalizedText Description { get; set; }

        #endregion
    }
}
