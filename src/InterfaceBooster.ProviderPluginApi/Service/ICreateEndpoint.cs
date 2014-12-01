using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public interface ICreateEndpoint : IEndpoint
    {
        #region METHODS

        CreateResource GetCreateResource();
        CreateResponse RunCreateRequest(ICreateRequest request);

        #endregion
    }
}
