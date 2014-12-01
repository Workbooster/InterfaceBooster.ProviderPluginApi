using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public class UpdateResponse : Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IUpdateRequest Request { get; }

        #endregion

        #region PUBLIC METHODS

        public UpdateResponse() : base(Communication.RequestType.Update) { }

        #endregion
    }
}
