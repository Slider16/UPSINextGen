using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Equipment
{
    public class EquipmentType : ModelBase
    {
        public int EquipmentTypeID { get; set; }
        public string EquipmentTypeCode { get; set; }
        public string Name { get; set; }

        public EquipmentType()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
