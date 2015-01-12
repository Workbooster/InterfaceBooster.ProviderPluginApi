using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public class ExecuteResponse : Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IExecuteRequest Request { get; private set; }

        /// <summary>
        /// Gets or sets a dictionary containing the requested ReturnValues.
        /// </summary>
        public IDictionary<string, object> Values { get; set; }

        #endregion

        #region PUBLIC METHODS

        public ExecuteResponse(IExecuteRequest request)
            : base(Communication.RequestTypeEnum.Execute)
        {
            Request = request;
            Values = new Dictionary<string, object>();
        }

        #endregion
    }
}
