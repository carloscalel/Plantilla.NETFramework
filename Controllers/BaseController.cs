using System.Web.Mvc;
using MyApp.Web.Models.Security;

namespace MyApp.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected UsuarioSesion UsuarioSesion => Session?["UsuarioSesion"] as UsuarioSesion;

        protected bool Puede(string permiso)
        {
            return UsuarioSesion != null && UsuarioSesion.TieneRol(permiso);
        }
    }
}
