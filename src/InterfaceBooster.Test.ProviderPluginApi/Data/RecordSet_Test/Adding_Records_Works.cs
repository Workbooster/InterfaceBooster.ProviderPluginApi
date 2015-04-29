using InterfaceBooster.ProviderPluginApi.Data;
using InterfaceBooster.ProviderPluginApi.ErrorHandling;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.RecordSet_Test
{
    [TestFixture]
    public class Adding_Records_Works
    {
        private RecordSet _ExistingRecordSet;

        [SetUp]
        public void SetupTest()
        {
            // create a record set with 2 fields

            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));

            _ExistingRecordSet = new RecordSet(schema);
        }

        [Test]
        public void Adding_Existing_Records_Using_Add_Method_Works()
        {
            // create new record instances and use the "Add" method of the record set to add the records

            _ExistingRecordSet.Add(new Record(_ExistingRecordSet.Schema, new object[] { 1, "Mike" }));
            _ExistingRecordSet.Add(new Record(_ExistingRecordSet.Schema, new object[] { 2, "Molly" }));

            Assert.AreEqual(2, _ExistingRecordSet.Count);
            Assert.AreEqual("Mike", _ExistingRecordSet.Where(r => (int)r["Id"] == 1).Select(r => r["Name"]).First());
            Assert.AreEqual("Molly", _ExistingRecordSet.Where(r => (int)r["Id"] == 2).Select(r => r["Name"]).First());
        }

        [Test]
        public void Adding_New_Records_Using_NewRecord_Method_Works()
        {
            // use the record sets "NewRecord" method to add the records

            _ExistingRecordSet.AppendRecord(1, "Mike");
            _ExistingRecordSet.AppendRecord(2, "Molly");

            Assert.AreEqual(2, _ExistingRecordSet.Count);
            Assert.AreEqual("Mike", _ExistingRecordSet.Where(r => (int)r["Id"] == 1).Select(r => r["Name"]).First());
            Assert.AreEqual("Molly", _ExistingRecordSet.Where(r => (int)r["Id"] == 2).Select(r => r["Name"]).First());
        }

        public void Adding_New_Record_With_Different_Schema_Throws_Exception()
        {
            // create a new schema instance with the same fields as the original schema

            Schema differentSchema = new Schema();

            differentSchema.Fields.Add(Field.New<int>("Id"));
            differentSchema.Fields.Add(Field.New<string>("Name"));

            // create a record with a schema that is not the schema used by the record set

            Record recordWithDifferentSchema = new Record(differentSchema, new object[] { 1, "Mike" });

            // Try to assign the record to the existing record set.
            // It is expected that this is not allowed to avoid problems when changing the schema (e.g. removing a field).
            // It is important that both the record set and the records reference the same schema.

            Assert.Throws<RecordSetException>(delegate { _ExistingRecordSet.Add(recordWithDifferentSchema); });
        }
    }
}
