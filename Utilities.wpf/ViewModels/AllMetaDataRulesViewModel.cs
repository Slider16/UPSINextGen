using Core.Common;
using Core.Common.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.EventArguments;
using Utilities.DL.Repositories;
using Utilities.wpf.Properties;

namespace Utilities.wpf.ViewModels
{
    /// <summary>
    /// Represents a container of MetaDataRuleViewModel objects
    /// that has support for staying synchronized with the 
    /// MetaDataRuleRepository.  
    /// </summary>
    public class AllMetaDataRulesViewModel : WorkspaceViewModel
    {
        #region Fields
        
        readonly MetaDataRuleRepository _metaDataRuleRepository;

        RelayCommand _deleteCommand;

        

        #endregion // Fields

        #region Constructor

        public AllMetaDataRulesViewModel(MetaDataRuleRepository metaDataRuleRepository)
        {
            if (metaDataRuleRepository == null)
                throw new ArgumentNullException("metaDataRuleRepository");

            base.DisplayName = Strings.AllMetaDataRulesViewModel_DisplayName;

            _metaDataRuleRepository = metaDataRuleRepository;

            // Subscribe for notifications of when a new metaDataRule is saved.
            _metaDataRuleRepository.MetaDataRuleAdded += this.OnMetaDataRuleAddedToRepository;
                   

            // Populate the AllMetaDataRules collection with MetaDataRuleViewModels.
            CreateAllMetaDataRules();
        }
         

        private void CreateAllMetaDataRules()
        {
            List<MetaDataRuleViewModel> all =
                (from metaDataRule in _metaDataRuleRepository.GetItems()
                 select new MetaDataRuleViewModel(metaDataRule, _metaDataRuleRepository)).ToList();

            foreach (MetaDataRuleViewModel mdrvm in all)
                mdrvm.PropertyChanged += this.OnMetaDataRuleViewModelPropertyChanged;

            this.AllMetaDataRules = new ObservableCollection<MetaDataRuleViewModel>(all);
            this.AllMetaDataRules.CollectionChanged += this.OnCollectionChanged;
                    
        }

        #endregion // Constructor

        #region Presentation Properties

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(
                        param => DeleteMetaDataRule(param),
                        param => CanDelete
                        );
                }
                return _deleteCommand;
            }
        }

        // For enabling the Delete button by setting count of selected items in grid.
        public int SelectedItemsCount;

        #endregion // Presentation Properties

        #region Public Interface

        public void DeleteMetaDataRule(object selectedItems)
        {
            List<MetaDataRuleViewModel> toBeRemoved = new List<MetaDataRuleViewModel>();
            toBeRemoved.Clear();

            var metaDataRuleViewModelList = (IEnumerable)selectedItems;

            foreach(MetaDataRuleViewModel mdrVM in metaDataRuleViewModelList)
            {
                if (!mdrVM.IsValid)
                    throw new InvalidOperationException(Strings.AllMetaDataRulesViewModel_Exception_CannotSave);

                if (!mdrVM.Delete())
                    throw new Exception("Unable to delete Meta Data Rule.");

                toBeRemoved.Add(mdrVM);
            }

            foreach(MetaDataRuleViewModel mdrVM in toBeRemoved)
            {
                AllMetaDataRules.Remove(AllMetaDataRules.FirstOrDefault(m => m.MetaDataRuleID == mdrVM.MetaDataRuleID));
            }
        }

        /// <summary>
        /// Returns a collection of all the MetaDataRuleViewModel objects.
        /// </summary>
        public ObservableCollection<MetaDataRuleViewModel> AllMetaDataRules { get; private set; }

        #endregion // Public Interface
        
        #region Private Helpers

        /// <summary>
        /// Returns true if the SelectedItems count of the 
        /// bound list is greater than zero.
        /// </summary>
        private bool CanDelete
        {
            get
            {
                return SelectedItemsCount > 0;
            }
        }


        #endregion // Private Helpers
        
        #region Base Class Overrides

        protected override void OnDispose()
        {
            foreach (MetaDataRuleViewModel mdrVM in this.AllMetaDataRules)
                mdrVM.Dispose();

            this.AllMetaDataRules.Clear();
            this.AllMetaDataRules.CollectionChanged -= this.OnCollectionChanged;

            _metaDataRuleRepository.MetaDataRuleAdded -= this.OnMetaDataRuleAddedToRepository;
        }

        #endregion // Base Class Overrides
          
        #region Event Handling Methods

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (MetaDataRuleViewModel mdrVM in e.NewItems)
                    mdrVM.PropertyChanged += this.OnMetaDataRuleViewModelPropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (MetaDataRuleViewModel mdrVM in e.OldItems)
                    mdrVM.PropertyChanged -= this.OnMetaDataRuleViewModelPropertyChanged;
        }

        private void OnMetaDataRuleViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: Do we have a need for this?

            string IsSelected = "IsSelected";

            // Make sure the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            (sender as MetaDataRuleViewModel).VerifyPropertyName(IsSelected);
            

            // When a metadatarule is selected or unselected, we can execute
            // any code that we need to here.
            
            //if (e.PropertyName == IsSelected) 
                // Fire some OnPropertyChanged event here

        }

        private void OnMetaDataRuleAddedToRepository(object sender, MetaDataRuleAddedEventArgs e)
        {
            var viewModel = new MetaDataRuleViewModel(e.NewMetaDataRule, _metaDataRuleRepository);
            this.AllMetaDataRules.Add(viewModel);
        }

        private void OnMetaDataRuleUpdated(object sender, MetaDataRuleUpdatedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion // Event Handling Methods
    }
}
