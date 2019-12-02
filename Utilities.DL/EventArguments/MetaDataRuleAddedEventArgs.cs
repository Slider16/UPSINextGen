using System;
using Utilities.BL.Models;

namespace Utilities.DL.EventArguments
{
    /// <summary>
    /// Event arguments used by MetaDataRuleRepository's MetaDataRuleAdded event.
    /// </summary>
    public class MetaDataRuleAddedEventArgs : EventArgs
    {
        public MetaDataRuleAddedEventArgs(MetaDataRule newMetaDataRule)
        {
            this.NewMetaDataRule = newMetaDataRule;
        }

        public MetaDataRule NewMetaDataRule { get; private set; }
    }
}
