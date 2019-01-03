using MGC_Hands_On_Senior_Marvin_Cadavid.DAL.Interface;
using MGC_Hands_On_Senior_Marvin_Cadavid.DTO;
using MGC_Hands_On_Senior_Marvin_Cadavid.Model.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.DAL
{
    public class ApiEmployeeRepository : ApiRepositoryBase, IEmployeeRepository
    {
        public ApiEmployeeRepository() : base(EntityNames.Employees)
        {

        }

        public List<Employee> Get()
        {
            string employeesresponsestring = null;
            List<Employee> employees = null;

            HttpResponseMessage response = this.ExecuteGet();
            if (response.IsSuccessStatusCode)
            {
                employeesresponsestring = response.Content.ReadAsStringAsync().Result;
                employees = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(employeesresponsestring);
            }

            return employees;
        }

        public Employee GetById(int id)
        {
            List<Employee> employees = this.Get();
            return employees.FirstOrDefault(x => x.id.Equals(id));
        }
    }
}
