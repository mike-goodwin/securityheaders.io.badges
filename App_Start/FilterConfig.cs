using System.Web;
using System.Web.Mvc;

namespace SecurityHeaders.io.badges
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
