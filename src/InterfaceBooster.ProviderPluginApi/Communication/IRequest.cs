using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public interface IRequest
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets a flag that states the type of the request. This is usefull to make a correct cast.
        /// </summary>
        RequestTypeEnum RequestType { get; set; }

        /// <summary>
        /// Gets or sets the Request(s) on some SubResources.
        /// </summary>
        IList<IRequest> SubRequests { get; set; }

        #endregion
    }
}
