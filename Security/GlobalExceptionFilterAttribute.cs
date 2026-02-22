using System.Web.Mvc;

namespace MyApp.Web.Security
{
    public class GlobalExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilterAttribute() : this(new Logger()) { }

        public GlobalExceptionFilterAttribute(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled) return;

            var user = filterContext.HttpContext.User?.Identity?.Name;
            _logger.Error("Error no controlado", filterContext.Exception, user);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}
