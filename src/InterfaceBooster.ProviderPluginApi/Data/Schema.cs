using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// A Schema describes the structure of a RecordSet. Each field represents a column in a RecordSet.
    /// </summary>
    public class Schema
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets an user friendly and localizable description about this Schema. 
        /// </summary>
        public LocalizedText Description { get; set; }

        /// <summary>
        /// Gets or sets an internal name used by the Provider Plugin to internaly identify the Schema (e.g. the table name).
        /// (You can use it or not - this value isn't touched by Interface Booster in any way).
        /// </summary>
        public string InternalName { get; set; }

        /// <summary>
        /// Gets or sets a list of columns.
        /// </summary>
        public IList<Field> Fields { get; set; }

        #endregion

        #region PUBLIC METHODS

        public Schema(IEnumerable<Field> fields = null)
        {
            if (fields == null)
            {
                Fields = new List<Field>();
            }
            else
            {
                Fields = new List<Field>(fields);
            }
        }

        #endregion
    }
}
