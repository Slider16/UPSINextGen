using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class ContactType : ModelBase
    {
        public int ContactTypeID { get; set; }
        public string Name { get; set; }

        public ContactType()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
