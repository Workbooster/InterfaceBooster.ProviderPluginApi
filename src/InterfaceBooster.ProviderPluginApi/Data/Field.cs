using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// A data field of a Schema. In combination with a RecordSet object a field represents a column.
    /// The "Data" namespace contains some interfaces that are used to describe the data structures that are exchanged between
    /// the Provider Plugin and the Interface Booster. Based on that information the Interface Booster is able to show the 
    /// interface developer all available structures, which can be used to perform a request using the Provider Plugin Connection.
    /// </summary>
    [Serializable]
    [XmlRoot("Field")]
    public class Field
    {
        #region MEMBERS

        private Type _Type;
        private LocalizedText _Description;
        private bool _IsNullable = true;
        private bool _IsKey = false;
        private bool _IsForeignKey = false;
        private LocalizedText _ForeignKeyDescription;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets the identifying name of the field used in Synery.
        /// It may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the data type of the field.
        /// </summary>
        [XmlIgnore]
        public Type Type
        {
            get { return _Type; }
            set
            {
                if (_Type != null && _Type != value)
                    throw new ArgumentException("It is not allowed to change the type of a field.");

                _Type = value;
            }
        }

        /// <summary>
        /// Gets or sets the assembly qualified name of "Type"
        /// (is only used for XML serialization)
        /// </summary>
        [XmlAttribute("Type")]
        public string TypeQualifiedName
        {
            get { return Type == null ? null : Type.AssemblyQualifiedName; }
            set { Type = string.IsNullOrEmpty(value) ? null : Type.GetType(value); }
        }

        /// <summary>
        /// Gets or sets the schema this field is related to.
        /// </summary>
        [XmlIgnore]
        public Schema Schema { get; set; }

        /// <summary>
        /// Gets or sets an user friendly and localizable description about this Field. 
        /// </summary>
        [XmlElement("Description")]
        public LocalizedText Description
        {
            get
            {
                if (_Description == null) _Description = new LocalizedText();
                return _Description;
            }
            set { _Description = value; }
        }

        /// <summary>
        /// Gets or sets an internal name used by the Provider Plugin to internaly identify the Field (e.g. the table name).
        /// (You can use it or not - this value isn't touched by Interface Booster in any way).
        /// </summary>
        [XmlAttribute("InternalName")]
        public string InternalName { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicates whether the field is required. Required = false
        /// </summary>
        [XmlAttribute("IsNullable")]
        public bool IsNullable { get { return _IsNullable; } set { _IsNullable = value; } }

        /// <summary>
        /// Gets or sets a flag that indicates whether the field is a key.
        /// This is NOT used for validation! It only is used 
        /// </summary>
        [XmlAttribute("IsKey")]
        public bool IsKey { get { return _IsKey; } set { _IsKey = value; } }

        /// <summary>
        /// Gets or sets a flag that indicates whether this field is a foreign key to another record set.
        /// </summary>
        [XmlAttribute("IsForeignKey")]
        public bool IsForeignKey { get { return _IsForeignKey; } set { _IsForeignKey = value; } }

        /// <summary>
        /// Gets or sets a human readable description of the foreign key (only if this field is contains a foreign key).
        /// </summary>
        [XmlElement("ForeignKeyDescription")]
        public LocalizedText ForeignKeyDescription
        {
            get
            {
                if (_ForeignKeyDescription == null) _ForeignKeyDescription = new LocalizedText();
                return _ForeignKeyDescription;
            }
            set { _ForeignKeyDescription = value; }
        }

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Is used for XML serialization.
        /// </summary>
        private Field() { }

        public Field(string name, Type type, bool isNullable = true)
        {
            Name = name;
            Type = type;
            _IsNullable = isNullable;
        }

        public static Field New<T>(string name, bool isNullable = true, string internalName = null, string description = null)
        {
            Field f = new Field(name, typeof(T));

            f.IsNullable = isNullable;
            f.InternalName = internalName;

            if (description != null) f.Description = description;

            return f;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Name, Type.Name);
        }

        #endregion
    }
}
