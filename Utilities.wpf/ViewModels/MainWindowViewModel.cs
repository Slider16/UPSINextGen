using Core.Common;
using Core.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Utilities.BL.Models;
using Utilities.DL.Repositories;
using Utilities.wpf.Properties;

namespace Utilities.wpf.ViewModels
{
    /// <summary>
    /// The ViewModel for the application's main window.
    /// </summary>
    public class MainWindowViewModel : WorkspaceViewModel
    {
        #region Fields

        private ReadOnlyCollection<CommandViewModel> _commands;
        readonly MetaDataRuleRepository _metaDataRuleRepository;
        private ObservableCollection<WorkspaceViewModel> _workspaces;

        #endregion // Fields

        #region Constructor

        public MainWindowViewModel()
        {
            base.DisplayName = Strings.MainWindowViewModel_DisplayName;

            _metaDataRuleRepository = new MetaDataRuleRepository();
        }

        #endregion // Constructor

        #region Commands

        /// <summary>
        /// MainwWindowViewModel Commands Collection.
        /// Returns a read-only list of commands
        /// that the UI can display and execute.
        /// </summary>
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _commands;
            } 
        }

        /// <summary>
        /// A list of command view models used by the Main Window
        /// </summary>
        /// <returns></returns>
        private List<CommandViewModel> CreateCommands()
        {
            return new List<CommandViewModel>
            {
                new CommandViewModel(
                    Strings.StageDataViewModel_DisplayName,
                    new RelayCommand(param => this.StageData())),

                new CommandViewModel(
                    Strings.MetaMakerViewModel_DisplayName,
                    new RelayCommand(param => this.ShowMetaMaker())),

                new CommandViewModel(
                    Strings.AllMetaDataRulesViewModel_DisplayName,
                    new RelayCommand(param => this.ShowAllMetaDataRules()))

            };
        }




        #endregion // Commands

        #region Workspaces

        /// <summary>
        /// Returns the collection of available workspaces to display.
        /// A 'workspace' is a ViewModel that can request to be closed.
        /// </summary>
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if ( _workspaces == null)
                {
                    _workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _workspaces;
            }
        }

        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
           if (e.NewItems != null && e.NewItems.Count != 0)
           {
               foreach (WorkspaceViewModel workspace in e.NewItems)
               {
                   workspace.RequestClose += this.OnWorkspaceRequestClose;
               }
           }

            if (e.OldItems != null && e.OldItems.Count != 0)
            {
                foreach (WorkspaceViewModel workspace in e.OldItems)
                {
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
                }
            }
        }

        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            workspace.Dispose();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers

        // This area reserved for the actual methods that serve as
        // parametes for the new RelayCommands() that populate
        // the List<CommandViewModels> in the CreateCommands() method
        // above.

        private void StageData()
        {
            //throw new NotImplementedException();
        }
        
        private void ShowMetaMaker()
        {
            MetaMakerViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is MetaMakerViewModel)
                as MetaMakerViewModel;

            if (workspace == null)
            {
                MetaDataRule newMetaDataRule = MetaDataRule.CreateNewMetaDataRule();
                workspace = new MetaMakerViewModel(newMetaDataRule,  _metaDataRuleRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);
        }

        private void ShowAllMetaDataRules()
        {
            AllMetaDataRulesViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is AllMetaDataRulesViewModel)
                as AllMetaDataRulesViewModel;

            if (workspace == null)
            {
                workspace = new AllMetaDataRulesViewModel(_metaDataRuleRepository);
                this.Workspaces.Add(workspace);
            }

            this.SetActiveWorkspace(workspace);            
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionVew = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionVew != null)
                collectionVew.MoveCurrentTo(workspace);
        }

        #endregion // Private Helpers

    }
}
