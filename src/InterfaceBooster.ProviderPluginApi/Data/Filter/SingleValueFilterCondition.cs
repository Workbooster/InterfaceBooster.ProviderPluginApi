using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    public class SingleValueFilterCondition : FilterCondition
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets the value that is used for the comparison with the filter-filed from the given FilterDefinition.
        /// </summary>
        public object Value { get; set; }

        #endregion

        #region PUBLIC METHOD

        public SingleValueFilterCondition(Data.Filter.FilterTypeEnum filterType, FilterDefinition definition, object value)
            : base(filterType, definition)
        {
            if (filterType == Data.Filter.FilterTypeEnum.AndGroup)
                throw new Exception("A logical AND operator cannot be used as single value filter");
            if (filterType == Data.Filter.FilterTypeEnum.OrGroup)
                throw new Exception("A logical OR operator cannot be used as single value filter");

            Value = value;
        }

        #endregion
    }
}
