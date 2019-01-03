using MGC_Hands_On_Senior_Marvin_Cadavid.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGC_Hands_On_Senior_Marvin_Cadavid.DAL;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business.Interface;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business.SalaryCalculator;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private IEmployeeRepository Repository { get; set; }
        private FactorySalaryCalculator calculatorfactory = new FactorySalaryCalculator();

        public EmployeeBusiness()
        {
            Repository = new ApiEmployeeRepository();
        }

        public EmployeeBusiness(IEmployeeRepository repository)
        {
            if (repository != null)
            {
                Repository = repository;
            }
            else
            {
                Repository = new ApiEmployeeRepository();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee result = Repository.GetById(id);
            if (result != null)
            {
                ISalaryCalculator calculator = calculatorfactory.GetInstance(result);
                result.annualsalary = calculator.CalculateSalary();
            }

            return result;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> result = Repository.Get();
            if (result != null && result.Count > 0)
            {
                ISalaryCalculator calculator;
                foreach (var employee in result)
                {
                    calculator = calculatorfactory.GetInstance(employee);
                    employee.annualsalary = calculator.CalculateSalary();
                }
            }

            return result;
        }
    }
}
