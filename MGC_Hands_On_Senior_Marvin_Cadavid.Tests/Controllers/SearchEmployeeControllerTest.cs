using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGC_Hands_On_Senior_Marvin_Cadavid.Controllers;
using System.Web.Mvc;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Tests.Controllers
{
    [TestClass]
    public class SearchEmployeeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            SearchEmployeeController controller = new SearchEmployeeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
