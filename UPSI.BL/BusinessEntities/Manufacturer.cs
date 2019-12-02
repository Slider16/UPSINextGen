using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class Manufacturer : ModelBase
    {
        public int BusinessEntityID { get; set; }
        public string ManufacturerCode { get; set; }
        public string Name { get; set; }

        public Manufacturer()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
