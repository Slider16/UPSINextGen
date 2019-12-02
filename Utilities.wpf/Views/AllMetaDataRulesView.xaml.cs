using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities.wpf.ViewModels;

namespace Utilities.wpf.Views
{
    /// <summary>
    /// Interaction logic for AllMetaDataRulesView.xaml
    /// </summary>
    public partial class AllMetaDataRulesView : UserControl
    {
        public AllMetaDataRulesView()
        {
            InitializeComponent();
        }

        // Get a count of selectedItems and pass it back to the SelectedItemsCount property on the ViewModel 
        // in order to enable and disable the Delete button.
        private void AllMetaDataRulesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dc = (AllMetaDataRulesViewModel)this.DataContext;
            if (dc != null)
            {
                var metaDataRuleItems = (ListView)sender;

                dc.SelectedItemsCount = metaDataRuleItems.SelectedItems.Count;
            }
        }
    }
}
