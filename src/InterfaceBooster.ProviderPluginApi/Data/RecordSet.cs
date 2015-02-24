using InterfaceBooster.ProviderPluginApi.ErrorHandling;
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
    /// a list of Records. Each Record represents one row. The size of the Record and the number of fields 
    /// in the Schema must always be equal. The specified data type in the schema fields must also match the data type of 
    /// the corresponding items from the object-arrays.
    /// </summary>
    public class RecordSet : IList<Record>
    {
        #region MEMBERS

        private IList<Record> _Data;

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
        public RecordSet(Schema schema, IEnumerable<Record> data = null)
        {
            if (schema == null)
                throw new ArgumentNullException("schema");

            Schema = schema;

            if (data == null)
            {
                _Data = new List<Record>();
            }
            else
            {
                _Data = new List<Record>(data);
            }
        }

        /// <summary>
        /// A record set is a container for transferring data from the Provider Plugin to the Interface Booster or vice versa. 
        /// It implements the IList interface. A record set is comparable to a table with some columns and some rows. 
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="data">A list of object-arrays. The object-arrays are converted to a Record and must match the Schema.</param>
        public RecordSet(Schema schema, IEnumerable<object[]> data)
        {
            if (schema == null)
                throw new ArgumentNullException("schema");

            Schema = schema;
            _Data = new List<Record>();

            foreach (var item in data)
            {
                NewRecord(new Record(Schema, item));
            }
        }

        /// <summary>
        /// Sets the data of the record set.
        /// </summary>
        /// <param name="data"></param>
        public void SetData(IEnumerable<Record> data)
        {
            _Data = new List<Record>(data);
        }

        /// <summary>
        /// Creates and adds a new record and allows a fluid API like:
        /// rs.NewRecord(1, "bla").NewRecord(2, "aha").NewRecord(3, "ok");
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public RecordSet NewRecord(params object[] args)
        {
            Add(new Record(Schema, args));

            return this;
        }

        public RecordSet Clone()
        {
            Schema schema = this.Schema.Clone();
            RecordSet recordSet = new RecordSet(schema);

            foreach (var record in this)
            {
                recordSet.Add(new Record(schema, record.ItemArray));
            }

            return recordSet;
        }

        public void RemoveField(Field field)
        {
            int index = Schema.Fields.IndexOf(field);

            RemoveFieldAt(index);
        }

        public void RemoveFieldAt(int index)
        {
            if (index != -1)
            {
                Schema.Fields.RemoveAt(index);

                foreach (var record in _Data)
                {
                    record.RemoveAt(index);
                }
            }
        }

        /// <summary>
        /// Gets or sets a field value of a record on the given recordIndex and with the given fieldName.
        /// </summary>
        /// <param name="recordIndex"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public object this[int recordIndex, string fieldName]
        {
            get
            {
                if (recordIndex >= _Data.Count)
                    throw new IndexOutOfRangeException(String.Format(
                        "No record at index '{0}'. The Record Set '{1}' only has '{2}' record(s).", recordIndex, Schema.InternalName, _Data.Count));

                return _Data[recordIndex][fieldName];
            }
            set
            {
                if (recordIndex >= _Data.Count)
                    throw new IndexOutOfRangeException(String.Format(
                        "No record at index '{0}'. The Record Set '{1}' only has '{2}' record(s).", recordIndex, Schema.InternalName, _Data.Count));

                _Data[recordIndex][fieldName] = value;
            }
        }

        public override string ToString()
        {
            return String.Format("RecordSet '{0}' with {1} records and {2} fields", Schema.InternalName, _Data.Count, Schema.Fields.Count);
        }

        #region IMPLEMENTATION OF IList<Record>

        public int IndexOf(Record item)
        {
            return _Data.IndexOf(item);
        }

        public void Insert(int index, Record item)
        {
            _Data.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _Data.RemoveAt(index);
        }

        public Record this[int index]
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

        public void Add(Record item)
        {
            if (item.Schema != Schema)
                throw new RecordSetException(Schema, "The schema of the given record is different to the schema of the record set.");

            _Data.Add(item);
        }

        public void Clear()
        {
            _Data.Clear();
        }

        public bool Contains(Record item)
        {
            return _Data.Contains(item);
        }

        public void CopyTo(Record[] array, int arrayIndex)
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

        public bool Remove(Record item)
        {
            return _Data.Remove(item);
        }

        public IEnumerator<Record> GetEnumerator()
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
