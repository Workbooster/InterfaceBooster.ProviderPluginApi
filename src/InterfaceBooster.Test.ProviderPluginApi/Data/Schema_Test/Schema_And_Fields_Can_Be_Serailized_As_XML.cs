using InterfaceBooster.ProviderPluginApi.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.Schema_Test
{
    [TestFixture]
    public class Schema_And_Fields_Can_Be_Serailized_As_XML
    {
        private Schema _Schema;

        private string _Xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Schema xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Description Default=\"\"><Translations /></Description><Fields><Field Name=\"Id\" Type=\"System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" InternalName=\"MyID\" IsNullable=\"false\" IsKey=\"false\" IsForeignKey=\"false\"><Description Default=\"ID\"><Translations><Translation LanguageCode=\"en\">Identifier</Translation><Translation LanguageCode=\"de\">Identifikator</Translation></Translations></Description><ForeignKeyDescription Default=\"\"><Translations /></ForeignKeyDescription></Field><Field Name=\"IdType\" Type=\"System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" InternalName=\"MyIDType\" IsNullable=\"false\" IsKey=\"false\" IsForeignKey=\"true\"><Description Default=\"ID\"><Translations><Translation LanguageCode=\"en\">Type Identifier</Translation><Translation LanguageCode=\"de\">Typen Identifikator</Translation></Translations></Description><ForeignKeyDescription Default=\"IDType\"><Translations /></ForeignKeyDescription></Field><Field Name=\"Name\" Type=\"System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" IsNullable=\"true\" IsKey=\"false\" IsForeignKey=\"false\"><Description Default=\"\"><Translations /></Description><ForeignKeyDescription Default=\"\"><Translations /></ForeignKeyDescription></Field><Field Name=\"IsMale\" Type=\"System.Boolean, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" IsNullable=\"true\" IsKey=\"false\" IsForeignKey=\"false\"><Description Default=\"\"><Translations /></Description><ForeignKeyDescription Default=\"\"><Translations /></ForeignKeyDescription></Field><Field Name=\"DateOfBirth\" Type=\"System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" IsNullable=\"true\" IsKey=\"false\" IsForeignKey=\"false\"><Description Default=\"\"><Translations /></Description><ForeignKeyDescription Default=\"\"><Translations /></ForeignKeyDescription></Field></Fields></Schema>";

        [SetUp]
        public void Setup()
        {
            _Schema = new Schema();

            Field id = Field.New<int>("Id", false, "MyID");
            id.Description.Default = "ID";
            id.Description.Add("en", "Identifier");
            id.Description.Add("de", "Identifikator");
            id.IsNullable = false;

            Field idType = Field.New<int>("IdType", false, "MyIDType");
            idType.Description.Default = "ID";
            idType.Description.Add("en", "Type Identifier");
            idType.Description.Add("de", "Typen Identifikator");
            idType.IsNullable = false;
            idType.IsForeignKey = true;
            idType.ForeignKeyDescription.Default = "IDType";


            _Schema.Fields.Add(id);
            _Schema.Fields.Add(idType);
            _Schema.Fields.Add(Field.New<string>("Name"));
            _Schema.Fields.Add(Field.New<bool>("IsMale"));
            _Schema.Fields.Add(Field.New<DateTime>("DateOfBirth"));
        }

        [Test]
        public void Serializing_Schema_As_XML_Works()
        {
            StringBuilder sb = new StringBuilder();

            using (XmlWriter xmlWriter = XmlWriter.Create(sb, new XmlWriterSettings() { /*Indent = true, NewLineHandling = NewLineHandling.Entitize*/ }))
            {
                XmlSerializer s = new XmlSerializer(_Schema.GetType());
                s.Serialize(xmlWriter, _Schema);
            }

            string generatedXml = sb.ToString();

            Assert.AreEqual(_Xml, generatedXml);
        }

        [Test]
        public void Deserializing_Schema_From_XML_Works()
        {
            Schema schema;            

            XmlSerializer s = new XmlSerializer(typeof(Schema));

            using (StringReader stringReader = new StringReader(_Xml))
            {
                schema = (Schema)s.Deserialize(stringReader);
            }

            Assert.AreEqual(_Schema.InternalName, schema.InternalName);
            Assert.AreEqual(_Schema.Description.Default, schema.Description.Default);
            Assert.AreEqual(_Schema.Fields.Count, schema.Fields.Count);

            for (int i = 0; i < _Schema.Fields.Count; i++)
            {
                Assert.AreEqual(_Schema.Fields[i].Name, schema.Fields[i].Name);
                Assert.AreEqual(_Schema.Fields[i].InternalName, schema.Fields[i].InternalName);
                Assert.AreEqual(_Schema.Fields[i].Type, schema.Fields[i].Type);
                Assert.AreEqual(_Schema.Fields[i].IsNullable, schema.Fields[i].IsNullable);
                Assert.AreEqual(_Schema.Fields[i].IsKey, schema.Fields[i].IsKey);
                Assert.AreEqual(_Schema.Fields[i].IsForeignKey, schema.Fields[i].IsForeignKey);
                Assert.IsTrue(_Schema.Fields[i].ForeignKeyDescription.Equals(schema.Fields[i].ForeignKeyDescription));
                Assert.IsTrue(_Schema.Fields[i].Description.Equals(schema.Fields[i].Description));
            }
        }

        public void Deserialization_Of_LocalizedText_Fields_Without_Transalations_Node_Works()
        {
            Schema schema;
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Schema xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Description Default=\"\"></Description><Fields><Field Name=\"Name\" Type=\"System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\" IsNullable=\"true\" IsKey=\"false\" IsForeignKey=\"false\"><Description Default=\"Some description\"></Description><ForeignKeyDescription Default=\"\"><Translations /></ForeignKeyDescription></Field></Fields></Schema>";

            XmlSerializer s = new XmlSerializer(typeof(Schema));

            using (StringReader stringReader = new StringReader(xml))
            {
                schema = (Schema)s.Deserialize(stringReader);
            }

            Assert.AreEqual(1, schema.Fields.Count);
            Assert.AreEqual("Some description", schema.Fields[0].Description.Default);
        }
    }
}
