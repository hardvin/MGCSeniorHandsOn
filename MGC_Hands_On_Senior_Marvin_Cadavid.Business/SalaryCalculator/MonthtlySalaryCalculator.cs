using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Business.SalaryCalculator
{
    public class MonthtlySalaryCalculator : ISalaryCalculator
    {
        private double BaseSalary { get; set; }
        public MonthtlySalaryCalculator(double basesalary)
        {
            BaseSalary = basesalary;
        }

        public double CalculateSalary()
        {
            return BaseSalary * 12;
        }
    }
}
