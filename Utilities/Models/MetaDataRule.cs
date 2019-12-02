using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.BL.Properties;



namespace Utilities.BL.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MetaDataRule : ModelBase, IDataErrorInfo, IEquatable<MetaDataRule>
    {
        #region Creation

        public static MetaDataRule CreateNewMetaDataRule()
        {
            return new MetaDataRule();
        }

        public static MetaDataRule CreateMetaDataRule(
                                        int metaDataRuleID,
                                        string tableName,
                                        string fieldName,
                                        string oldValue,
                                        string newValue,
                                        bool isDeleted)
        {
            return new MetaDataRule
            {
                MetaDataRuleID = metaDataRuleID,
                TableName = tableName,
                FieldName = fieldName,
                OldValue = oldValue,
                NewValue = newValue,
                IsDeleted = isDeleted
            };
        }

        protected MetaDataRule()
        {

        }

        #endregion // Creation

        #region Properties

        private int _metaDataRuleID;

        public int MetaDataRuleID
        {
            get { return _metaDataRuleID; }
            set
            {
                _metaDataRuleID = value;
                OnPropertyChanged("MetaDataRuleID");
            }
        }
    
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set 
            { 
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
                _fieldName = value;
                OnPropertyChanged("FieldName");
            }
        }

        private string _oldValue;

        public string OldValue
        {
            get { return _oldValue; }
            set 
            { 
                _oldValue = value;
                OnPropertyChanged("OldValue");
            }
        }

        private string _newValue;

        public string NewValue
        {
            get { return _newValue; }
            set 
            { 
                _newValue = value;
                OnPropertyChanged("NewValue");
            }
        }

        //private int _isDeleted;
        private bool _isDeleted;

        //public int IsDeleted
        //{
        //    get { return _isDeleted; }
        //    set 
        //    { 
        //        _isDeleted = value;
        //        OnPropertyChanged("IsDeleted");
        //    }
        //}
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                _isDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }
        
        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary>
        ///  Inherited method to be set by the IsValidMetaDataRule property.
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            return this.IsValidMetaDataRule;           
        }

        /// <summary>
        /// Property to contain validation result. Implements the usage
        /// of IDataErrorInfo interface and the Strings_BL resource.
        /// </summary>
        public bool IsValidMetaDataRule
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
        /// String array to contain all the Public name of 
        /// all properties within this model that are to
        /// be validated.
        /// </summary>
        private static readonly string[] ValidatedProperties =
        {
            "TableName",
            "FieldName",
            "OldValue",
            "NewValue"
        };

        /// <summary>
        /// Validate each property and get validation error
        /// from Strings_BL resource if necessary.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "TableName":
                    error = this.ValidateTableName();
                    break;

                case "FieldName":
                    error = this.ValidateFieldName();
                    break;
                    
                case "OldValue":
                    error = this.ValidateOldValue();
                    break;
                    
                case "NewValue":
                    error = this.ValidateNewValue();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on MetaDataRule: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateTableName()
        {
            if (IsStringMissing(this.TableName))
            {
                return Strings_BL.MetaDataRule_Error_MissingTableName;
            }
            return null;
        }

        private string ValidateFieldName()
        {
            if (IsStringMissing(this.FieldName))
            {
                return Strings_BL.MetaDataRule_Error_MissingFieldName;
            }
            return null;
        }

        private string ValidateOldValue()
        {
            if (IsStringMissing(this.OldValue))
            {
                return Strings_BL.MetaDataRule_Error_MissingOldValue;
            }
            return null;
        }

        private string ValidateNewValue()
        {
            if (IsStringMissing(this.NewValue))
            {
                return Strings_BL.MetaDataRule_Error_MissingNewValue;
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

        /// <summary>
        /// Override Equals comparator
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MetaDataRule other)
        {
            return this.TableName == other.TableName && 
                   this.FieldName == other.FieldName && 
                   this.OldValue == other.OldValue;
        }
    }
}
