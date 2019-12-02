using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.BL.Models;

namespace Utilities.BLTest
{
    [TestClass]
    public class MetaDataRuleModelTest
    {
        [TestMethod]
        public void MetaDataRuleTableNameIsInvalid()
        {
            // -- Arrange

            MetaDataRule metaDataRule = MetaDataRule.CreateNewMetaDataRule();
            metaDataRule.TableName = "";
            metaDataRule.FieldName = "manufactur";
            metaDataRule.OldValue = "this is oldvalue";
            metaDataRule.NewValue = "this is newvalue";
            metaDataRule.IsDeleted = false;

            // -- Act
            var ruleIsValid = metaDataRule.Validate();

            // -- Assert
            Assert.AreEqual(false, ruleIsValid);

        }
    }
}
