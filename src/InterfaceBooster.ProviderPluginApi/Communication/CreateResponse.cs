using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public class CreateResponse : Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public ICreateRequest Request { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public CreateResponse(ICreateRequest request)
            : base(Communication.RequestType.Create)
        {
            Request = request;
        }

        #endregion
    }
}
