using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class PhoneNumberType : ModelBase
    {
        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public PhoneNumberType()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
