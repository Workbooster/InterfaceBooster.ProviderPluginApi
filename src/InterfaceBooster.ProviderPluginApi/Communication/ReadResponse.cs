using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public class ReadResponse : Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public IReadRequest Request { get; private set; }

        /// <summary>
        /// Gets or sets the RecordSet that contains the data according to the request (filtered, only the requested fields etc.).
        /// </summary>
        public RecordSet RecordSet { get; set; }

        #endregion

        #region PUBLIC METHODS

        public ReadResponse(IReadRequest request)
            : base(Communication.RequestType.Read)
        {
            Request = request;
        }

        #endregion
    }
}
