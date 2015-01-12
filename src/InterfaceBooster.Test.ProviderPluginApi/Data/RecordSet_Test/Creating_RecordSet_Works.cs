using InterfaceBooster.ProviderPluginApi.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.RecordSet_Test
{
    [TestFixture]
    public class Creating_RecordSet_Works
    {
        [Test]
        public void Creating_Empty_Record_Set_Works()
        {
            Schema schema = new Schema();

            schema.Fields.Add(Field.New<int>("Id"));
            schema.Fields.Add(Field.New<string>("Name"));

            RecordSet recordSet = new RecordSet(schema);

            Assert.IsInstanceOf<Schema>(recordSet.Schema);
        }
    }
}
