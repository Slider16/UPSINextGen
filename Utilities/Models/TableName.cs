using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Utilities.BL.Models
{
    public class TableName : ModelBase
    {
        private string _originalName;

        public string OriginalName
        {
            get { return _originalName; }
            set 
            {
                if (_originalName == value)
                    return;
                _originalName = value;
                OnPropertyChanged("OriginalName");
            }
        }


        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set 
            {
                if (_displayName == value)
                    return;
                _displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        public override bool Validate()
        {
            //TODO: Do I need validation here?
            throw new NotImplementedException();
        }
    }
}
