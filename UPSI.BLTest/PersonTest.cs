using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UPSI.BL.BusinessEntities;


namespace UPSI.BLTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            // -- Arrange
            Person person = new Person();
            person.FirstName = "Bilbo";
            person.LastName = "Baggins";
            string expected = "Baggins, Bilbo";

            // -- Act
            string actual = person.FullName;

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            // -- Arrange
            Person person = new Person();
            person.LastName = "Baggins";
            string expected = "Baggins";

            // -- Act
            string actual = person.FullName;

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            // -- Arrange
            Person person = new Person();
            person.FirstName = "Bilbo";
            string expected = "Bilbo";

            // -- Act
            string actual = person.FullName;
            
                // -- Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void StaticTest()
        {
            // -- Arrange

            var p1 = new Person();
            p1.FirstName = "Bilbo";
            Person.InstanceCount += 1;

            var p2 = new Person();
            p2.FirstName = "Frodo";
            Person.InstanceCount += 1;

            var p3 = new Person();
            p3.FirstName = "Rosie";
            Person.InstanceCount += 1;

            // -- Act
            

            // -- Assert
            Assert.AreEqual(3, Person.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            // -- Arrange
            var person = new Person();
            person.LastName = "Baggins";

            var expected = true;

            // -- Act
            var actual = person.Validate();

            // -- Assert
            Assert.AreEqual(expected, actual);
        }


       [TestMethod]
       public void ValidateMissingLastName()
       {
           // -- Arrange
           var person = new Person();
           person.LastName = string.Empty;

           var expected = false;

           // -- Act
           var actual = person.Validate();

           // -- Assert
           Assert.AreEqual(expected, actual);

        }
        
    }
}
