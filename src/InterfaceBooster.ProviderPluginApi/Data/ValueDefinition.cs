using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// Defines the type and the name of a value that can be exchanged between the Provider Plugin and the Interface Booster.
    /// </summary>
    public class ValueDefinition
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the name of the value used in Synery.
        /// It may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the expected data type of the value.
        /// </summary>
        public Type Type { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public ValueDefinition(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        #endregion
    }
}
