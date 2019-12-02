using Core.Common;
using Core.Common.ViewModels;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.Repositories;
using Utilities.wpf.Properties;

namespace Utilities.wpf.ViewModels
{
    public class MetaDataRuleViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        #region Fields
        
        readonly MetaDataRule _metaDataRule;
        readonly MetaDataRuleRepository _metaDataRuleRepository;
        bool _isSelected;
        RelayCommand _saveCommand;
        RelayCommand _deleteCommand;

        #endregion // Fields

        #region Constructor

        public MetaDataRuleViewModel(MetaDataRule metaDataRule, MetaDataRuleRepository metaDataRuleRepository)
        {
            if (metaDataRule == null)
                throw new ArgumentNullException("metaDataRule");

            if (metaDataRuleRepository == null)
                throw new ArgumentNullException("metaDataRuleRepository");

            _metaDataRule = metaDataRule;
            _metaDataRuleRepository = metaDataRuleRepository;
        }

        #endregion // Constructor

        #region MetaDataRule Properties

        public int MetaDataRuleID
        {
            get { return _metaDataRule.MetaDataRuleID; }
            set
            {
                if (value == _metaDataRule.MetaDataRuleID)
                    return;

                _metaDataRule.MetaDataRuleID = value;

                base.OnPropertyChanged("MetaDataRuleID");
            }
        }
        
        public string TableName
        {
            get { return _metaDataRule.TableName; }
            set
            {
                if (value == _metaDataRule.TableName)
                    return;

                _metaDataRule.TableName = value;

                base.OnPropertyChanged("TableName");
            }
        }

        public string FieldName
        {
            get { return _metaDataRule.FieldName; }
            set
            {
                if (value == _metaDataRule.FieldName)
                    return;

                _metaDataRule.FieldName = value;

                base.OnPropertyChanged("FieldName");
            }
        }

        public string OldValue
        {
            get { return _metaDataRule.OldValue; }
            set
            {
                if (_metaDataRule.OldValue == value)
                    return;

                _metaDataRule.OldValue = value;

                base.OnPropertyChanged("OldValue");
            }
        }

        public string NewValue
        {
            get { return _metaDataRule.NewValue; }
            set
            {
                if (_metaDataRule.NewValue == value)
                    return;

                _metaDataRule.NewValue = value;

                base.OnPropertyChanged("NewValue");
            }
        }

        public bool IsDeleted
        {
            get { return _metaDataRule.IsDeleted; }
            set
            {
                if (_metaDataRule.IsDeleted == value)
                    return;

                _metaDataRule.IsDeleted = value;

                base.OnPropertyChanged("IsDeleted");
            }
        }

        /// <summary>
        /// Returns true if this metadatarule was created by the user and it has not yet
        /// been saved to the metadatarule repository.
        /// </summary>
        //public bool IsNew
        //{
        //    //get { return _metaDataRule.IsNew; }
        //    get { return !_metaDataRuleRepository.ContainsMetaDataRule(_metaDataRule); }
        //    set
        //    {
        //        if (_metaDataRule.IsNew == value)
        //            return;

        //        _metaDataRule.IsNew = value;

        //        base.OnPropertyChanged("IsNew");
        //    }
        //}

        public EntityStateOption EntityState
        {
            get { return _metaDataRule.EntityState; }
            set
            {
                if (_metaDataRule.EntityState == value)
                    return;

                _metaDataRule.EntityState = value;

                base.OnPropertyChanged("EntityState");
            }
        }

        public bool HasChanges
        {
            get { return _metaDataRule.HasChanges; }
            set
            {
                if (_metaDataRule.HasChanges == value)
                    return;

                _metaDataRule.HasChanges = value;

                base.OnPropertyChanged("HasChanges");
            }
        }

        public bool IsValid
        {
            get { return _metaDataRule.IsValid; }            
        }      
      

        #endregion // MetaDataRule Properties

        #region Presentation Properties

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value)
                    return;

                _isSelected = value;

                base.OnPropertyChanged("IsSelected");
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => this.Save(),
                        param => this.CanSave
                        );
                }
                return _saveCommand;
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => this.Delete(),
                        param => this.CanSave
                        );
                }
                return _deleteCommand;
            }
        }


        #endregion // Presentation Properties

        #region Public Methods

        /// <summary>
        /// Saves the metadatarule to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        public void Save()
        {
            if (!_metaDataRule.IsValid)
                throw new InvalidOperationException(Strings.MetaDataRuleViewModel_Exception_CannotSave);

            //if (this.IsNew)
            //    _metaDataRuleRepository.AddMetaDataRule(_metaDataRule);

            _metaDataRuleRepository.Save(_metaDataRule);

            base.OnPropertyChanged("DisplayName");
        }

        public bool Delete()
        {
            if (!_metaDataRule.IsValid)
                throw new InvalidOperationException(Strings.MetaDataRuleViewModel_Exception_CannotSave);

            base.OnPropertyChanged("DisplayName");

            return  _metaDataRuleRepository.DeleteItem(_metaDataRule);
        }

        #endregion // Public Methods

        #region Private Helpers

        /// <summary>
        /// Returns true if this metadatarule was created by the user and it has not yet
        /// been saved to the metadatarule repository.
        /// </summary>
        //private bool IsNewMetaDataRule
        //{
        //    get { return !_metaDataRuleRepository.ContainsMetaDataRule(_metaDataRule); }
        //}

        /// <summary>
        /// Returns true if the metadatarule is valid and can be saved.
        /// </summary>
        private bool CanSave
        {
            get { return _metaDataRule.IsValid; }
        }

        #endregion // Private Helpers

        #region IDataErrorInfo Members

        //TODO: Need to understand IDataErrorInfo and implement.
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion // IDataErrorInfo Members
    }
}
