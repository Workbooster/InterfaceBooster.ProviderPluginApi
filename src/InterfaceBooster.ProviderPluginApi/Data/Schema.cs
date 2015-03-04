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
        public IList<Field> Fields { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public Schema()
        {
            Initialize();
        }

        public Schema(IEnumerable<Field> fields = null)
        {
            Initialize(fields);
        }

        /// <summary>
        /// Finds the index of the first field matching the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The index of the first matching item, or -1 if no items match.</returns>
        public int FindIndexOfFieldByName(string name)
        {
            int retVal = 0;
            foreach (var item in Fields)
            {
                if (item.Name == name) return retVal;
                retVal++;
            }
            return -1;
        }

        /// <summary>
        /// Finds the index of the first field matching the given internal name.
        /// </summary>
        /// <param name="internalName"></param>
        /// <returns>The index of the first matching item, or -1 if no items match.</returns>
        public int FindIndexOfFieldByInternalName(string internalName)
        {
            int retVal = 0;
            foreach (var item in Fields)
            {
                if (item.InternalName == internalName) return retVal;
                retVal++;
            }
            return -1;
        }

        /// <summary>
        /// Clones an existing schema. Copies all primitive values and creates a new list for the fields.
        /// </summary>
        /// <param name="originalSchema"></param>
        /// <returns></returns>
        public Schema Clone()
        {
            return new Schema(new List<Field>(this.Fields))
            {
                InternalName = this.InternalName,
                Description = this.Description,
            };
        }

        /// <summary>
        /// Creates a new schema based on the given parameters..
        /// </summary>
        /// <param name="internalName"></param>
        /// <param name="fields"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static Schema New(string internalName = null, IEnumerable<Field> fields = null, string description = null)
        {
            return new Schema(fields)
            {
                InternalName = internalName,
                Description = description,
            };
        }

        public override string ToString()
        {
            return String.Format("Schema '{0}' with {1} fields", InternalName, Fields.Count);
        }

        #endregion

        #region INTERNAL METHODS

        /// <summary>
        /// Initializes a new instance of this class (used by the constructor).
        /// </summary>
        /// <param name="fields"></param>
        private void Initialize(IEnumerable<Field> fields = null)
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
