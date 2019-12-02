using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to handle visual inspection results.
    /// </summary>
    public class VisualInspection : BaseAnalysis
    {
        public string OperatingTemperature { get; set; }
        public string PeakTemperature { get; set; }
        public string ActualTemperature { get; set; }
        public string FluidLevel { get; set; }
        public string Pressure { get; set; }
        public string PaintCondition { get; set; }
        public string BushingsCondition { get; set; }
        public string Environment { get; set; }
        public string Leaks { get; set; }
        public string RecommendedService { get; set; }
        public bool PerformDGAnalysis { get; set; }
        public bool PerformICPAnalysis { get; set; }
        public bool PerformPCBAnalysis { get; set; }
        public bool PerformOtherAnalysis { get; set; }

        public VisualInspection()
        { }
    }
}
