using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to handle icap analysis results.
    /// </summary>
    public class Icap : BaseAnalysis
    {
        public int Aluminum { get; set; }
        public int Copper { get; set; }
        public int Iron { get; set; }
        public int Lead { get; set; }
        public int Silver { get; set; }
        public int Tin { get; set; }
        public int Zinc { get; set; }
        public int Silicon { get; set; }
        public string Comment { get; set; }


        public Icap()
        { }
    }
}
