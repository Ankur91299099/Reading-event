using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.BookReading.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Nagarro.BookReading.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod]

        public void PrivacyTest()
        {

            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Privacy() as Microsoft.AspNetCore.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Privacy", result.ViewName);
        }

        [TestMethod]
        public void CustomerTest()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.Customer() as Microsoft.AspNetCore.Mvc.ViewResult;

            // Assert
            Assert.AreEqual("Customer", result.ViewName);
        }

        [TestMethod]
        public void AboutTest()
        {
            // Arrange
            var controller = new HomeController(null);

            // Act
            var result = controller.About() as Microsoft.AspNetCore.Mvc.ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("About", result.ViewName);
        }
    }
}