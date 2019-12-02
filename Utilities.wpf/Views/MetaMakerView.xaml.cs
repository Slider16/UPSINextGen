using Core.Common.Extensions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Utilities.BL.Models;
using Utilities.wpf.ViewModels;


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

            metaMatcherColumn.Width = new GridLength(400);

        }

        // Retrieve data for, and build Dynamic Grid based on table, field, and field value selected.
        private void MetaSourceDataListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dc = (MetaMakerViewModel)this.DataContext;

            var tablename = (!string.IsNullOrEmpty(dc.SelectedTable.OriginalName)) ? dc.SelectedTable.OriginalName : string.Empty;

            var fieldname = (!string.IsNullOrEmpty(dc.SelectedField.FieldName)) ? dc.SelectedField.FieldName : string.Empty;

            var fieldvalue = (!string.IsNullOrEmpty(dc.SelectedFieldValue.FieldValue) ) ? dc.SelectedFieldValue.FieldValue : string.Empty;

            ucDynamicGrid.BuildDynamicGrid(tablename, fieldname, fieldvalue);
        }

        private void GridSplitter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            GridLength currentColumnWidth = metaMatcherColumn.Width;
            if (currentColumnWidth != new GridLength(24))
            {
                metaMatcherColumn.Width = new GridLength(24);
                return;
            }
           
            metaMatcherColumn.Width = new GridLength(400);
  

            //GeneralTransform generalTransform = this.TransformToVisual(metaMatcherGrid);
            //Point gridPoint = generalTransform.Transform(new Point());

            //gridPoint.X += metaMatcherTransform.X;
            ////gridPoint.X -= metaMatcherColumn.ActualWidth / 2;
            //gridPoint.X -= metaMatcherColumn.ActualWidth * 2;
            //gridPoint.Y = 0;
            //metaMatcherTransform.AnimateTo(gridPoint);
            
        }

        // TODO: Fix Dynamic Grid vanishing when switching to AllMetaDataRules tab and back again.
        private void MetaSourceDataListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var metaDataItems = (ListView)sender;
            var selectedItemsCount = metaDataItems.SelectedItems.Count;

            if (selectedItemsCount == 0)
            {
                OldValueDisplayLabel.Content = string.Empty;
            }
            else if(selectedItemsCount > 1)
            {
                OldValueDisplayLabel.Content = string.Format("There {0} {1} items selected for rule creation.",
                (selectedItemsCount >= 2) ? "are" : "is",
                    selectedItemsCount);
            }
            else
            {
                var selectedItem = (MetaData)metaDataItems.SelectedItem;
                OldValueDisplayLabel.Content = string.Format("Old Value:          {0}", selectedItem.FieldValue);
            }

            // If there's a dynamic grid of data displayed, let's remove it since the selection on which it is based has changed.
            if (ucDynamicGrid != null)
            {
                ucDynamicGrid.dataGrid.Columns.Clear();
                ucDynamicGrid.dataGrid.ItemsSource = null;
            }
        }
    }
}
