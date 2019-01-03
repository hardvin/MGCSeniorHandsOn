using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MGC_Hands_On_Senior_Marvin_Cadavid
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
