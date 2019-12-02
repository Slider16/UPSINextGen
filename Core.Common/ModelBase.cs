using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    // TODO: Revisit EntityStateOption enum - Duplicating IsDeleted?
    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    public abstract class ModelBase : ObservableObject
    {
        public EntityStateOption EntityState { get; set; }
        
        public bool HasChanges { get; set; }

        public bool IsValid
        {
            get
            {
                return Validate();
            }
        }

        /// <summary>
        /// Validates the entity.
        /// </summary>
        /// <returns></returns>
        public abstract bool Validate();
    }

}
