using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.Web.Models.Security;

namespace MyApp.Web.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private readonly string[] _roles;

        public AuthorizeRolesAttribute(params string[] roles)
        {
            _roles = roles ?? new string[0];
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            var sesion = httpContext.Session?["UsuarioSesion"] as UsuarioSesion;
            if (sesion == null || !_roles.Any())
            {
                return false;
            }

            return _roles.Any(sesion.TieneRol);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpStatusCodeResult(403, "No autorizado");
        }
    }
}
