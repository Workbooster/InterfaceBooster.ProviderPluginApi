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
            string[] path;
            string name;

            SplitQuestionFullPath(questionFullPath, out name, out path, pathSeparator);

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
            Answer answer = GetAnswer<T>(name, path);

            if (answer != null)
            {
                return (T)answer.Value;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// This helper method can be used to get an Answer object by specifying the expected type and the full path of the question.
        /// The <paramref name="questionFullPath"/> is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.
        /// </summary>
        /// <typeparam name="T">Expected data type of the question / answer value.</typeparam>
        /// <param name="questionFullPath">Is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.</param>
        /// <param name="pathSeparator">The character used as separator in the <paramref name="questionFullPath"/>.</param>
        /// <returns>The Answer object or null.</returns>
        public Answer GetAnswer<T>(string questionFullPath, char pathSeparator = '.')
        {
            string[] path;
            string name;

            SplitQuestionFullPath(questionFullPath, out name, out path, pathSeparator);

            return GetAnswer<T>(name, path);
        }

        /// <summary>
        /// This helper method can be used to get an Answer object by specifying the expected type, the name and the path of the question.
        /// </summary>
        /// <typeparam name="T">Expected data type of the question / answer value.</typeparam>
        /// <param name="name">The name of the question.</param>
        /// <param name="path">The path of the question.</param>
        /// <returns>The Answer value or null.</returns>
        public Answer GetAnswer<T>(string name, string[] path)
        {
            return (from a in this
                    where a.Question != null
                    && a.Question.Name == name
                    && a.Question.ExpectedType == typeof(T)
                    && ((a.Question.Path == null && path == null)
                        || (a.Question.Path != null && a.Question.Path.SequenceEqual(path)))
                    select a).FirstOrDefault();
        }

        /// <summary>
        /// Checks whether an Answer was given.
        /// </summary>
        /// <typeparam name="T">Expected data type of the question / answer value.</typeparam>
        /// <param name="questionFullPath">Is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.</param>
        /// <param name="pathSeparator">The character used as separator in the <paramref name="questionFullPath"/>.</param>
        /// <returns>True if an Answer is available.</returns>
        public bool IsAnswerSet<T>(string questionFullPath, char pathSeparator = '.')
        {
            string[] path;
            string name;

            SplitQuestionFullPath(questionFullPath, out name, out path, pathSeparator);

            return IsAnswerSet<T>(name, path);
        }

        /// <summary>
        /// Checks whether an Answer was given.
        /// </summary>
        /// <typeparam name="T">Expected data type of the question / answer value.</typeparam>
        /// <param name="name">The name of the question.</param>
        /// <param name="path">The path of the question.</param>
        /// <returns>True if the Answer is available.</returns>
        public bool IsAnswerSet<T>(string name, string[] path)
        {
            if (GetAnswer<T>(name, path) != null)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region INTERNAL METHODS

        private void SplitQuestionFullPath(string questionFullPath, out string name, out string[] path, char pathSeparator = '.')
        {
            string[] fullPath = questionFullPath.Split(pathSeparator);

            path = fullPath.Take(fullPath.Length - 1).ToArray();
            name = fullPath.LastOrDefault();
        }

        #endregion
    }
}
