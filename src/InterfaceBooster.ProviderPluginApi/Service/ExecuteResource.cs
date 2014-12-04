using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public class ExecuteResource : Resource
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets a list of parameter declarations.
        /// These parameters can/must be set by Interface Booster on a request.
        /// </summary>
        public IList<Question> Questions { get; set; }

        /// <summary>
        /// Gets or sets a list of values that can be requested by Interface Booster as ReturnValues.
        /// </summary>
        public IList<ValueDefinition> ReturnValues { get; set; }

        #endregion

        #region PUBLIC METHODS

        public ExecuteResource() : base(Communication.RequestTypeEnum.Execute) { }

        #endregion
    }
}
