using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public interface IExecuteEndpoint : IEndpoint
    {
        #region METHODS

        ExecuteResource GetExecuteResource();
        ExecuteResponse RunExecuteRequest(IExecuteRequest request);

        #endregion
    }
}
