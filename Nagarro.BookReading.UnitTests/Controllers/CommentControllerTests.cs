using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nagarro.BookReading.Core.Entities;
using Nagarro.BookReading.Web.Controllers;
using Nagarro.BookReading.Web.Interfaces;
using Nagarro.BookReading.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookReading.Web.Controllers.Tests
{
    [TestClass()]
    public class CommentControllerTests
    {
        [TestMethod]
        public void IndexTest()
        {
            // Arrange
            var controller = new CommentController(null);

            // Act
            var result = controller.Index() as Microsoft.AspNetCore.Mvc.ViewResult;

            // Assert
            //Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}