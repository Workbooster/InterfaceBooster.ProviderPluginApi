using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Communication
{
    /// <summary>
    /// Specifies all requests that may contain a RecordSet
    /// </summary>
    public interface IRequestWithRecordSet
    {
        /// <summary>
        /// Gets or sets a RecordSet that matches the Schema of the resource (or null if no data is given).
        /// </summary>
        RecordSet RecordSet { get; set; }
    }
}
