using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi
{
    public static class ProviderPluginApi
    {
        /// <summary>
        /// Gets a list of CLR Types supported by Interface Booster and Synery
        /// </summary>
        public static readonly IEnumerable<Type> SUPPORTED_TYPES = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(decimal), typeof(double), typeof(char), typeof(DateTime) };

        /// <summary>
        /// Gets a regular expression instance that can be used to check for valid Synery Identifiers.
        /// All identifers used in Synery (e.g. endpoint paths an names, field names etc.) must match this rules.
        /// </summary>
        public static readonly Regex SYNERY_IDENTIFIER_REGEX = new Regex(@"^[a-zA-Z_][a-zA-Z0-9_]*$");
    }
}
