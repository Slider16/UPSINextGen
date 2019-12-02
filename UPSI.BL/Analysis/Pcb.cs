using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to handle pcb analysis results.
    /// </summary>
    public class Pcb : BaseAnalysis
    {
        public int Ar1242 { get; set; }
        public int Ar1254 { get; set; }
        public int Ar1260 { get; set; }
        public int OtherPCB { get; set; }
        public int TotalPCB { get; set; }
        public string PcbNumber { get; set; }

        public Pcb()
        { }
    }
}
