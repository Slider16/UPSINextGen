using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.DL.Repositories;
using System.Collections.ObjectModel;
using Utilities.BL.Models;

namespace Utilities.DLTest
{
    [TestClass]
    public class DynamicGridRecordRepoTest
    {
        [TestMethod]
        public void GetFieldValueOwnerRecordsTest()
        {
            // -- Arrange

            string tablename = "nameplat";
            string fieldname = "equip_type";
            string fieldvalue = "REG";

            ObservableCollection<DynamicGridRecord> recordList = new ObservableCollection<DynamicGridRecord>();

            DynamicGridRecordRepository repo = new DynamicGridRecordRepository();

            // -- Act
            recordList = repo.GetFieldValueOwnerRecords(tablename, fieldname, fieldvalue);

            // -- Assert
            Assert.IsNotNull(recordList);
        }
    }
}
