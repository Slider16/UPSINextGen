using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class PhoneNumber : ModelBase
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumberString { get; set; }
        public int PhoneNumberTypeID { get; set; }

        public PhoneNumber()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
