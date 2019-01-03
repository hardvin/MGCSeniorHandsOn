using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.DAL.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        List<Employee> Get();
    }
}
