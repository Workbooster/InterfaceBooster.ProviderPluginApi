using InterfaceBooster.ProviderPluginApi.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Common
{
    public static class Helpers
    {
        public static T FindRequestByResourceName<T>(this IEnumerable<IRequest> listOfRequests, string resourceName) where T : IRequest
        {
            T request = (from r in listOfRequests
                         where r is T
                         && r.Resource != null
                         && r.Resource.Name == resourceName
                         select (T)r).FirstOrDefault();

            return request;
        }
    }
}
