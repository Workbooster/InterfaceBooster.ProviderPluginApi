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

            // reset everything
            Clear();

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

        /// <summary>
        /// Gets the field value and casts it to the given type.
        /// If the value is null the <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldIndex"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValue<T>(int fieldIndex, T defaultValue = default(T))
        {
            var value = this[fieldIndex];
            if (value == null)
                return defaultValue;
            else
                return (T)value;
        }

        /// <summary>
        /// Gets the field value and casts it to the given type.
        /// If the value is null the <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldIndex"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValue<T>(string fieldName, T defaultValue = default(T))
        {
            var value = this[fieldName];
            if (value == null)
                return defaultValue;
            else
                return (T)value;
        }

        /// <summary>
        /// Checks whether the given field exists and gets the field value and casts it to the given type.
        /// If the field doesn't exists or the value is null the <paramref name="defaultValue"/> is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string fieldName, T defaultValue = default(T))
        {
            int fieldIndex = _Schema.FindIndexOfFieldByName(fieldName);

            if (fieldIndex == -1)
                return defaultValue;

            var value = this[fieldIndex];
            if (value == null)
                return defaultValue;
            else
                return (T)value;
        }

        /// <summary>
        /// Gets the field value and casts it to a nullable instance of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldIndex"></param>
        /// <returns></returns>
        public T? GetNullableValue<T>(int fieldIndex) where T : struct
        {
            var value = this[fieldIndex];
            if (value == null)
                return null;
            else
                return (T)value;
        }

        /// <summary>
        /// Gets the field value and casts it to a nullable instance of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public T? GetNullableValue<T>(string fieldName) where T : struct
        {
            var value = this[fieldName];
            if (value == null)
                return null;
            else
                return (T)value;
        }

        /// <summary>
        /// Checks whether the given field exists and gets the field value and casts it to a nullable instance of the given type.
        /// If the field wasn't found NULL is returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public T? GetNullableValueOrDefault<T>(string fieldName) where T : struct
        {
            int fieldIndex = _Schema.FindIndexOfFieldByName(fieldName);

            if (fieldIndex == -1)
                return null;

            var value = this[fieldIndex];

            if (value == null)
                return null;
            else
                return (T)value;
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
            _Data = new object[Schema.Fields.Count];
        }

        public bool Contains(object value)
        {
            return IndexOf(value) != -1 ? true : false;
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                // check for null value
                if (value == null)
                {
                    if (_Data[i] == null)
                    {
                        return i;
                    }
                }
                else
                {
                    // compare with equals method
                    if (value.Equals(_Data[i]))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((_CurrentAddPosition + 1 <= Count) && (index < Count) && (index >= 0))
            {
                for (int i = Count - 1; i > index; i--)
                {
                    SetValue(i, _Data[i - 1], true);
                }

                SetValue(index, value, true);

                // overwrite current position
                _CurrentAddPosition = index + 1;
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
                return _Data.Length;
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
            }

            for (int i = 0; i < Schema.Fields.Count; i++)
            {
                object value = data[i];
                SetValue(i, value, validate);
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

            if (index >= _CurrentAddPosition)
            {
                // update current position
                _CurrentAddPosition = index + 1;
            }

            _Data[index] = value;
        }

        #endregion
    }
}
