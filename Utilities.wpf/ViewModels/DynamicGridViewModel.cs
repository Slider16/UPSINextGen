using Core.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Utilities.BL.Models;
using Utilities.DL.Repositories;

namespace Utilities.wpf.ViewModels
{
    /// <summary>
    /// The ViewModel for the DynamicGridView user control.
    /// </summary>
    public class DynamicGridViewModel : ViewModelBase
    {
        #region Fields

        #endregion // Fields

        #region ObservableCollections

        /// <summary>
        /// Property to contain record of the owner of the
        /// selected field value. (i.e., show the record(s) where
        /// the value "REG" is used in the "equip_type" field.
        /// </summary>
        private ObservableCollection<DynamicGridRecord> _valueOwnerRecords;

        public ObservableCollection<DynamicGridRecord> ValueOwnerRecords
        {
            get { return _valueOwnerRecords; }
            set 
            {
                if (_valueOwnerRecords == value)
                    return;
                _valueOwnerRecords = value;
                OnPropertyChanged("ValuOwnerRecords");
            }
        }
        

        #endregion // ObservableCollections

        #region Constructor

        public DynamicGridViewModel()
        {

        }
 
        public DynamicGridViewModel(string tableName, string fieldName, string fieldValue)
        {
            this.GenerateGrid(tableName, fieldName, fieldValue);
        }


        #endregion // Constructor
           
        #region Presentation Properties
        

        #endregion // Presentation Properties


        #region Public Methods

        public List<DataGridTextColumn> GenerateGrid(string tableName, string fieldName, string fieldValue)
        {
            List<DataGridTextColumn> dynamicColumnsList = new List<DataGridTextColumn>();

            this.ValueOwnerRecords = GetDynamicGridRecords(tableName, fieldName, fieldValue);

            if (this.ValueOwnerRecords.Count > 0)
            {

                var columns = _valueOwnerRecords.FirstOrDefault().Properties.Select((x, i) => new { Name = x.Name, Index = i }).ToArray();
            
                foreach (var column in columns)
                {
                    var binding = new Binding(string.Format("Properties[{0}].Value", column.Index));

                    DataGridTextColumn dynamicColumn = new DataGridTextColumn() { Header = column.Name, Binding = binding };

                    dynamicColumnsList.Add(dynamicColumn);

                }
            }

            return dynamicColumnsList;
        }

        #endregion // Public Methods

        #region Private Helpers

        private ObservableCollection<DynamicGridRecord> GetDynamicGridRecords(string tablename, string fieldname, string fieldvalue)
        {
            DynamicGridRecordRepository dynamicGridRecordRepo = new DynamicGridRecordRepository();
            return dynamicGridRecordRepo.GetFieldValueOwnerRecords(tablename, fieldname, fieldvalue);
        }

        #endregion // Private Helpers

    }
}
