using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.BL.Models
{
    public class MetaSourceField : ModelBase
    {

        #region Properties

        private int _metaSourceFieldID;

        public int MetaSourceFieldID
        {
            get { return _metaSourceFieldID; }
            set 
            {
                if (_metaSourceFieldID == value)
                    return;
                _metaSourceFieldID = value;
                OnPropertyChanged("MetaSourceField");
            }
        }


        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set 
            {
                if (_tableName == value)
                    return;
                _tableName = value;
                OnPropertyChanged("TableName");
            }
        }


        private string _fieldName;

        public string FieldName
        {
            get { return _fieldName; }
            set 
            {
                if (_fieldName == value)
                    return;
                _fieldName = value;
                OnPropertyChanged("FieldName");
            }
        }


        // vfp = Visual Foxpro
        private string _vfpDataType;

        // VFP = Visual Foxpro
        public string VFPDataType
        {
            get { return _vfpDataType; }
            set 
            {
                if (_vfpDataType == value)
                    return;
                _vfpDataType = value;
                OnPropertyChanged("VFPDataType");
            }
        }


        private int _isDeleted;

        public int IsDeleted
        {
            get { return _isDeleted; }
            set 
            {
                if (_isDeleted == value)
                    return;
                _isDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }

        #endregion

        #region Events

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        public override bool Validate()
        {

            //TODO: Do I need validation here?
            throw new NotImplementedException();
        }
    }
}
