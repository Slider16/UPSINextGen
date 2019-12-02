using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.DL.Repositories;
using Utilities.BL.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Utilities.DLTest
{
    [TestClass]
    public class MetaDataRuleRepoTest
    {
        [TestMethod]
        public void SaveNewItemTest()
        {
            // -- Arrange
            string tablename = "nameplat";
            string fieldname = "manufactur";
            string oldvalue = "SaveNew unit test.";
            string newvalue = "Added by Unit Test at" + DateTime.Now.ToString();

            MetaDataRuleRepository repo = new MetaDataRuleRepository();
            MetaDataRule rule = MetaDataRule.CreateNewMetaDataRule();
            rule.TableName = tablename;
            rule.FieldName = fieldname;
            rule.OldValue = oldvalue;
            rule.NewValue = newvalue;
            rule.HasChanges = true;
            //rule.IsNew = true;
            //MetaDataRule rule = new MetaDataRule{
            //    TableName = tablename,
            //    FieldName = fieldname, 
            //    OldValue = oldvalue,
            //    NewValue = newvalue,
            //    HasChanges = true,
            //    IsNew = true};

            // -- Act
            bool success = repo.Save(rule);

            // -- Assert
            Assert.AreEqual(true, success, "Record WAS NOT added to MetaDataRules table.");
        }

        [TestMethod]
        public void UpdateExistingItemTest()
        {
            // -- Arrange
            string newvalue = "Updated by Unit Test" + DateTime.Now.ToString();

            MetaDataRuleRepository repo = new MetaDataRuleRepository();
            MetaDataRule rule = MetaDataRule.CreateNewMetaDataRule();
            rule.TableName = "nameplat";
            rule.FieldName = "manufactur";
            rule.OldValue = "SaveNew unit test.";
            rule.NewValue = newvalue;
            rule.IsDeleted = true;
            rule.HasChanges = true;
            //rule.IsNew = false;
            //MetaDataRule rule = new MetaDataRule {
            //    TableName = "nameplat",
            //    FieldName = "manufactur",
            //    OldValue = "unit test.",
            //    NewValue = newvalue,
            //    IsDeleted = true,
            //    HasChanges = true,
            //    IsNew = false
            //};

            // -- Act
            bool success = repo.Save(rule);

            // -- Assert
            Assert.AreEqual(true, success, "Record WAS NOT updated in MetaDataRules table.");            
        }

        [TestMethod]
        public void MetaDataRulesRepoGetItemsTest()
        {
            // -- Arrange
            ObservableCollection<MetaDataRule> metaDataRules = new ObservableCollection<MetaDataRule>();

            // -- Act
            MetaDataRuleRepository repo = new MetaDataRuleRepository();
            metaDataRules = repo.GetItems();

            // Assert
            Assert.IsNotNull(repo, "Failed to instantiate MetaDataRuleRepository.");
            Assert.IsTrue(metaDataRules.Count > 0, "No metadata rules retrieved from repository.");
        }

    }
}
