using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public interface IDeleteEndpoint : IEndpoint
    {
        #region METHODS

        DeleteResource GetDeleteResource();
        DeleteResponse RunDeleteRequest(IDeleteRequest request);

        #endregion
    }
}
