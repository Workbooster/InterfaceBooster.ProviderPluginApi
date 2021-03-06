﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data.Filter
{
    /// <summary>
    /// Represents a list of combined filters connected by a logical OR operator.
    /// </summary>
    public class OrFilterGroup : FilterGroup
    {
        #region PUBLIC METHODS

        public OrFilterGroup() : base(FilterTypeEnum.OrGroup) { }

        #endregion
    }
}
