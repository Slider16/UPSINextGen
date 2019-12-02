using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Core.Common;
using UPSI.BL.BusinessEntities;


namespace Core.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            // Arrange
            var changedItems = new List<ILoggable>();

            var customer = new Customer()
            {
                BusinessEntityID = 1,
                UpsiCustomerNumber = "MN1000045",
                CustomerName = "Minnesota Steel Works",
                HasChanges = true
            };
            changedItems.Add(customer as ILoggable);

            var address = new Address()
            {
                AddressLine1 = "128 St Paul St",
                City = "Houma",
                StateProvinceID = 2,
                PostalCode = "70364",
                Country = "USA"
            };
            changedItems.Add(address as ILoggable);
            
            // Act
            LoggingService.WriteToFile(changedItems);

            // Assert
            // Nothing here to assert.
        }
    }
}
