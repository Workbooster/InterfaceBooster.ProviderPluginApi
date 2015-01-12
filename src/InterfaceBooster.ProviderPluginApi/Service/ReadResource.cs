using InterfaceBooster.ProviderPluginApi.Data;
using InterfaceBooster.ProviderPluginApi.Data.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public class ReadResource : Resource
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the data schema that is provided on a request.
        /// If no schema is provided this property can be set to null.
        /// </summary>
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets a list of parameter declarations.
        /// These parameters can/must be set by Interface Booster on a request.
        /// </summary>
        public IList<Question> Questions { get; set; }

        /// <summary>
        /// Gets or sets a list of filter-fields that can be used to specify filters for reading the data.
        /// </summary>
        public IList<FilterDefinition> FilterDefinitions { get; set; }

        #endregion

        #region PUBLIC METHODS

        public ReadResource()
            : base(Communication.RequestTypeEnum.Read)
        {
            Questions = new List<Question>();
            FilterDefinitions = new List<FilterDefinition>();
        }

        #endregion
    }
}
