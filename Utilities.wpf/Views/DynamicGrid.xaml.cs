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
    /// Interaction logic for DynamicGrid.xaml
    /// </summary>
    public partial class DynamicGrid : UserControl
    {
        public DynamicGrid()
        {
            InitializeComponent();
        }


        public void BuildDynamicGrid(string _tablename, string _fieldname, string _fieldvalue)
        {
            dataGrid.Columns.Clear();

            var viewModel = (DynamicGridViewModel)this.DataContext;
          
            List<DataGridTextColumn> dynamicColumnsList = viewModel.GenerateGrid(_tablename, _fieldname, _fieldvalue);

            foreach (var column in dynamicColumnsList)
            {
                dataGrid.Columns.Add(column);
            }

            dataGrid.ItemsSource = viewModel.ValueOwnerRecords;

            string sentenceBegin = (dataGrid.Items.Count > 1 ? "There are " : "There is ");
            string sentenceEnd = (dataGrid.Items.Count > 1 ? " records using the selected value." : " record using the selected value.");

            ValueOwnerRecordsCountTextBlock.Text = sentenceBegin + dataGrid.Items.Count.ToString() + sentenceEnd;
        }

    }
}
