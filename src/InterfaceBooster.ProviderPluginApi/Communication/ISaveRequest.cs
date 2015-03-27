using InterfaceBooster.ProviderPluginApi.Data;
using InterfaceBooster.ProviderPluginApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public interface ISaveRequest : IRequest, IRequestWithRecordSet
    {
        /// <summary>
        /// Gets or sets the original resource this request is based on.
        /// </summary>
        new SaveResource Resource { get; set; }

        /// <summary>
        /// Gets or sets a list of Answers given to the Questions from the resource.
        /// </summary>
        AnswerList Answers { get; set; }
    }
}
