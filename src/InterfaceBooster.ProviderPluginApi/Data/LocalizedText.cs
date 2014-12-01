using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// Stores translated strings. As keys the default .NET culture names (e.g. "en-US", "de-CH") are used.
    /// </summary>
    public class LocalizedText
    {
        #region MEMBERS
        
        private Dictionary<string, string> _Translations;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets the default translation.
        /// </summary>
        public string Default { get; set; }
        
        /// <summary>
        /// Gets a dictionary containing all available translations (without default).
        /// Key = CultureName / Value = translated text.
        /// </summary>
        public IReadOnlyDictionary<string, string> Translations
        {
            get
            {
                return _Translations;
            }
        }

        #endregion

        #region PUBLIC METHODS
        
        public LocalizedText(string defaultText)
        {
            Default = defaultText;
            _Translations = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds a new translation for the given <paramref name="cultureName"/>.
        /// </summary>
        /// <param name="cultureName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public LocalizedText Add(string cultureName, string text)
        {
            if (_Translations.ContainsKey(cultureName))
            {
                _Translations[cultureName] = text;
            }
            else
            {
                _Translations.Add(cultureName, text);
            }

            return this;
        }

        /// <summary>
        /// Searches for a translation matching the given <paramref name="cultureName"/>.
        /// If no translation is available the default text is returned.
        /// </summary>
        /// <param name="cultureName"></param>
        /// <returns></returns>
        public string GetTranslationOrDefault(string cultureName)
        {
            if (_Translations.ContainsKey(cultureName))
            {
                return _Translations[cultureName];
            }

            return Default;
        }

        /// <summary>
        /// Converts a LocalizedText object to a string by returning the Default text.
        /// </summary>
        /// <param name="localizedText"></param>
        /// <returns></returns>
        public static implicit operator string(LocalizedText localizedText)
        {
            return localizedText.Default;
        }

        /// <summary>
        /// Create a LocalizedText from a string. The string is set as Default.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A new instance</returns>
        public static explicit operator LocalizedText(string text)
        {
            return new LocalizedText(text);
        }

        #endregion
    }
}
