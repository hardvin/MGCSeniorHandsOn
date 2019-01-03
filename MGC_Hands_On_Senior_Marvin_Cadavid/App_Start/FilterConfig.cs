using System.Web;
using System.Web.Mvc;

namespace MGC_Hands_On_Senior_Marvin_Cadavid
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
