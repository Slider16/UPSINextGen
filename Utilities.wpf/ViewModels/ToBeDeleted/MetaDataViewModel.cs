using Core.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.Repositories;

namespace Utilities.wpf.ViewModels
{
    public class MetaDataViewModel : ViewModelBase
    {
        #region Fields
        
        private MetaDataRule _metaDataModel;

        private ICommand _SaveMetaDataCommand;

        #endregion

        #region Public Properties/Commands
        
        public MetaDataRule MetaDataModel
        {
            get { return _metaDataModel; }
            set 
            { 
                _metaDataModel = value;
                OnPropertyChanged("MetaDataModel");
            }
        }
        
        public ICommand SaveMetaDataCommand
        {
            get { return _SaveMetaDataCommand; }
            set 
            {
                _SaveMetaDataCommand = value;
                OnPropertyChanged("SaveMetaDataCommand");
            }
        }

        #endregion

        public MetaDataViewModel()
        {
            InitializeCommand();
            LoadNewMetaData();
        }

        private void InitializeCommand()
        {
            SaveMetaDataCommand = new SaveMetaDataCommand(SaveMetaData);
        }

        private void SaveMetaData()
        {
            MetaDataRuleRepository repo = new MetaDataRuleRepository();
            repo.Save(MetaDataModel);
        }

        private void LoadNewMetaData(bool _isNew=true)
        {
            //MetaDataModel = new MetaDataRule();
            //MetaDataModel.IsNew = _isNew;
        }
    }


    public class SaveMetaDataCommand : ICommand
    {
        Action _executeMethod;

        public SaveMetaDataCommand(Action saveMetaData)
        {
            _executeMethod = saveMetaData;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        // TODO: I just guessed at this part.  Need to implement correctly.
        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
               
            }
        }


        public void Execute(object parameter)
        {
            _executeMethod.Invoke();
        }
    }

}
