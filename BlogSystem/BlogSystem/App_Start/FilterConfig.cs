using System.Web;
using System.Web.Mvc;
using BlogSystem.Filters;

namespace BlogSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new NotFoundRedirect());
        }
    }
}
