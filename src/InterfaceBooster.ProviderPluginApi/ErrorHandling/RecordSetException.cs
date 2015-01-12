using InterfaceBooster.ProviderPluginApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.ErrorHandling
{
    /// <summary>
    /// An exception that happens in the context of a record set. It takes a Schema as parameter that allows to display a better error description.
    /// </summary>
    [Serializable]
    public class RecordSetException : Exception
    {
        #region PROPERTIES

        public Schema Schema { get; private set; }

        #endregion

        #region IMPLEMNETATION OF EXCEPTION

        public RecordSetException() { }
        public RecordSetException(Schema schema, string message) : base(message) { Schema = schema; }
        public RecordSetException(Schema schema, string message, Exception inner) : base(message, inner) { Schema = schema; }
        protected RecordSetException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        #endregion
    }
}
