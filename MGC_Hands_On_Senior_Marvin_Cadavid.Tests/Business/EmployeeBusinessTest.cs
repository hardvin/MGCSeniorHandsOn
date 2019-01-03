using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Rhino.Mocks;
using MGC_Hands_On_Senior_Marvin_Cadavid.DAL.Interface;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business.Interface;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Tests.Business
{
    [TestClass]
    public class EmployeeBusinessTest
    {
        private IEmployeeRepository repository;

        List<Employee> list = new List<Employee>();

        [TestInitialize]
        public void Initialize()
        {
            list.Add(new Employee
            {
                id = 1,
                name = "Marvin",
                monthlySalary = 200000,
                hourlySalary = 300000,
                contractTypeName = "HourlySalaryEmployee"
            });

            list.Add(new Employee
            {
                id = 2,
                name = "Vanesa",
                monthlySalary = 300000,
                hourlySalary = 500000,
                contractTypeName = "MonthlySalaryEmployee"
            });

            list.Add(new Employee
            {
                id = 3,
                name = "Sol",
                monthlySalary = 500000,
                hourlySalary = 400000,
                contractTypeName = "MonthlySalaryEmployee"
            });

            repository = MockRepository.GenerateMock<IEmployeeRepository>();

            repository.Stub(x => x.Get()).Return(list);
            repository.Stub(x => x.GetById(1)).Return(list.FirstOrDefault(x => x.id == 1));
            repository.Stub(x => x.GetById(2)).Return(list.FirstOrDefault(x => x.id == 2));
        }

        [TestMethod]
        public void CalculatedHourlySalaryEmployee()
        {
            // Arrange
            IEmployeeBusiness objEmployeeBusiness = new EmployeeBusiness(repository);

            //Act
            Employee result = objEmployeeBusiness.GetEmployeeById(1);

            //Assert
            double expectedsalary = 432000000;
            Assert.AreEqual(expectedsalary, result.annualsalary);
        }


        [TestMethod]
        public void CalculatedMonthlySalaryEmployee()
        {
            // Arrange
            IEmployeeBusiness objEmployeeBusiness = new EmployeeBusiness(repository);

            //Act
            Employee result = objEmployeeBusiness.GetEmployeeById(2);

            //Assert
            double expectedsalary = 3600000;
            Assert.AreEqual(expectedsalary, result.annualsalary);
        }

        [TestMethod]
        public void CalculatedMultipleEmployee()
        {
            // Arrange
            IEmployeeBusiness objEmployeeBusiness = new EmployeeBusiness(repository);

            //Act
            List<Employee> result = objEmployeeBusiness.GetEmployees();

            //Assert
            double expectedsalary1 = 432000000;
            double expectedsalary2 = 3600000;
            double expectedsalary3 = 6000000;

            Assert.AreEqual(expectedsalary1, result[0].annualsalary);
            Assert.AreEqual(expectedsalary2, result[1].annualsalary);
            Assert.AreEqual(expectedsalary3, result[2].annualsalary);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidEnumArgumentException))]

        public void FactoryFailTypeOfSalary()
        {
            // Arrange
            repository.Stub(x => x.GetById(4)).Return((new Employee
            {
                id = 1,
                name = "Other Employee",
                monthlySalary = 200000,
                hourlySalary = 300000,
                contractTypeName = "WeekSalaryEmployee"
            }));

            IEmployeeBusiness objEmployeeBusiness = new EmployeeBusiness(repository);

            //Act
            Employee result = objEmployeeBusiness.GetEmployeeById(4);

        }
    }
}
