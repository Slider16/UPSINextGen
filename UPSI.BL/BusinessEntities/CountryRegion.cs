using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class CountryRegion : ModelBase
    {
        public string CountryRegionCode { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }

        public CountryRegion()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
