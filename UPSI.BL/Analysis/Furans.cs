using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to handle furan analysis results.
    /// </summary>
    public class Furans : BaseAnalysis
    {
        public string CertificateNumber { get; set; }
        public int Hydroxymth { get; set; }
        public int FurFuryl { get; set; }
        public int Furaldehyd { get; set; }
        public int Acetylfur { get; set; }
        public int Methylfur { get; set; }
        public int TotalPPB { get; set; }
        public string FuranNumber { get; set; }
        public string Classification { get; set; }
        
        public Furans()
        { }
    }
}
