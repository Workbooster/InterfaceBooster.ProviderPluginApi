using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public interface IReadEndpoint : IEndpoint
    {
        #region METHODS

        ReadResource GetReadResource();
        ReadResponse RunReadRequest(IReadRequest request);

        #endregion
    }
}
