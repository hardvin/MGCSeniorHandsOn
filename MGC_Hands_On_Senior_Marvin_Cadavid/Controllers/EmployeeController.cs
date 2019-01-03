using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;
using MGC_Hands_On_Senior_Marvin_Cadavid.Business.Interface;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEmployeeBusiness objemployeebusiness = new EmployeeBusiness();

        [HttpGet]
        public IHttpActionResult Get(int? id = null)
        {
            List<Employee> result = new List<Employee>();
            if (id != null)
            {
                Employee employee = objemployeebusiness.GetEmployeeById((int)id);
                result.Add(employee);
            }
            else
            {
                result = objemployeebusiness.GetEmployees();
            }

            return this.Ok(result);
        }
    }
}
