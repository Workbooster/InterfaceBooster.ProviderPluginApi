using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public abstract class Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets a flag that states the type of the original request. This is usefull to make a correct type-casting.
        /// </summary>
        public RequestTypeEnum RequestType { get; set; }

        /// <summary>
        /// Gets or sets a list of responses to the according SubRequests.
        /// </summary>
        public IList<Response> SubResponses { get; set; }

        #endregion

        #region PUBLIC METHODS

        public Response(RequestTypeEnum type)
        {
            RequestType = type;
        }

        #endregion
    }
}
