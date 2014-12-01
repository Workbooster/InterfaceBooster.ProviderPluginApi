using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// A data field of a Schema. In combination with a RecordSet object a field represents a column.
    /// The "Data" namespace contains some interfaces that are used to describe the data structures that are exchanged between
    /// the Provider Plugin and the Interface Booster. Based on that information the Interface Booster is able to show the 
    /// interface developer all available structures, which can be used to perform a request using the Provider Plugin Connection.
    /// </summary>
    public class Field
    {
        #region MEMBERS

        private bool _IsNullable = true;
        private bool _IsKey = false;
        private bool _IsForeignKey = false;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the identifying name of the field used in Synery.
        /// It may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the data type of the field.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets or sets an user friendly and localizable description about this Field. 
        /// </summary>
        public LocalizedText Description { get; set; }

        /// <summary>
        /// Gets or sets an internal name used by the Provider Plugin to internaly identify the Field (e.g. the table name).
        /// (You can use it or not - this value isn't touched by Interface Booster in any way).
        /// </summary>
        public string InternalName { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicates whether the field is required. Required = false
        /// </summary>
        public bool IsNullable { get { return _IsNullable; } set { _IsNullable = value; } }

        /// <summary>
        /// Gets or sets a flag that indicates whether the field is a key.
        /// This is NOT used for validation! It only is used 
        /// </summary>
        public bool IsKey { get { return _IsKey; } set { _IsKey = value; } }
        public bool IsForeignKey { get { return _IsForeignKey; } set { _IsForeignKey = value; } }
        public LocalizedText ForeignKeyDescription { get; set; }

        #endregion

        #region PUBLIC METHODS

        public Field(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        #endregion
    }
}
