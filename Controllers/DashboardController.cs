using System.Linq;
using System.Web.Mvc;
using MyApp.Web.Data;
using MyApp.Web.Models.ViewModels;

namespace MyApp.Web.Controllers
{
    public class DashboardController : BaseController
    {
        public ActionResult Index()
        {
            using (var db = new DbContextApp())
            {
                var vm = new DashboardVM
                {
                    TotalClientes = db.Clientes.Count(),
                    ClientesActivos = db.Clientes.Count(x => x.Activo),
                    UsuarioDominio = User.Identity.Name
                };

                return View(vm);
            }
        }
    }
}
