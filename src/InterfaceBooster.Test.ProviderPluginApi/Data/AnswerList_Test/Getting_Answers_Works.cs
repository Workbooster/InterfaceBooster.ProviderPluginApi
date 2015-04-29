using InterfaceBooster.ProviderPluginApi.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.Test.ProviderPluginApi.Data.AnswerList_Test
{
    [TestFixture]
    public class Getting_Answers_Works
    {
        private AnswerList Answers;

        [SetUp]
        public void SetupTest()
        {
            Answers = new AnswerList();

            // add the test questions/answers

            Answers.Add(
                new Answer(
                    Question.New<string>("Test1", new string[] { "First", "Second" }, true)
                    , "Test-Value-1"));

            Answers.Add(
                new Answer(
                    Question.New<string>("Test2", new string[] { "First", "Second" }, true)
                    , "Test-Value-2"));

            Answers.Add(
                new Answer(
                    Question.New<string>("Test3", new string[] { "First", "Second" }, true)
                    , "Test-Value-3"));

            // add some other questions/answers with the same names but different paths and values
            // this is to avoid chance hits

            Answers.Add(
                new Answer(
                    Question.New<string>("Test1", new string[] { "One", "Two" }, true)
                    , "Different-Test-Value-1"));

            Answers.Add(
                new Answer(
                    Question.New<string>("Test2", new string[] { "One", "Two" }, true)
                    , "Different-Test-Value-2"));

            Answers.Add(
                new Answer(
                    Question.New<string>("Test3", new string[] { "One", "Two" }, true)
                    , "Different-Test-Value-3"));

            // add some questions with path = null

            Answers.Add(
                new Answer(
                    Question.New<string>("Test1", null, true)
                    , "NullPath-Test-Value-1"));

            Answers.Add(
                new Answer(
                    Question.New<string>("Test2", null, true)
                    , "NullPath-Test-Value-2"));

            Answers.Add(
                new Answer(
                    Question.New<string>("Test3", null, true)
                    , "NullPath-Test-Value-3"));

            // add some questions with path = empty-string-array

            Answers.Add(
                new Answer(
                    Question.New<string>("EmptyTest1", new string[] { }, true)
                    , "EmptyPath-Test-Value-1"));

            Answers.Add(
                new Answer(
                    Question.New<string>("EmptyTest2", new string[] { }, true)
                    , "EmptyPath-Test-Value-2"));

            Answers.Add(
                new Answer(
                    Question.New<string>("EmptyTest3", new string[] { }, true)
                    , "EmptyPath-Test-Value-3"));
        }

        [Test]
        public void Getting_Answer_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("First.Second.Test2");

            Assert.AreEqual("Test-Value-2", testValue);
        }

        [Test]
        public void Getting_DefaultValue_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("Some.Wrong.Value.Test", "test-default");

            Assert.AreEqual("test-default", testValue);
        }

        [Test]
        public void Getting_Answer_With_Non_Default_PathSeparator_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("First_Second_Test2", pathSeparator: '_');

            Assert.AreEqual("Test-Value-2", testValue);
        }

        [Test]
        public void Getting_NullPath_Answer_From_Question_With_EmptyPath_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("Test2", path: new string[] { });

            Assert.AreEqual("NullPath-Test-Value-2", testValue);
        }

        [Test]
        public void Getting_NullPath_Answer_From_Question_With_NullPath_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("Test2", path: null);

            Assert.AreEqual("NullPath-Test-Value-2", testValue);
        }

        [Test]
        public void Getting_EmptyPath_Answer_From_Question_With_EmptyPath_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("EmptyTest2", path: new string[] { });

            Assert.AreEqual("EmptyPath-Test-Value-2", testValue);
        }

        [Test]
        public void Getting_EmptyPath_Answer_From_Question_With_NullPath_Works()
        {
            string testValue = Answers.GetAnswerValue<string>("EmptyTest2", path: null);

            Assert.AreEqual("EmptyPath-Test-Value-2", testValue);
        }
    }
}
