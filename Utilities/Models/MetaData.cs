using Core.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.BL.Properties;

namespace Utilities.BL.Models
{
    public class MetaData : ModelBase
    {

        #region Creation

        public static MetaData CreateNewMetaData()
        {
            return new MetaData();
        }

        public static MetaData CreateMetaData(

            string tableName,
            string fieldName,
            string fieldValue)
        {
            return new MetaData
            {
                TableName = tableName,
                FieldName = fieldName,
                FieldValue = fieldValue
            };
        }

        protected MetaData()
        {

        }

        #endregion // Creation

        #region Properties

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

        private string _fieldValue;
        public string FieldValue
        {
            get { return _fieldValue; }
            set 
            {
                if (_fieldValue == value)
                    return;
                _fieldValue = value;
                OnPropertyChanged("FieldValue");
            }
        }

        #endregion // Properties

        #region Validation

        /// <summary>
        ///  Inherited method to be set by the IsValidMetaData property.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return this.IsValidMetaData;
        }

        /// <summary>
        /// Property to contain validation result. Implements the usage
        /// of IDataErrorInfo interface and the Strings_BL resource.
        /// </summary>
        public bool IsValidMetaData
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        /// <summary>
        /// String array to contain all the Public names of 
        /// all properties within this model that are to
        /// be validated.
        /// </summary>
        private static readonly string[] ValidatedProperties =
        {
            "TableName",
            "FieldName",
            "FieldValue"
        };

        /// <summary>
        /// Validate each property and get validation error
        /// from Strings_BL resource if necessary.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
            {
                return null;
            }

            string error = null;

            switch(propertyName)
            {
                case "TableName":
                    error = this.ValidateTableName();
                    break;

                case "FieldName":
                    error = this.ValidateFieldName();
                    break;

                case "FieldValue":
                    error = this.ValidateFieldValue();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on MetaData: " + propertyName);
                    break;
            }
            return error;

        }

        private string ValidateTableName()
        {
            if (IsStringMissing(this.TableName))
            {
                return Strings_BL.MetaData_Error_MissingTableName;
            }
            return null;
        }

        private string ValidateFieldName()
        {
            if (IsStringMissing(this.FieldName))
            {
                return Strings_BL.MetaData_Error_MissingFieldName;
            }
            return null;
        }

        private string ValidateFieldValue()
        {
            if(IsStringMissing(this.FieldValue))
            {
                return Strings_BL.MetaData_Error_MissingFieldValue;
            }
            return null;
        }

        private static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        #endregion // Validation

        public void Dispose()
        {
            throw new NotImplementedException();
        }





    }
}
