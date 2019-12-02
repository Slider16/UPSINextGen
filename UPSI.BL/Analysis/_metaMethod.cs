using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPSI.BL.Analysis
{
    /// <summary>
    /// Class to hold the various analysis method codes and descriptions used
    /// within the the analysis processes.
    /// </summary>
    public class _metaMethod
    {
        public int MethodID { get; set; }
        public string AnalysisType { get; set; }
        public string MethodCode { get; set; }
        public string Description { get; set; }

        public _metaMethod()
        { }
    }
}
