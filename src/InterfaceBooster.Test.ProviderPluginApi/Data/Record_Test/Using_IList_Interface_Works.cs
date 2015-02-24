using InterfaceBooster.ProviderPluginApi.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.Record_Test
{
    [TestFixture]
    public class Using_IList_Interface_Works
    {
        [SetUp]
        public void SetupTest()
        {
            
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<string>("Street"));
            schema.Fields.Add(Field.New<string>("City"));

        }

        [Test]
        public void Setting_And_Getting_Values_By_Indexer_Works()
        {
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<bool>("IsMale"));
            schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));

            Record record = new Record(schema);

            record[0] = 15;
            record[1] = "Max";
            record[2] = true;
            record[3] = new DateTime(1982, 11, 5);

            Assert.AreEqual(15, record[0]);
            Assert.AreEqual("Max", record[1]);
            Assert.AreEqual(true, record[2]);
            Assert.AreEqual(new DateTime(1982, 11, 5), record[3]);
        }

        [Test]
        public void Setting_And_Getting_Values_By_Field_Name_Works()
        {
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<bool>("IsMale"));
            schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));

            Record record = new Record(schema);

            record["Id"] = 15;
            record["Name"] = "Max";
            record["IsMale"] = true;
            record["DateOfBirth"] = new DateTime(1982, 11, 5);

            Assert.AreEqual(15, record["Id"]);
            Assert.AreEqual("Max", record["Name"]);
            Assert.AreEqual(true, record["IsMale"]);
            Assert.AreEqual(new DateTime(1982, 11, 5), record["DateOfBirth"]);
        }

        [Test]
        public void Setting_Values_With_Add_Works()
        {
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<bool>("IsMale"));
            schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));

            Record record = new Record(schema);

            record.Add(15);
            record.Add("Max");
            record.Add(true);
            record.Add(new DateTime(1982, 11, 5));

            Assert.AreEqual(15, record[0]);
            Assert.AreEqual("Max", record[1]);
            Assert.AreEqual(true, record[2]);
            Assert.AreEqual(new DateTime(1982, 11, 5), record[3]);
        }

        [Test]
        public void Setting_Values_With_Insert_Works()
        {
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<bool>("IsMale"));
            schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));

            Record record = new Record(schema);

            record.Insert(0, 15);
            record.Insert(1, "Max");
            record.Insert(2, true);
            record.Insert(3, new DateTime(1982, 11, 5));

            Assert.AreEqual(15, record[0]);
            Assert.AreEqual("Max", record[1]);
            Assert.AreEqual(true, record[2]);
            Assert.AreEqual(new DateTime(1982, 11, 5), record[3]);
        }

        [Test]
        public void Count_Returns_Always_The_Number_Of_Schema_Fields()
        {
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(Field.New<bool>("IsMale"));
            schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));

            Record record = new Record(schema);

            // should return the number of field even if no value has been set yet
            Assert.AreEqual(4, record.Count);

            // change a value
            record[1] = "Max";

            // should still return the number of fields
            Assert.AreEqual(4, record.Count);
        }

        [Test]
        public void Removing_Field_Works()
        {
            Field isMaleField = Field.New<bool>("IsMale");

            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));
            schema.Fields.Add(isMaleField);
            schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));

            Record record = new Record(schema);

            // set all values
            record[0] = 15;
            record[1] = "Max";
            record[2] = true;
            record[3] = new DateTime(1982, 11, 5);

            // remove the filed from the schema and the record
            schema.Fields.Remove(isMaleField);
            record.RemoveAt(2);

            // check value / position
            Assert.AreEqual(15, record[0]);
            Assert.AreEqual("Max", record[1]);
            Assert.AreEqual(new DateTime(1982, 11, 5), record[2]);
            
            // check field counter
            Assert.AreEqual(3, record.Count);
        }

    }
}
