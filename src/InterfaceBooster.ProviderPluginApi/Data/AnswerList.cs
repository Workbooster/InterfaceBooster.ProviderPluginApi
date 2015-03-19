using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    public class AnswerList : List<Answer>
    {
        #region PUBLIC METHODS

        public AnswerList() : base() { }

        public AnswerList(IEnumerable<Answer> answers) : base(answers) { }

        /// <summary>
        /// This helper method can be used to access an answer value by specifying the expected type and the full path of the question.
        /// The <paramref name="questionFullPath"/> is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.
        /// </summary>
        /// <typeparam name="T">Expected data type of the question / answer value.</typeparam>
        /// <param name="questionFullPath">Is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.</param>
        /// <param name="defaultValue">The default return value if no answer was found.</param>
        /// <param name="pathSeparator">The character used as separator in the <paramref name="questionFullPath"/>.</param>
        /// <returns>The value of the answer or the <paramref name="defaultValue"/>.</returns>
        public T GetAnswerValue<T>(string questionFullPath, T defaultValue = default(T), char pathSeparator = '.')
        {
            string[] fullPath = questionFullPath.Split(pathSeparator);

            string[] path = fullPath.Take(fullPath.Length - 1).ToArray();
            string name = fullPath.LastOrDefault();

            return GetAnswerValue<T>(name, path, defaultValue);
        }

        /// <summary>
        /// This helper method can be used to access an answer value by specifying the expected type, the name and the path of the question.
        /// </summary>
        /// <typeparam name="T">Expected data type of the question / answer value.</typeparam>
        /// <param name="name">The name of the question.</param>
        /// <param name="path">The path of the question.</param>
        /// <param name="defaultValue">The default value of no matching answer was found.</param>
        /// <returns>The value of the answer or the <paramref name="defaultValue"/>.</returns>
        public T GetAnswerValue<T>(string name, string[] path, T defaultValue = default(T))
        {
            Answer answer = (from a in this
                             where a.Question != null
                             && a.Question.Name == name
                             && a.Question.ExpectedType == typeof(T)
                             && (   (a.Question.Path == null && path == null)
                                 || (a.Question.Path != null && a.Question.Path.SequenceEqual(path)))
                             select a).FirstOrDefault();

            if (answer != null)
            {
                return (T)answer.Value;
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion
    }
}
