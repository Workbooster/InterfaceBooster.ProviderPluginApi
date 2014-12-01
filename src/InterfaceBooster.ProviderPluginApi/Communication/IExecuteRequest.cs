using InterfaceBooster.ProviderPluginApi.Data;
using InterfaceBooster.ProviderPluginApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public interface IExecuteRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the original resource this request is based on.
        /// </summary>
        ExecuteResource Resource { get; set; }

        /// <summary>
        /// Gets or sets a list of Answers given to the Questions from the resource.
        /// </summary>
        IEnumerable<Answer> Answers { get; set; }

        /// <summary>
        /// Gets or sets a list of names of requested return values from the resource.
        /// </summary>
        IEnumerable<string> RequestedValues { get; set; }
    }
}
