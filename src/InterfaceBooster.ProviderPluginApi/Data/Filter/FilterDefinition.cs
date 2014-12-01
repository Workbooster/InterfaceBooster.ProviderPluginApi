using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    /// <summary>
    /// Describes a filter-field that can be used by Interface Booster to define a filter 
    /// Example:
    ///     Firstname == "Max"
    /// Description:
    ///     "Firstname" is the filter-field described by this filter definition.
    ///     "==" is the filter type used fo the comparison (in this case FilterType.Equal).
    ///     "Max" is the value (specified in the FilterCondition object).
    /// </summary>
    public class FilterDefinition
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the name of the filter used in Synery.
        /// It may not contain any white spaces or special chars that are not allowed in synery identifiers.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets or sets the Type of the value the filter-field is compared to.
        /// </summary>
        public Type ExpectedType { get; private set; }

        /// <summary>
        /// Gets or sets a list of filter types that can be used to compare the value of this filter-field with a value specified in a Filter object.
        /// </summary>
        public FilterType[] SupportedFilterTypes { get; private set; }

        /// <summary>
        /// Gets or sets an user friendly and localizable description about this FilterDefinition. 
        /// </summary>
        public LocalizedText Description { get; set; }

        /// <summary>
        /// Gets or sets an internal name used by the Provider Plugin to internaly identify the FilterDefinition (e.g. the table name).
        /// (You're free to use this property internally. This value isn't touched or displayed by Interface Booster in any way).
        /// </summary>
        public string InternalIdentifier { get; set; }

        #endregion

        #region PUBLIC METHODS

        public FilterDefinition(string name, Type expectedType, FilterType[] supportedFilterTypes)
        {
            Name = name;
            ExpectedType = expectedType;
            SupportedFilterTypes = supportedFilterTypes;
        }

        #endregion
    }
}
