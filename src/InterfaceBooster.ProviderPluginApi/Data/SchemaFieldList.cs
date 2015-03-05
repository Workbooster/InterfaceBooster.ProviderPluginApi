using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    [Serializable]
    public class SchemaFieldList : List<Field>
    {
        #region DELEGATES

        public delegate void FieldAddedEventHandler(SchemaFieldList list, Field field);

        #endregion

        #region EVENTS

        /// <summary>
        /// Occures if a new field has been added to the field list.
        /// </summary>
        public event FieldAddedEventHandler FieldAdded;

        #endregion

        #region PUBLIC METHODS

        public SchemaFieldList() : base() { }

        #region OVERWRITE List<Field>

        public new Field this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
                PerformFieldAddedCallback(value);
            }
        }
        
        public new void AddRange(IEnumerable<Field> listOfFields)
        {
            base.AddRange(listOfFields);

            foreach (var field in listOfFields)
            {
                PerformFieldAddedCallback(field);
            }
        }

        public new void Add(Field field)
        {
            base.Add(field);
            PerformFieldAddedCallback(field);
        }

        public new void Insert(int index, Field field)
        {
            base.Insert(index, field);
            PerformFieldAddedCallback(field);
        }

        public new void InsertRange(int index, IEnumerable<Field> listOfFields)
        {
            base.InsertRange(index, listOfFields);

            foreach (var field in listOfFields)
            {
                PerformFieldAddedCallback(field);
            }
        }

        #endregion

        #endregion

        #region INTERNAL METHODS

        private void PerformFieldAddedCallback(Field field)
        {
            if (FieldAdded != null)
                FieldAdded(this, field);
        }

        #endregion
    }
}
