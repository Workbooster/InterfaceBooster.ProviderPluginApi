using InterfaceBooster.ProviderPluginApi.ErrorHandling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    public class Record : IEnumerable, IList
    {
        #region MEMBERS

        private object[] _Data;
        private int _CurrentAddPosition;
        private Schema _Schema;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the schema containing the field definitions for this record.
        /// </summary>
        public Schema Schema
        {
            get { return _Schema; }
        }

        /// <summary>
        /// Gets or sets all the values for this record through an array.
        /// </summary>
        public object[] ItemArray
        {
            get
            {
                return _Data;
            }
            set
            {
                SetData(value, true);
            }
        }

        #endregion

        #region PUBLIC METHODS

        public Record(Schema schema, object[] data = null)
        {
            if (schema == null)
                throw new ArgumentNullException("schema");

            _Schema = schema;
            _CurrentAddPosition = 0;
            _Data = new object[Schema.Fields.Count];

            if (data != null)
            {
                SetData(data, true);
            }
        }

        /// <summary>
        /// Converts a record into an ordinary object-array. The schema gets lost.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static implicit operator object[](Record record)
        {
            return record._Data;
        }

        #region INDEXERS

        public object this[string fieldName]
        {
            get
            {
                int fieldIndex = _Schema.FindIndexOfFieldByName(fieldName);

                if (fieldIndex == -1)
                    throw new Exception(String.Format(
                        "No field with name '{0}' found in Record Set '{1}'.", fieldName, _Schema.InternalName));

                return _Data[fieldIndex];
            }
            set
            {
                int fieldIndex = _Schema.FindIndexOfFieldByName(fieldName);

                if (fieldIndex == -1)
                    throw new Exception(String.Format(
                        "No field with name '{0}' found in Record Set '{1}'.", fieldName, _Schema.InternalName));

                SetValue(fieldIndex, value, true);
            }
        }

        #endregion

        #region IMPLEMENTATION OF IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        #endregion

        #region IMPLEMENTATION OF IList

        public object this[int index]
        {
            get
            {
                return _Data[index];
            }
            set
            {
                SetValue(index, value, true);
            }
        }

        public int Add(object value)
        {
            if (_CurrentAddPosition < _Data.Length)
            {
                SetValue(_CurrentAddPosition, value, true);
                _CurrentAddPosition++;

                return (_CurrentAddPosition - 1);
            }
            else
            {
                return -1;
            }
        }

        public void Clear()
        {
            _CurrentAddPosition = 0;
        }

        public bool Contains(object value)
        {
            bool inList = false;
            for (int i = 0; i < Count; i++)
            {
                if (_Data[i] == value)
                {
                    inList = true;
                    break;
                }
            }
            return inList;
        }

        public int IndexOf(object value)
        {
            int itemIndex = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_Data[i] == value)
                {
                    itemIndex = i;
                    break;
                }
            }
            return itemIndex;
        }

        public void Insert(int index, object value)
        {
            if ((_CurrentAddPosition + 1 <= _Data.Length) && (index < Count) && (index >= 0))
            {
                _CurrentAddPosition++;

                for (int i = Count - 1; i > index; i--)
                {
                    SetValue(i, _Data[i - 1], true);
                }
                SetValue(index, value, true);
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    SetValue(i, _Data[i + 1], true);
                }

                _Data = _Data.Take(Count - 1).ToArray();

                _CurrentAddPosition--;
            }
        }

        #endregion

        #region IMPLEMENTATION OF ICollection

        public void CopyTo(Array array, int index)
        {
            int j = index;
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_Data[i], j);
                j++;
            }
        }

        public int Count
        {
            get
            {
                return _CurrentAddPosition;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                // Return the current instance since the underlying store is not publicly available. 
                return this;
            }
        }

        #endregion

        #endregion

        #region INTERNAL METHODS

        /// <summary>
        /// Stores the given data internally.
        /// </summary>
        /// <param name="data"></param>
        private void SetData(object[] data, bool validate)
        {
            if (validate == true)
            {
                if (data.Count() != Schema.Fields.Count)
                {
                    throw new Exception(String.Format(
                        "The schema '{0}' ({1} fields) doesn't have the same size as the given array ({2} values).",
                        Schema.InternalName, Schema.Fields.Count, data.Count()));
                }

                for (int i = 0; i < Schema.Fields.Count; i++)
                {
                    object value = data[i];
                    SetValue(i, value, true);
                    _CurrentAddPosition++;
                }
            }
        }

        private void SetValue(int index, object value, bool validate)
        {
            Field field = Schema.Fields[index];

            if (validate)
            {
                if (value != null)
                { 
                    if (value.GetType() != field.Type)
                    {
                        throw new RecordSetException(Schema, String.Format(
                            "Datatype missmatch. The field '{0}' expects a value of type '{1}'. Type given: '{2}'.",
                            field.Name, field.Type.Name, value.GetType().Name));
                    }
                }
                else
                {
                    if (field.IsNullable == false)
                    {
                        throw new RecordSetException(Schema, String.Format(
                            "NULL value not allowed. The field '{0}' expects a value of type '{1}'.",
                            field.Name, field.Type.Name));
                    }
                }
            }

            _Data[index] = value;
        }

        #endregion
    }
}
