using InterfaceBooster.ProviderPluginApi.Communication;
using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public abstract class Resource
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets a flag that states the type of the request. This is usefull to make a correct type-casting.
        /// </summary>
        public RequestType RequestType { get; set; }

        /// <summary>
        /// Gets or sets a Name-Resource dictionary with nested Resources. This Sub-Resources can be used in Sub-Requests.
        /// The key contains a name that is used in Synery to identify the Resource. 
        /// The name may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        public IDictionary<string, Resource> SubResources { get; set; }

        /// <summary>
        /// Gets or sets an user friendly and localizable description about this Resource. 
        /// </summary>
        public LocalizedText Description { get; set; }

        /// <summary>
        /// Gets or sets an internal name used by the Provider Plugin to internaly identify the FilterDefinition (e.g. the table name).
        /// (You're free to use this property internally. This value isn't touched or displayed by Interface Booster in any way).
        /// </summary>
        public string InternalIdentifier { get; set; }

        #endregion

        #region PUBLIC METHODS

        public Resource(RequestType type)
        {
            RequestType = type;
        }

        #endregion
    }
}
