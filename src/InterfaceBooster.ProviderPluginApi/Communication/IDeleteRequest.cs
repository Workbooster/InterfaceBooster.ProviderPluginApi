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
    public interface IDeleteRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the original resource this request is based on.
        /// </summary>
        DeleteResource Resource { get; set; }

        /// <summary>
        /// Gets or sets a RecordSet that matches the Schema of the resource (or null if no data is given).
        /// </summary>
        RecordSet RecordSet { get; set; }

        /// <summary>
        /// Gets or sets a list of Answers given to the Questions from the resource.
        /// </summary>
        IEnumerable<Answer> Answers { get; set; }
        
        /// <summary>
        /// Gets or sets a Filter according to the available FilterDefinitions from the Resource.
        /// </summary>
        Filter Filters { get; set; }
    }
}
