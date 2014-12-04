using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public class SaveResponse : Response
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the original request.
        /// </summary>
        public ISaveRequest Request { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public SaveResponse(ISaveRequest request)
            : base(Communication.RequestTypeEnum.Save)
        {
            Request = request;
        }

        #endregion
    }
}
