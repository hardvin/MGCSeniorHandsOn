using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Business.Interface
{
    public interface IEmployeeBusiness
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployees();
    }
}
