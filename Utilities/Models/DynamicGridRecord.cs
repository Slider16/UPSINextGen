using Core.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.BL.Models
{
    /// <summary>
    /// Used in builiding the DynamicGrid
    /// user control.
    /// </summary>
    public class DynamicGridRecord : ModelBase
    {

        private readonly ObservableCollection<DynamicGridProperty> properties = new ObservableCollection<DynamicGridProperty>();

        public DynamicGridRecord(params DynamicGridProperty[] properties)
        {
            foreach (var property in properties)
            {
                Properties.Add(property);
            }

        }

        public ObservableCollection<DynamicGridProperty> Properties 
        {
            get { return properties; } 
        }


        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
