using Core.Common;
using Core.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.Repositories;
using Utilities.DL.EventArguments;
using Utilities.wpf.Properties;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections;
using System.Windows.Controls;

namespace Utilities.wpf.ViewModels
{

    /// <summary>
    /// The ViewModel for the Meta Maker screen
    /// </summary>
    public class MetaMakerViewModel : WorkspaceViewModel
    {
        #region Fields

        //private ReadOnlyCollection<CommandViewModel> _commands;
        //readonly MetaDataRule _metaDataRule;

        readonly MetaDataRuleRepository _metaDataRuleRepository;
        //MetaDataRuleRepository _metaDataRuleRepository;

        RelayCommand _saveCommand;
        RelayCommand _autoEnterCommand;
        
        private TableName _selectedTable;
        public TableName SelectedTable
        {
            get { return _selectedTable; }
            set 
            {
                if (_selectedTable == value)
                    return;
                _selectedTable = value;
                
                this.MetaSourceFields = GetMetaSourceFields(_selectedTable);
    
                this.SelectedField = this.MetaSourceFields.FirstOrDefault();
                OnPropertyChanged("SelectedTable");
                
                if (value != null)
                    this._metaDataRule.TableName = _selectedTable.OriginalName;
            }
        }

        private MetaSourceField _selectedField;
        public MetaSourceField SelectedField
        {
            get { return _selectedField; }
            set 
            {
                if (_selectedField == value)
                    return;
                _selectedField = value;

                
                if (_selectedTable != null && _selectedField != null)
                {
                    this._metaDataRule.FieldName = _selectedField.FieldName;

                    List<MetaData> all = 
                    (from metaData in _metaSourceDataRepo.GetMetaSourceDataByTableAndField(SelectedTable.OriginalName, SelectedField.FieldName)
                      select MetaData.CreateMetaData(metaData.TableName, metaData.FieldName, metaData.FieldValue)).ToList();

                    foreach (MetaData md in all)
                        md.PropertyChanged += this.OnMetaDataPropertyChanged;

                    this.MetaSourceData = new ObservableCollection<MetaData>(all);
                    this.MetaSourceData.CollectionChanged += this.OnMetaSourceDataChanged;

                }
                OnPropertyChanged("SelectedField");
            }
        }


        private MetaData _selectedFieldValue;
        public MetaData SelectedFieldValue
        {
            get { return _selectedFieldValue; }
            set 
            {
                if (_selectedFieldValue == value)
                    return;
                
                _selectedFieldValue = value;
                if (_selectedFieldValue != null)
                {
                    this._metaDataRule.OldValue = _selectedFieldValue.FieldValue;
                }

                OnPropertyChanged("SelectedFieldValue");     
            }
        }

        private MetaDataRule _metaDataRule;
        public MetaDataRule MetaDataRule
        {
            get { return _metaDataRule; }

            set
            {
                if (_metaDataRule == value)
                {
                    _metaDataRule.HasChanges = false;
                    return;
                }
                else
                {
                    _metaDataRule = value;
                    _metaDataRule.HasChanges = true;
                }
            }
        }

        private int _isActive;
        public int IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        TableNameRepository _tableNameRepo;
        MetaSourceFieldRepository _metaSourceFieldRepo;
        MetaSourceDataRepository _metaSourceDataRepo;


        #endregion // Fields       

        #region Constructor

        public MetaMakerViewModel(MetaDataRule metaDataRule, MetaDataRuleRepository metaDataRuleRepository )
        {
            if (metaDataRule == null)
                throw new ArgumentNullException("metaDataRule");

            if (metaDataRuleRepository == null)
                throw new ArgumentNullException("metaDataRuleRepository");
            
            base.DisplayName = Strings.MetaMakerViewModel_DisplayName;

            _metaDataRule = metaDataRule;
            _metaDataRuleRepository = metaDataRuleRepository;           
            _metaSourceDataRepo = new MetaSourceDataRepository();

            // Subscribe for notifications of when a new metaDataRule is added or updated.
            //_metaDataRuleRepository.MetaDataRuleAdded += this.OnMetaDataRuleAddedToRepository;
            //_metaDataRuleRepository.MetaDataRuleUpdated += this.OnMetaDataRuleUpdatedInRepository;

            // Subscribe for notifications of when a metaDataRule is deleted.
            _metaDataRuleRepository.MetaDataRuleDeleted += this.OnMetaDataRuleDeletedFromRepository;
            
            
            this.TableNames = GetTableNamesList();
            this.SelectedTable = TableNames.FirstOrDefault();
        }

