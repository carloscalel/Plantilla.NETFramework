using System.Web.Mvc;

namespace MyApp.Web.Controllers
{
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View("~/Views/Shared/AccessDenied.cshtml");
        }
    }
}
