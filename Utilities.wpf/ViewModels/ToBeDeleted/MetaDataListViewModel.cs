using Core.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.Repositories;

namespace Utilities.wpf.ViewModels
{
    public class MetaDataListViewModel : ViewModelBase
    {

        #region Fields

        private ICommand _command;
        private ICommand _tableNameChangedCommand;
        private ICommand _toggleExecuteCommand { get; set; }
        private bool _canExecute = true;

        private ObservableCollection<MetaSourceField> _metaSourceFields = new ObservableCollection<MetaSourceField>();
        private ObservableCollection<TableName> _tableNames;
        private TableName _selectedTableName;

        #endregion // Fields

        #region Public Properties/Commands

        public bool CanExecute
        {
            get
            {
                return this._canExecute;
            }
            set
            {
                if (this._canExecute == value)
                {
                    return;
                }
                this._canExecute = value;
            }
        }


        public ICommand GetMetaSourceFieldsCommand
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged("GetMetaSourceFieldsCommand");
            }
        }

        public ICommand TableNameChangedCommand
        {
            get
            {
                return _tableNameChangedCommand;
            }
            set
            {
                _tableNameChangedCommand = value;
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            {
                return _toggleExecuteCommand;
            }
            set
            {
                _toggleExecuteCommand = value;
            }
        }



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


        public TableName SelectedTableName
        {
            get { return _selectedTableName; }
            set 
            {
                _selectedTableName = value;
                OnPropertyChanged("SelectedTableName");
            }
        }
        

        #endregion // Public Properties/Commands


        public MetaDataListViewModel()
        {

            TableNameChangedCommand = new RelayCommand(UpdateMetaSourceFieldsComboBox, param => this._canExecute);
            _toggleExecuteCommand = new RelayCommand(ChangeCanExecute);

            this.TableNames = GetTableNamesList();
            //GetMetaSourceFields("liquid");       
        }


        private void UpdateMetaSourceFieldsComboBox(object obj)
        {
            MetaSourceFieldRepository metaSourceFieldRepo = new MetaSourceFieldRepository();
            this.MetaSourceFields = metaSourceFieldRepo.GetMetaSourceFieldsByTableName(this.SelectedTableName.DisplayName);
        }

        private void ChangeCanExecute(object obj)
        {
            _canExecute = !_canExecute;
        }

        #region Events
        #endregion


        #region Methods

        private void InitializeCommand()
        {
           // GetMetaSourceFieldsCommand = new GetMetaSourceFieldsCommandClass(GetMetaSourceFields);
        }
 
        private ObservableCollection<TableName> GetTableNamesList()
        {
            TableNameRepository tableNameRepo = new TableNameRepository();
            return tableNameRepo.GetItems();
        }
      
        #endregion



        





    }
}
