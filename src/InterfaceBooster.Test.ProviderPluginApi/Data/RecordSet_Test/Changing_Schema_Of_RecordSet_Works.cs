using InterfaceBooster.ProviderPluginApi.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.RecordSet_Test
{
    public class Changing_Schema_Of_RecordSet_Works
    {
        private RecordSet _ExistingRecordSet;

        [SetUp]
        public void SetupTest()
        {
            // create a record set with 4 fields and add two rows

            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<string>("Street"));
            schema.Fields.Add(Field.New<string>("City"));

            _ExistingRecordSet = new RecordSet(schema);

            _ExistingRecordSet.AppendRecord(1, "Mike", "Main Avenue 15", "Somecity");
            _ExistingRecordSet.AppendRecord(2, "Molly", "Sixt Street 12", "Anothercity");
        }

        [Test]
        public void Removing_Field_By_Reference_Works()
        {
            Field streetField = _ExistingRecordSet.Schema.Fields.Where(f => f.Name == "Street").First();

            _ExistingRecordSet.RemoveField(streetField);

            // check number of fields in schema
            Assert.AreEqual(3, _ExistingRecordSet.Schema.Fields.Count);

            // check number of fields in records
            Assert.AreEqual(3, _ExistingRecordSet[0].Count);
            Assert.AreEqual(3, _ExistingRecordSet[1].Count);

            // check the correct values can be accessed by using the row index and the field name
            Assert.AreEqual(2, _ExistingRecordSet[1, "Id"]);
            Assert.AreEqual("Molly", _ExistingRecordSet[1, "Name"]);
            Assert.AreEqual("Anothercity", _ExistingRecordSet[1, "City"]);

            // check the correct values can be accessed by using the row index and the field index
            Assert.AreEqual(2, _ExistingRecordSet[1].ItemArray[0]);
            Assert.AreEqual("Molly", _ExistingRecordSet[1].ItemArray[1]);
            Assert.AreEqual("Anothercity", _ExistingRecordSet[1].ItemArray[2]);

            // check whether the records counter has been set right
            Assert.AreEqual(3, _ExistingRecordSet[1].Count);
        }
    }
}
