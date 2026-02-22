using System.Linq;
using System.Web.Mvc;
using MyApp.Web.Data;
using MyApp.Web.Models.Security;

namespace MyApp.Web.Security
{
    public class DomainUserSessionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = filterContext.HttpContext;
            if (!context.User.Identity.IsAuthenticated) return;

            if (context.Session["UsuarioSesion"] != null) return;

            var domainUser = context.User.Identity.Name;
            using (var db = new DbContextApp())
            {
                var roles = db.UsuariosAccesos
                    .Where(x => x.UsuarioDominio == domainUser && x.Activo)
                    .Select(x => x.RolCodigo)
                    .ToList();

                context.Session["UsuarioSesion"] = new UsuarioSesion
                {
                    UsuarioDominio = domainUser,
                    NombreCompleto = domainUser,
                    Roles = roles
                };
            }
        }
    }
}
