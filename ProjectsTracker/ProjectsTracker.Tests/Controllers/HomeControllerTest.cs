﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectsTracker;
using ProjectsTracker.Controllers;

namespace ProjectsTracker.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(null, null, null);

            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }


    }
}
