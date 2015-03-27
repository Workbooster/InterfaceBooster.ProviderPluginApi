using InterfaceBooster.ProviderPluginApi.Data;
using InterfaceBooster.ProviderPluginApi.Data.Filter;
using InterfaceBooster.ProviderPluginApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    public interface IDeleteRequest : IRequest, IRequestWithRecordSet, IRequestWithFilters
    {
        /// <summary>
        /// Gets or sets the original resource this request is based on.
        /// </summary>
        new DeleteResource Resource { get; set; }

        /// <summary>
        /// Gets or sets a list of Answers given to the Questions from the resource.
        /// </summary>
        AnswerList Answers { get; set; }
    }
}
