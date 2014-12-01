using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// A record set is a container for transferring data from the Provider Plugin to the Interface Booster or vice versa. 
    /// It implements the IList interface. A record set is comparable to a table with some columns and some rows. 
    /// The definition of the columns is represented by a list of fields in the related Schema. The record set consists of 
    /// a list of object-arrays. Each object-array represents one row. The size of the object-array and the number of fields 
    /// in the Schema must always be equal. The specified data type in the schema fields must also match the data type of 
    /// the corresponding items from the object-arrays.
    /// </summary>
    public class RecordSet : IList<object[]>
    {
        #region MEMBERS

        private IList<object[]> _Data;

        #endregion

        /// <summary>
        /// Gets the schema of the record set.
        /// </summary>
        public Schema Schema { get; private set; }

        #region PUBLIC METHODS

        /// <summary>
        /// A record set is a container for transferring data from the Provider Plugin to the Interface Booster or vice versa. 
        /// It implements the IList interface. A record set is comparable to a table with some columns and some rows. 
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="data"></param>
        public RecordSet(Schema schema, IEnumerable<object[]> data = null)
        {
            Schema = schema;

            if (data == null)
            {
                _Data = new List<object[]>();
            }
            else
            {
                _Data = new List<object[]>(data);
            }
        }

        /// <summary>
        /// Sets the data of the record set.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(IEnumerable<object[]> data)
        {
            _Data = new List<object[]>(data);
        }

        #region IMPLEMENTATION OF IList<object[]>

        public int IndexOf(object[] item)
        {
            return _Data.IndexOf(item);
        }

        public void Insert(int index, object[] item)
        {
            _Data.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _Data.RemoveAt(index);
        }

        public object[] this[int index]
        {
            get
            {
                return _Data[index];
            }
            set
            {
                _Data[index] = value;
            }
        }

        public void Add(object[] item)
        {
            _Data.Add(item);
        }

        public void Clear()
        {
            _Data.Clear();
        }

        public bool Contains(object[] item)
        {
            return _Data.Contains(item);
        }

        public void CopyTo(object[][] array, int arrayIndex)
        {
            _Data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _Data.Count; }
        }

        public bool IsReadOnly
        {
            get { return _Data.IsReadOnly; }
        }

        public bool Remove(object[] item)
        {
            return _Data.Remove(item);
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        #endregion

        #endregion
    }
}
