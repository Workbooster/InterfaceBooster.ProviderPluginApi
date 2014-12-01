﻿using System;
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

        #endregion
    }
}
