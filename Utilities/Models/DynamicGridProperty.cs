using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.BL.Models
{
    /// <summary>
    /// Used in builiding the DynamicGrid
    /// user control.
    /// </summary>
    public class DynamicGridProperty : ModelBase
    {
        public string Name { get; private set; }
        public object Value { get; set; }

        public DynamicGridProperty(string name, object value)
        {
            Name = name;
            Value = value;          
        }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
