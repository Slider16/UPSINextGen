using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Utilities.BL.Models;
using Utilities.DL.Repositories;
using Utilities.wpf.ViewModels;
using System.Collections.ObjectModel;

namespace Utilities.wpfTest
{
    [TestClass]
    public class AllMetaDataRulesViewModelTest
    {
        [TestMethod]
        public void DeleteMetaDataRuleTest()
        {
            // -- Arrange
            var repo = new MetaDataRuleRepository();

            var metaDataRules = repo.GetItems();

            var countBeforeDeletion = metaDataRules.Count;

            MetaDataRule mdr1 = MetaDataRule.CreateNewMetaDataRule();
            mdr1.TableName = "nameplat";
            mdr1.FieldName = "manufactur";
            mdr1.OldValue = "OldTestValue1";
            mdr1.NewValue = "NewTestValue1";
  
            MetaDataRule mdr2 = MetaDataRule.CreateNewMetaDataRule();
            mdr2.TableName = "nameplat";
            mdr2.FieldName = "manufactur";
            mdr2.OldValue = "OldTestValue2";
            mdr2.NewValue = "NewTestValue2";

            MetaDataRule mdr3 = MetaDataRule.CreateNewMetaDataRule();
            mdr3.TableName ="nameplat";
            mdr3.FieldName = "manufactur";
            mdr3.OldValue = "OldTestValue3";
            mdr3.NewValue = "NewTestValue3";

            mdr1.MetaDataRuleID = repo.AddItem(mdr1);
            mdr2.MetaDataRuleID = repo.AddItem(mdr2);
            mdr3.MetaDataRuleID = repo.AddItem(mdr3);

            var viewModel = new AllMetaDataRulesViewModel(repo);

            List<MetaDataRuleViewModel> selectedItems = new List<MetaDataRuleViewModel>();
            MetaDataRuleViewModel mdrvm1 = new MetaDataRuleViewModel(mdr1, repo);
            MetaDataRuleViewModel mdrvm2 = new MetaDataRuleViewModel(mdr2, repo);
            MetaDataRuleViewModel mdrvm3 = new MetaDataRuleViewModel(mdr3, repo);

            selectedItems.Add(mdrvm1);
            selectedItems.Add(mdrvm2);
            selectedItems.Add(mdrvm3);

            // -- Act
            viewModel.DeleteMetaDataRule(selectedItems);
            

            // -- Assert
            Assert.AreEqual(viewModel.AllMetaDataRules.Count, countBeforeDeletion,  "Deleted count not correct.");
            Assert.IsTrue(mdr1.MetaDataRuleID > 0);
            Assert.IsTrue(mdr2.MetaDataRuleID > 0);
            Assert.IsTrue(mdr3.MetaDataRuleID > 0);
            
        }
    }
}
