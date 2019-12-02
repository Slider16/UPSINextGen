using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class EmailAddress : ModelBase
    {
        public int BusinessEntityID { get; set; }
        public int EmailAddressID { get; set; }
        public string EmailAddressString { get; set; }
        public DateTime ModifiedDate { get; set; }

        public EmailAddress()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
