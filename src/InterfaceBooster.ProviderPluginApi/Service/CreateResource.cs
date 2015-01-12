using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public class CreateResource : Resource
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the data schema that is expected on a request.
        /// If no schema is expected this property can be set to null.
        /// </summary>
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets a list of parameter declarations.
        /// These parameters can/must be set by Interface Booster on a request.
        /// </summary>
        public IList<Question> Questions { get; set; }

        #endregion

        #region PUBLIC METHODS

        public CreateResource()
            : base(Communication.RequestTypeEnum.Create)
        {
            Questions = new List<Question>();
        }

        #endregion
    }
}
