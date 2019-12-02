using System;
using Utilities.BL.Models;

namespace Utilities.DL.EventArguments
{
    /// <summary>
    /// Event argument used by MetaDataRuleRepository's MetaDataRuleUpdated event.
    /// </summary>
    public class MetaDataRuleUpdatedEventArgs : EventArgs
    {
        public MetaDataRuleUpdatedEventArgs(MetaDataRule updatedMetaDateRule)
        {
            this.UpdatedMetaDataRule = updatedMetaDateRule;
        }

        public MetaDataRule UpdatedMetaDataRule { get; private set; }
    }
}
