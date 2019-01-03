using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGC_Hands_On_Senior_Marvin_Cadavid.Model.Const;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Business.SalaryCalculator
{
    public class FactorySalaryCalculator
    {
        public ISalaryCalculator GetInstance(Employee employee)
        {
            ISalaryCalculator instance = null;
            switch (employee.contractTypeName)
            {
                case TypeOfContract.HourlySalaryEmployee:
                    instance = new HourlySalaryCalculator(employee.hourlySalary);
                    break;
                case TypeOfContract.MonthlySalaryEmployee:
                    instance = new MonthtlySalaryCalculator(employee.monthlySalary);
                    break;
                default:
                    throw new InvalidEnumArgumentException($"The type of instance {employee.contractTypeName} does not exists.");
                break;
            }

            return instance;

        }
    }
}
