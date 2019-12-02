using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to handle standard screen analysis results.
    /// </summary>
    public class StandardScreen : BaseAnalysis
    {
        public string Dielectric { get; set; }
        public string Dielectric1MM { get; set; }
        public string Dielectric2MM { get; set; }
        public decimal NeutralizationNumber { get; set; }
        public string InterfacialTension { get; set; }
        public string Color { get; set; }
        public string Visual { get; set; }
        public string SpecificGravity { get; set; }
        public string PowerFactor25 { get; set; }
        public string PowerFactor100 { get; set; }
        public string WaterPPM { get; set; }
        public string DBPC { get; set; }
        public string Classification { get; set; }
        public string RecommendedService { get; set; }
        
        public StandardScreen()
        { }
    }
}
