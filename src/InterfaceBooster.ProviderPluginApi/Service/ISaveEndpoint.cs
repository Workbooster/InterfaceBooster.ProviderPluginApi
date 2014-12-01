using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Service
{
    public interface ISaveEndpoint : IEndpoint
    {
        #region METHODS

        SaveResource GetSaveResource();
        SaveResponse RunSaveRequest(ISaveRequest request);

        #endregion
    }
}
