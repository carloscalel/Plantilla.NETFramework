using System.Web.Mvc;
using MyApp.Web.Security;
using MyApp.Web.Services;
using MyApp.Web.Services.Interfaces;
using MyApp.Web.Models.ViewModels;

namespace MyApp.Web.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteService _service;

        public ClientesController() : this(new ClienteService()) { }

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [AuthorizeRoles("CLIENTE_VER", "ADMIN")]
        public ActionResult Index()
        {
            var model = _service.GetAll(User.Identity.Name);
            return View(model);
        }

        [AuthorizeRoles("CLIENTE_CREAR", "ADMIN")]
        public ActionResult Create() => View(new ClienteVM());

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles("CLIENTE_CREAR", "ADMIN")]
        public ActionResult Create(ClienteVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Create(vm, User.Identity.Name);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("CLIENTE_EDITAR", "ADMIN")]
        public ActionResult Edit(int id)
        {
            var vm = _service.GetById(id, User.Identity.Name);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles("CLIENTE_EDITAR", "ADMIN")]
        public ActionResult Edit(ClienteVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Update(vm, User.Identity.Name);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("CLIENTE_ELIMINAR", "ADMIN")]
        public ActionResult Delete(int id)
        {
            var vm = _service.GetById(id, User.Identity.Name);
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizeRoles("CLIENTE_ELIMINAR", "ADMIN")]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id, User.Identity.Name);
            return RedirectToAction("Index");
        }
    }
}
