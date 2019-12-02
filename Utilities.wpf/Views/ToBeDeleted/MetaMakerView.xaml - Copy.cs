using Core.Common.Extensions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Utilities.BL.Models;


namespace Utilities.wpf.Views
{
    /// <summary>
    /// Interaction logic for MetaMakerView.xaml
    /// </summary>
    public partial class MetaMakerView : UserControl
    {
        public MetaMakerView()
        {
            InitializeComponent();

            //var viewModel = (MetaMakerViewModel)this.DataContext;

            //viewModel.DynamicGridViewModel = new DynamicGridViewModel("cust","state", "0R");

        }

        //private void GetGridButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ucDynamicGrid.BuildDynamicGrid("cust", "state", "0R");
        //}

        private void MetaSourceDataListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TableName selectedTableName = (TableNamesComboBox.SelectedValue == null) ? (TableName)TableNamesComboBox.Items[0] : (TableName)TableNamesComboBox.SelectedValue;
            string tablename = selectedTableName.OriginalName;
            
            MetaSourceField selectedField = (MetaSourceFieldsListView.SelectedValue == null) ? (MetaSourceField)MetaSourceFieldsListView.Items[0] : (MetaSourceField)MetaSourceFieldsListView.SelectedValue;
            string fieldname = selectedField.FieldName;

            MetaSourceData selectedFieldValue = (MetaSourceDataListBox.SelectedValue == null) ? (MetaSourceData)MetaSourceDataListBox.Items[0] : (MetaSourceData)MetaSourceDataListBox.SelectedValue;
            string fieldvalue = selectedFieldValue.FieldValue;

            ucDynamicGrid.BuildDynamicGrid(tablename, fieldname, fieldvalue);
           
        }

        private void GridSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GeneralTransform generalTransform = this.TransformToVisual(metaMatcherGrid);
            Point point = generalTransform.Transform(new Point());

            point.X += metaMatcherTransform.X;
            point.X -= metaMatcherColumn.ActualWidth/2;
            point.Y = 0;
            metaMatcherTransform.AnimateTo(point);
        }
    }
}
