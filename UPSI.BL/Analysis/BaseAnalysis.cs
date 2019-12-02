using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Base class for all analysis classes
    /// </summary>
    public class BaseAnalysis : ModelBase
    {
        public int TestID { get; set; }
        public int UnitID { get; set; }
        public DateTime TestDate { get; set; }
        public DateTime SampleDate { get; set; }
        public string MethodCode { get; set; }
        public int SampleNumber { get; set; }

        public BaseAnalysis()
        { }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