        #endregion // Constructor

        #region MetaDataRule Properties

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

        //public bool IsNew
        //{
        //    get { return _metaDataRule.IsNew; }
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
            get { return _metaDataRule.Validate(); }

            //TODO: No set method on this property, it is ReadOnly.  Study to understand why.
        }


        #endregion // MetaDataRule Properties        
        
        #region ObservableCollections

        private ObservableCollection<TableName> _tableNames;
        public ObservableCollection<TableName> TableNames
        {
            get { return _tableNames; }
            set
            {
                if (_tableNames == value)
                    return;
                _tableNames = value;
                OnPropertyChanged("TableNames");
            }
        }


        private ObservableCollection<MetaSourceField> _metaSourceFields;
        public ObservableCollection<MetaSourceField> MetaSourceFields
        {
            get { return _metaSourceFields; }
            set
            {
                if (_metaSourceFields == value)
                    return;
                _metaSourceFields = value;
                OnPropertyChanged("MetaSourceFields");
            }
        }

        
        private ObservableCollection<MetaData> _metaSourceData;
        public ObservableCollection<MetaData> MetaSourceData
        {
            get { return _metaSourceData; }
            set
            {
                if (_metaSourceData == value)
                    return;
                _metaSourceData = value;
                OnPropertyChanged("MetaSourceData");               
            }
        }

        #endregion // ObservableCollections

        #region Commands - May re-visit

        /// <summary>
        /// MetaMakerViewModel Commands Collection
        /// </summary>
        //public ReadOnlyCollection<CommandViewModel> Commands
        //{
        //    get
        //    {
        //        if (_commands == null)
        //        {
        //            List<CommandViewModel> cmds = this.CreateCommands();
        //            _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
        //        }
        //        return _commands;
        //    }
        //}

        //private List<CommandViewModel> CreateCommands()
        //{
        //    return new List<CommandViewModel>
        //    {
        //        new CommandViewModel(
        //            Strings.MainWindowViewModel_GetTableNames,
        //            new RelayCommand(param => this.GetTableNamesList())),

        //        new CommandViewModel(
        //            Strings.MetaMakerViewModel_GetMetaSourceFields,
        //            new RelayCommand(param => this.GetMetaSourceFields(_selectedTable))),

        //        new CommandViewModel(
        //            Strings.MetaMakerViewModel_GetMetaSourceData,
        //            new RelayCommand(param => this.GetMetaSourceData(_selectedTable, _selectedField))),
        //    };
        //}

        #endregion // Commands - May re-visit
        
