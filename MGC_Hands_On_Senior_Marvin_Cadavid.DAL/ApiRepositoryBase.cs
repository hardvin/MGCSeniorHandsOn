using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MGC_Hands_On_Senior_Marvin_Cadavid.DAL
{
    public class ApiRepositoryBase
    {
        private HttpClient ClientHttp { get; set; }
        private string Url { get; set; }

        public ApiRepositoryBase(string entityname)
        {
            ClientHttp = new HttpClient();
            ClientHttp.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Url = $"http://masglobaltestapi.azurewebsites.net/api/{entityname}";
        }

        public HttpResponseMessage ExecuteGet()
        {
            HttpResponseMessage response = ClientHttp.GetAsync(Url).Result;
            return response;
        }
    }
}
