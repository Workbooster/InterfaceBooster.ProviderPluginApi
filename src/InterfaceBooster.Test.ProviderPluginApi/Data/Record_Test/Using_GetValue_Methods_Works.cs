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
    public class Using_GetValue_Methods_Works
    {
        private Schema _Schema;
        private Record _Record;

        [SetUp]
        public void SetupTest()
        {
            _Schema = new Schema();

            _Schema.Fields.Add(Field.New<int>("Id"));
            _Schema.Fields.Add(Field.New<string>("Name"));
            _Schema.Fields.Add(Field.New<bool>("IsMarried"));
            _Schema.Fields.Add(Field.New<bool>("IsMale"));
            _Schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));
            _Schema.Fields.Add(Field.New<DateTime>("DateOfDeath"));

            _Record = new Record(_Schema);

            _Record[0] = 15;
            _Record[1] = "Max";
            _Record[2] = null;
            _Record[3] = true;
            _Record[4] = new DateTime(1982, 11, 5);
            _Record[5] = null;
        }

        [Test]
        public void Test_GetValue_With_FieldIndex_Works()
        {
            Assert.AreEqual("Max", _Record.GetValue<string>(1));
            Assert.AreEqual(new DateTime(1982, 11, 5), _Record.GetValue<DateTime>(4));
        }

        [Test]
        public void Test_GetValue_With_FieldName_Works()
        {
            Assert.AreEqual("Max", _Record.GetValue<string>("Name"));
            Assert.AreEqual(new DateTime(1982, 11, 5), _Record.GetValue<DateTime>("DateOfBirth"));
        }

        [Test]
        public void Test_GetValueOrDefault_On_Existing_Fields_Works()
        {
            Assert.AreEqual("Max", _Record.GetValueOrDefault<string>("Name"));
            Assert.AreEqual(new DateTime(1982, 11, 5), _Record.GetValueOrDefault<DateTime>("DateOfBirth"));
        }

        [Test]
        public void Test_GetValueOrDefault_On_Unknown_Fields_Works()
        {
            Assert.AreEqual(default(string), _Record.GetValueOrDefault<string>("UnknownField"));
            Assert.AreEqual(default(DateTime), _Record.GetValueOrDefault<DateTime>("UnknownField"));
            Assert.AreEqual("MyDefault", _Record.GetValueOrDefault<string>("UnknownField", "MyDefault"));
            Assert.AreEqual(new DateTime(1987, 12, 15), _Record.GetValueOrDefault<DateTime>("UnknownField", new DateTime(1987, 12, 15)));
        }

        [Test]
        public void Test_GetNullableValue_With_FieldIndex_On_Existing_Fields_Works()
        {
            Assert.AreEqual(null, _Record.GetNullableValue<bool>(2));
            Assert.AreEqual(null, _Record.GetNullableValue<DateTime>(5));
        }

        [Test]
        public void Test_GetNullableValue_With_FieldName_On_Existing_Fields_Works()
        {
            Assert.AreEqual(null, _Record.GetNullableValue<bool>("IsMarried"));
            Assert.AreEqual(null, _Record.GetNullableValue<DateTime>("DateOfDeath"));
        }

        [Test]
        public void Test_GetNullableValueOrDefault_On_Unknown_Fields_Works()
        {
            Assert.AreEqual(null, _Record.GetNullableValueOrDefault<DateTime>("UnknownField"));
            Assert.AreEqual(null, _Record.GetNullableValueOrDefault<bool>("UnknownField"));
        }
    }
}
