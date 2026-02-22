using System.Web.Mvc;
using MyApp.Web.Security;

namespace MyApp.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalExceptionFilterAttribute());
            filters.Add(new AuditActionFilterAttribute());
            filters.Add(new DomainUserSessionFilterAttribute());
        }
    }
}
