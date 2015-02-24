using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi
{
    public static class ProviderPluginApi
    {
        /// <summary>
        /// Gets a list of CLR Types supported by Interface Booster and Synery
        /// </summary>
        public static readonly IEnumerable<Type> SUPPORTED_TYPES = new Type[] { typeof(string), typeof(bool), typeof(int), typeof(decimal), typeof(double), typeof(char), typeof(DateTime) };
    }
}
