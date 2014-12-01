using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceBooster.ProviderPluginApi.Data
{
    /// <summary>
    /// An Answer object contains the parameter value set by Interface Booster answering a Question object.
    /// </summary>
    public class Answer
    {
        #region PROPERTIES
        
        public Question Question { get; private set; }
        public object Value { get; private set; }

        #endregion

        #region PUBLIC METHODS

        public Answer(Question question, object value)
        {
            Question = question;
            Value = value;
        }

        #endregion
    }
}
