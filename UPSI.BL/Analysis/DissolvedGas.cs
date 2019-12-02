using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to handle dissolved gas analysis results.
    /// </summary>
    public class DissolvedGas : BaseAnalysis
    {
        public int Acetylene { get; set; }
        public int Hydrogen { get; set; }
        public int Methane { get; set; }
        public int Ethylene { get; set; }
        public int Ethane { get; set; }
        public int CarbonMonoxide { get; set; }
        public int CarbonDioxide { get; set; }
        public int Nitrogen { get; set; }
        public int Oxygen { get; set; }

        public DissolvedGas()
        {
           
        }
    }
}
