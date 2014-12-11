using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// A Question object describes a parameter that can be answered by Interface Booster by using an Answer object.
    /// </summary>
    public class Question
    {
        #region PROPERTIES

        /// <summary>
        /// Gets the name of question (parameter) used in Synery.
        /// It may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets a list of strings which build a path to this question used in Synery.
        /// The strings may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        public string[] Path { get; set; }

        /// <summary>
        /// Gets or sets an user friendly and localizable description for this Question. 
        /// </summary>
        public LocalizedText Description { get; set; }

        /// <summary>
        /// Gets or sets an internal name used by the Provider Plugin to internaly identify the parameter.
        /// (You can use it or not - this value isn't touched by Interface Booster in any way).
        /// </summary>
        public string InternalName { get; set; }

        /// <summary>
        /// Gets the expected primitive type of the parameter value.
        /// </summary>
        public Type ExpectedType { get; private set; }

        /// <summary>
        /// Gets a flag that indicates whether a value is required.
        /// </summary>
        public bool IsRequired { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public Question(string name, Type expectedType, bool isRequired = false)
        {
            Name = name;
            ExpectedType = expectedType;
            IsRequired = isRequired;
        }

        public Question(string name, string[] path, Type expectedType, bool isRequired = false)
        {
            Name = name;
            Path = path;
            ExpectedType = expectedType;
            IsRequired = isRequired;
        }

        public static Question New<T>(string name, bool isRequired = false)
        {
            return new Question(name, typeof(T), isRequired);
        }

        public static Question New<T>(string name, string[] path, bool isRequired = false, string internalName = null, string description = null)
        {
            Question q = new Question(name, path, typeof(T), isRequired);

            if (internalName != null) q.InternalName = internalName;
            if (description != null) q.Description = new LocalizedText(description);

            return q;
        }

        #endregion
    }
}
