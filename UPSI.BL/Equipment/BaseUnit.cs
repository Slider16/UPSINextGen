using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Equipment
{
    public class BaseUnit : ModelBase
    {
        public int UnitID { get; set; }
        public string ManufacturerCode { get; set; }
        public string EquipmentTypeCode { get; set; }
        public string UpsiNumber { get; set; }
        public string ManufactureDate { get; set; }
        public string HighVoltage { get; set; }
        public string LowVoltage { get; set; }
        public string Valves { get; set; }

        public BaseUnit()
        { }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
