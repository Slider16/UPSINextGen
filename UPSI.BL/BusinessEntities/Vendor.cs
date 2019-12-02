using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class Vendor : ModelBase
    {
        public int BusinessEntityID { get; set; }
        public string VendorName { get; set; }

        public Vendor()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
