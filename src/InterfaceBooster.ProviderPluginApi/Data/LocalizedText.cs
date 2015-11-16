using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// Stores translated strings. As keys the default .NET culture names (e.g. "en-US", "de-CH") are used.
    /// </summary>
    [Serializable]
    [XmlRoot("LocalizedText")]
    public class LocalizedText : IXmlSerializable
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
        [XmlIgnore]
        public Dictionary<string, string> Translations
        {
            get
            {
                return _Translations;
            }
        }

        #endregion

        #region PUBLIC METHODS

        public LocalizedText()
        {
            Initialize();
        }

        public LocalizedText(string defaultText)
        {
            Initialize(defaultText);
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
            if (localizedText == null) return null;

            return localizedText.Default;
        }

        /// <summary>
        /// Create a LocalizedText from a string. The string is set as Default.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A new instance</returns>
        public static implicit operator LocalizedText(string text)
        {
            return new LocalizedText(text);
        }

        #region IMPLEMENTATION OF IXmlSerializable

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            Initialize();

            if (reader.MoveToContent() == XmlNodeType.Element)
            {
                Default = reader["Default"];

                if (reader.ReadToDescendant("Translations"))
                {
                    if (reader.ReadToDescendant("Translation"))
                    {
                        while (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Translation")
                        {
                            _Translations.Add(reader["LanguageCode"], reader.ReadElementContentAsString());
                        }
                    }
                    reader.Read();
                }
                reader.Read();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Default", Default);

            if (Translations != null && Translations.Count > 0)
            {
                // write translations in a nested node
                writer.WriteStartElement("Translations");

                foreach (var tranlation in Translations)
                {
                    writer.WriteStartElement("Translation");
                    writer.WriteAttributeString("LanguageCode", tranlation.Key);
                    writer.WriteValue(tranlation.Value);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }

        #endregion

        #region IMPLEMENTATION OF EQUALITY CHECK LOGIC

        public override bool Equals(System.Object obj)
        {
            if (obj != null && obj is LocalizedText)
            {
                return Equals((LocalizedText)obj);
            }

            return false;
        }

        public bool Equals(LocalizedText p)
        {
            if (this.Default != p.Default)
            {
                return false;
            }

            if (_Translations != null)
            {
                if (p.Translations == null)
                {
                    return false;
                }
                else
                {
                    foreach (var item in this._Translations)
                    {
                        if (p.Translations.Contains(item) == false)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = this.Default.GetHashCode();

            if (_Translations != null)
            {
                foreach (var item in _Translations)
                {
                    hash = hash ^ item.GetHashCode();
                }
            }

            return hash;
        }

        #endregion

        #endregion

        #region INTERNAL METHODS

        /// <summary>
        /// Initializes a new instance of this class (used by constructors).
        /// </summary>
        /// <param name="defaultText"></param>
        private void Initialize(string defaultText = "")
        {
            Default = defaultText;
            _Translations = new Dictionary<string, string>();
        }

        #endregion
    }
}
