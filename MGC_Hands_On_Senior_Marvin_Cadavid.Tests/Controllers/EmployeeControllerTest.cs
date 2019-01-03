using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MGC_Hands_On_Senior_Marvin_Cadavid.Controllers;
using Rhino.Mocks;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business.Interface;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;
using System.Collections.Generic;
using System.Linq;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        List<Employee> list = new List<Employee>();
        IEmployeeBusiness mockBusiness = MockRepository.GenerateMock<IEmployeeBusiness>();

        [TestInitialize]
        public void TestInitialize()
        {
            list.Add(new Employee
            {
                id=1,
                name="Marvin",
                annualsalary=200000,
                hourlySalary = 300000,
                contractTypeName= "HourlySalaryEmployee"
            });

            list.Add(new Employee
            {
                id = 2,
                name = "Vanesa",
                annualsalary = 300000,
                hourlySalary = 500000,
                contractTypeName = "MonthlySalaryEmployee"
            });

            list.Add(new Employee
            {
                id = 3,
                name = "Sol",
                annualsalary = 500000,
                hourlySalary = 400000,
                contractTypeName = "MonthlySalaryEmployee"
            });

            mockBusiness.Stub(x => x.GetEmployees()).Return(list);
            mockBusiness.Stub(x => x.GetEmployeeById(1)).IgnoreArguments().Return(list.FirstOrDefault());
        }

        [TestMethod]
        public void GetByIdIsNotNull()
        {
          
            // Arrange
            EmployeeController controller = new EmployeeController();
            controller.objemployeebusiness = mockBusiness;

            // Act
            System.Web.Http.IHttpActionResult result = controller.Get(1) as System.Web.Http.IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetIsNotNull()
        {

            // Arrange
            EmployeeController controller = new EmployeeController();
            controller.objemployeebusiness = mockBusiness;

            // Act
            System.Web.Http.IHttpActionResult result = controller.Get() as System.Web.Http.IHttpActionResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
