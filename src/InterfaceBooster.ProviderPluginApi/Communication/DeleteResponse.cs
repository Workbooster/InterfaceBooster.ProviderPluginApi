using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public class DeleteResponse : Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IDeleteRequest Request { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public DeleteResponse(IDeleteRequest request)
            : base(Communication.RequestType.Delete)
        {
            Request = request;
        }

        #endregion
    }
}
