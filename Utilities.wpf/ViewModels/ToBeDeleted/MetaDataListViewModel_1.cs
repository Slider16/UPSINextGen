using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.Repositories;

namespace Utilities.wpf.ViewModels
{
    public class MetaDataListViewModel_1 : ViewModelBase
    {
        #region Fields

        private MetaDataRule _metaDataModel;

        private ICommand _command;

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

        public ICommand GetMetaDataListCommand
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged("GetMetaDataListCommand");
            }
        }
        
        #endregion

        public MetaDataListViewModel_1()
        {
            InitializeCommand();

            GetMetaDataList();
        }

        private void InitializeCommand()
        {
            GetMetaDataListCommand = new GetMetaDataListCommandClass(GetMetaDataList);
        }


        private void GetMetaDataList()
        {
            MetaDataRuleRepository repo = new MetaDataRuleRepository();
            repo.GetItems();
        }

        public class GetMetaDataListCommandClass : ICommand
        {

            Action _executeMethod;

            public GetMetaDataListCommandClass(Action getMetaDataList)
            {
                _executeMethod = getMetaDataList;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;
            // I just guessed at this part.  Need to implement correctly.
            public void OnCanExecuteChanged()
            {
                if (CanExecuteChanged != null)
                {

                }
            }

            public void Execute(object parameter)
            {
                throw new NotImplementedException();
            }
        }


    }
}
