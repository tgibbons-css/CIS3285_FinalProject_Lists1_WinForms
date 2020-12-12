using Microsoft.VisualStudio.TestTools.UnitTesting;
using CIS3285_FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS3285_FinalProject.Tests
{
    [TestClass()]
    public class ShoppingItemTests
    {

        [TestMethod()]
        public void ItemConstrutorSetsCheckedFalse()
        {
            // Arrange 
            bool isFalse = false;
            ShoppingItem testItem = new ShoppingItem("test name", 99);
            // Act
            bool result = testItem.IsChecked();
            // Assert
            Assert.AreEqual(result, isFalse);
        }

        [TestMethod()]
        public void ItemConstrutorCreatesNewGuid()
        {
            // Arrange 
            ShoppingItem testItem = new ShoppingItem("test name", 99);
            // Act
            Guid resultId = testItem.Id;
            // Assert
            Assert.IsNotNull(resultId);
        }

        [TestMethod()]
        public void IsCheckedTrue()
        {
            // Arrange 
            bool isTrue = true;
            ShoppingItem testItem = new ShoppingItem(Guid.NewGuid(), "test name", 99, isTrue);
            // Act
            bool result = testItem.IsChecked();
            // Assert
            Assert.AreEqual(result, isTrue);
        }

        [TestMethod()]
        public void IsCheckedFalse()
        {
            // Arrange 
            bool isFalse = false;
            ShoppingItem testItem = new ShoppingItem(Guid.NewGuid(), "test name", 99, isFalse);
            // Act
            bool result = testItem.IsChecked();
            // Assert
            Assert.AreEqual(result, isFalse);
        }

        [TestMethod()]
        public void ToDoMarkChecked()
        {
            // Arrange 
            ShoppingItem testItem = new ShoppingItem("test name", 99);
            // Act
            testItem.markChecked();
            bool result = testItem.IsChecked();
            // Assert
            Assert.IsTrue(result);
        }
    }
}