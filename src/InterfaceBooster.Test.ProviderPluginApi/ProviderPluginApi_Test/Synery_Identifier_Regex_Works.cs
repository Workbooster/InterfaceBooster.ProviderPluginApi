using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.ProviderPluginApi_Test
{
    [TestFixture]
    public class Synery_Identifier_Regex_Works
    {
        [Test]
        public void Correc_Identifiers_Are_Valid()
        {
            Regex syneryIdentifierRegex = InterfaceBooster.ProviderPluginApi.ProviderPluginApi.SYNERY_IDENTIFIER_REGEX;

            Assert.IsTrue(syneryIdentifierRegex.IsMatch("test"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("TEST"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("ThisIsATest"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("_Test"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("Test1"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("The1Test"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("_1"));
            Assert.IsTrue(syneryIdentifierRegex.IsMatch("_"));
        }

        [Test]
        public void Incorret_Identifiers_Are_Detected_As_Invalid()
        {
            Regex syneryIdentifierRegex = InterfaceBooster.ProviderPluginApi.ProviderPluginApi.SYNERY_IDENTIFIER_REGEX;

            Assert.IsFalse(syneryIdentifierRegex.IsMatch(" "));
            Assert.IsFalse(syneryIdentifierRegex.IsMatch(" test"));
            Assert.IsFalse(syneryIdentifierRegex.IsMatch("1test"));
            Assert.IsFalse(syneryIdentifierRegex.IsMatch("te-st"));
            Assert.IsFalse(syneryIdentifierRegex.IsMatch("te*st"));
            Assert.IsFalse(syneryIdentifierRegex.IsMatch("te[st"));
            Assert.IsFalse(syneryIdentifierRegex.IsMatch("te]st"));
        }
    }
}
