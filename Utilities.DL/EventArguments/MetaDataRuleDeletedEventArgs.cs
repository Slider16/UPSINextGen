using System;
using Utilities.BL.Models;

namespace Utilities.DL.EventArguments
{
    /// <summary>
    /// Event argument used by MetaDataRuleRepository's MetaDataRuleDeleted event.
    /// </summary>
    public class MetaDataRuleDeletedEventArgs : EventArgs
    {
        public MetaDataRuleDeletedEventArgs(MetaDataRule deletedMetaDataRule)
        {
            this.DeletedMetaDataRule = deletedMetaDataRule;
        }

        public MetaDataRule DeletedMetaDataRule { get; private set; }
    }
}
