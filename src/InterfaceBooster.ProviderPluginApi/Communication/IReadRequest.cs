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
    public interface IReadRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the original resource this request is based on.
        /// </summary>
        new ReadResource Resource { get; set; }
        
        /// <summary>
        /// Gets or sets a list of Answers given to the Questions from the resource.
        /// </summary>
        AnswerList Answers { get; set; }

        /// <summary>
        /// Gets or sets a list of fields from the original Schema of the ReadResource that are expected to be loaded and returned within the response.
        /// </summary>
        IEnumerable<Field> RequestedFields { get; set; }

        /// <summary>
        /// Gets or sets a Filter according to the available FilterDefinitions from the Resource.
        /// </summary>
        Filter Filters { get; set; }
    }
}
