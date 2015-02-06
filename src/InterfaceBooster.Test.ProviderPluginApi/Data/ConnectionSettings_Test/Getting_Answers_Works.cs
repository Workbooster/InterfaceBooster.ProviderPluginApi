using InterfaceBooster.ProviderPluginApi.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.ConnectionSettings_Test
{
    [TestFixture]
    public class Getting_Answers_Works
    {
        private ConnectionSettings _Settings;

        [SetUp]
        public void SetupTest()
        {
            _Settings = new ConnectionSettings();

            // add the test questions/answers

            _Settings.Answers.Add(
                new Answer(
                    Question.New<string>("Test1", new string[] { "First", "Second" }, true)
                    , "Test-Value-1"));

            _Settings.Answers.Add(
                new Answer(
                    Question.New<string>("Test2", new string[] { "First", "Second" }, true)
                    , "Test-Value-2"));

            _Settings.Answers.Add(
                new Answer(
                    Question.New<string>("Test3", new string[] { "First", "Second" }, true)
                    , "Test-Value-3"));

            // add some other questions/answers with the same names but different paths and values
            // this is to avoid chance hits

            _Settings.Answers.Add(
                new Answer(
                    Question.New<string>("Test1", new string[] { "One", "Two" }, true)
                    , "Different-Test-Value-1"));

            _Settings.Answers.Add(
                new Answer(
                    Question.New<string>("Test2", new string[] { "One", "Two" }, true)
                    , "Different-Test-Value-2"));

            _Settings.Answers.Add(
                new Answer(
                    Question.New<string>("Test3", new string[] { "One", "Two" }, true)
                    , "Different-Test-Value-3"));
        }

        [Test]
        public void Getting_Answer_Works()
        {
            string testValue = _Settings.GetAnswerValue<string>("First.Second.Test2");

            Assert.AreEqual("Test-Value-2", testValue);
        }

        [Test]
        public void Getting_DefaultValue_Works()
        {
            string testValue = _Settings.GetAnswerValue<string>("Some.Wrong.Value.Test", "test-default");

            Assert.AreEqual("test-default", testValue);
        }

        [Test]
        public void Getting_Answer_With_Non_Default_PathSeparator_Works()
        {
            string testValue = _Settings.GetAnswerValue<string>("First_Second_Test2", pathSeparator: '_');

            Assert.AreEqual("Test-Value-2", testValue);
        }
    }
}