        #region Presentation Properties

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => Save(param),
                        param => CanSave
                        );
                }
                return _saveCommand;
            }
        }

        public ICommand AutoEnterCommand
        {
            get
            {
                if (_autoEnterCommand == null)
                {
                    _autoEnterCommand = new RelayCommand(
                        param => AutoEnter(),
                        param => CanSave
                        );
                }
                return _autoEnterCommand;
            }
        }

        private void AutoEnter()
        {
            NewValue = "YouClicked";
        }

        #endregion // Presentation Properties

        #region Public Methods

        public void Save(object selectedItems)
        {
            List<MetaData> toBeRemoved = new List<MetaData>();
            toBeRemoved.Clear();

            var metaDataList = (IEnumerable)selectedItems;

            foreach(MetaData metaData in metaDataList)
            {
                var newMetaDataRule = MetaDataRule.CreateNewMetaDataRule();
                newMetaDataRule.TableName = metaData.TableName;
                newMetaDataRule.FieldName = metaData.FieldName;
                newMetaDataRule.OldValue = metaData.FieldValue;
                newMetaDataRule.NewValue = NewValue;
                newMetaDataRule.IsDeleted = false;

                if (!newMetaDataRule.Validate())
                    throw new InvalidOperationException(Strings.MetaMakerViewModel_Exception_CannotSave);

                if (!_metaDataRuleRepository.Save(newMetaDataRule))
                    throw new Exception("Unable to save new metadata rule to the database.");

                toBeRemoved.Add(metaData);
            }

            NewValue = string.Empty;
            
            foreach(MetaData md in toBeRemoved)
            {
                MetaSourceData.Remove(md);
            }
        }

        #endregion // Public Methods

        #region Private Helpers

        /// <summary>
        /// Returns true if this MetaDataRule was created by the user and it has not yet
        /// been saved to the _metaDataRule repository.
        /// </summary>
        private bool IsNewMetaDataRule
        {
            get { return !_metaDataRuleRepository.ContainsMetaDataRule(_metaDataRule); }
           
        }

        /// <summary>
        /// Returns true if the metaDataRule is valid.
        /// </summary>
        private bool CanSave
        {           
            get 
            {
                 //This line is what disables the "Create Rule" button until the metadata rule has been validated.
                 return _metaDataRule.Validate();                           
            }            
        }

        /// <summary>
        /// Retrieve a list of tablenames that contain the source data on
        /// which the meta data will be based.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<TableName> GetTableNamesList()
        {
            if (_tableNameRepo == null)
                _tableNameRepo = new TableNameRepository();

            return _tableNameRepo.GetItems();
        }

        /// <summary>
        /// Retrieve the meta source fields for the selected table name.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private ObservableCollection<MetaSourceField> GetMetaSourceFields(TableName tableName)
        {
            if (_metaSourceFieldRepo == null)
                _metaSourceFieldRepo = new MetaSourceFieldRepository();
            
            return _metaSourceFieldRepo.GetMetaSourceFieldsByTableName(tableName.OriginalName);
        }

        /// <summary>
        /// Retrieve the meta source data fields for the selected table name
        /// and field name.
        /// </summary>
        /// <param name="_tableName"></param>
        /// <param name="_fieldName"></param>
        /// <returns></returns>
        private ObservableCollection<MetaData> GetMetaSourceData(TableName _tableName, MetaSourceField _fieldName)
        {
            if (_metaSourceDataRepo == null)
                _metaSourceDataRepo = new MetaSourceDataRepository();
            
            return _metaSourceDataRepo.GetMetaSourceDataByTableAndField(_tableName.OriginalName, _fieldName.FieldName);
        }

        #endregion // Private Helpers

        #region Base Class Overrides

        protected override void OnDispose()
        {
            //foreach (MetaData md in this.MetaSourceData)
            //    md.Dispose();

            this.MetaSourceData.Clear();
            this.MetaSourceData.CollectionChanged -= this.OnMetaSourceDataChanged;
        }

        #endregion // Base Class Overrides

        #region Event Handling Methods

        private void OnMetaSourceDataChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (MetaData md in e.NewItems)
                    md.PropertyChanged += this.OnMetaDataPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (MetaData md in e.OldItems)
                    md.PropertyChanged += this.OnMetaDataPropertyChanged;
        }

        private void OnMetaDataPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Code up anything needed here.

            throw new NotImplementedException();
        }

        private void OnMetaDataRuleAddedToRepository(object sender, MetaDataRuleAddedEventArgs e)
        {
            //_metaDataRuleRepository = new MetaDataRuleRepository();

            //// Subscribe for notifications of when a new metaDataRule is saved.
            //_metaDataRuleRepository.MetaDataRuleAdded += this.OnMetaDataRuleAddedToRepository;
            //_metaDataRuleRepository.MetaDataRuleUpdated += this.OnMetaDataRuleUpdatedInRepository;

            //this.GetMetaSourceData(SelectedTable, SelectedField);

            //MetaData md = MetaData.CreateMetaData(e.NewMetaDataRule.TableName, e.NewMetaDataRule.FieldName, e.NewMetaDataRule.OldValue);
            //this.MetaSourceData.Remove(md);          
            
        }

        private void OnMetaDataRuleUpdatedInRepository(object sender, MetaDataRuleUpdatedEventArgs e)
        {
            //_metaDataRuleRepository = new MetaDataRuleRepository();
            
            //// Subscribe for notifications of when an existing metaDataRule is updated.
            //_metaDataRuleRepository.MetaDataRuleAdded += this.OnMetaDataRuleAddedToRepository;
            //_metaDataRuleRepository.MetaDataRuleUpdated += this.OnMetaDataRuleUpdatedInRepository;

            
        }

        private void OnMetaDataRuleDeletedFromRepository(object sender, MetaDataRuleDeletedEventArgs e)
        {
            // If user is currently viewing the Table and Field of the rule that was deleted, at it to view.
            if (e.DeletedMetaDataRule.TableName == TableName && e.DeletedMetaDataRule.FieldName == FieldName)
            {
                MetaData metaData = MetaData.CreateNewMetaData();
                metaData.TableName = e.DeletedMetaDataRule.TableName;
                metaData.FieldName = e.DeletedMetaDataRule.FieldName;
                metaData.FieldValue = e.DeletedMetaDataRule.OldValue;

                _metaSourceData.Add(metaData);
                //this._metaSourceData.OrderBy(msd => msd.FieldValue);  


                         
            }
        }
        
        #endregion // Event Handling Methods


    }
}
