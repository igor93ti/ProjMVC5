using ProjMVC5.Infra.CrossCutting.MvcFilters;
using System.Web;
using System.Web.Mvc;

namespace ProjMVC5.UI.Sistema
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
