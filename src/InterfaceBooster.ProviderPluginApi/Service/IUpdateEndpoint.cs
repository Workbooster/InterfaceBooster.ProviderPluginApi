using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public interface IUpdateEndpoint : IEndpoint
    {
        #region METHODS

        UpdateResource GetUpdateResource();
        UpdateResponse RunUpdateRequest(IUpdateRequest request);

        #endregion
    }
}
