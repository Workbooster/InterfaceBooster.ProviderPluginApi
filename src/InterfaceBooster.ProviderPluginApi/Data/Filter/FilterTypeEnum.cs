using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    public enum FilterTypeEnum
    {
        /// <summary>
        /// Compares the values case in-sensitive.
        /// e.g. "Test" == "test" is true
        /// </summary>
        Equal,

        /// <summary>
        /// Compares the values case in-sensitive.
        /// e.g. "Test" != "test" is false
        /// </summary>
        NotEqual,

        /// <summary>
        /// Compares the values (case sensitive)
        /// Examples:
        /// "Test" === "test" is false
        /// "Test" === "Test" is true
        /// </summary>
        ExactlyEqual,

        /// <summary>
        /// Compares the values (case sensitive)
        /// Examples:
        /// "Test" !== "test" is true
        /// "Test" !== "Test" is false
        /// </summary>
        NotExactlyEqual,
        
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,
        Like,
        OrGroup,
        AndGroup,
    }
}
