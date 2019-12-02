using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.BusinessEntities
{
    public class StateProvince : ModelBase
    {
        public int StateProvinceID { get; set; }
        public string StateProviceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag { get; set; }
        public string Name { get; set; }
        public int TerritoryID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public StateProvince()
        { }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
