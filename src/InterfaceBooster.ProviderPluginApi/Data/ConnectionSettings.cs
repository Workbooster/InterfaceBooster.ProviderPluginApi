using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// Represents the settings for opening a new ProviderConnection.
    /// </summary>
    public class ConnectionSettings
    {
        #region MEMBERS

        public IList<Answer> _Answers;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets a list that contains the answers to the questions needed for creating a connection.
        /// </summary>
        public IList<Answer> Answers
        {
            get
            {
                return _Answers;
            }
        }

        #endregion

        #region PUBLIC METHODS

        public ConnectionSettings(IEnumerable<Answer> answers = null)
        {
            if (answers != null)
            {
                // initialize a new list from the given answers
                _Answers = new List<Answer>(answers);
            }
            else
            {
                // initialize an empty list
                _Answers = new List<Answer>();
            }
        }

        /// <summary>
        /// This helper method can be used to access an answer value by specifying the expected type and the full path of the question.
        /// The <paramref name="questionFullPath"/> is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="questionFullPath">Is composed by the Path and the Name of the Question separated by <paramref name="pathSeparator"/>.</param>
        /// <param name="defaultValue">The default return value if no answer was found.</param>
        /// <param name="pathSeparator">The character used as separator in the <paramref name="questionFullPath"/>.</param>
        /// <returns>The value of the answer or the <paramref name="defaultValue"/>.</returns>
        public T GetAnswerValue<T>(string questionFullPath, T defaultValue = default(T), char pathSeparator = '.')
        {
            string[] fullPath = questionFullPath.Split(pathSeparator);

            string[] path = fullPath.Take(fullPath.Length - 1).ToArray();
            string name = fullPath.LastOrDefault();

            Answer answer = (from a in _Answers
                             where a.Question.Name == name
                             && a.Question.ExpectedType == typeof(T)
                             && a.Question.Path.SequenceEqual(path)
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
