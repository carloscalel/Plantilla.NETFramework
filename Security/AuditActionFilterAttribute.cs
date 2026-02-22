using System;
using System.Linq;
using System.Web.Mvc;
using MyApp.Web.Data;

namespace MyApp.Web.Security
{
    public class AuditActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var method = filterContext.HttpContext.Request.HttpMethod;
            if (!new[] { "POST", "PUT", "DELETE" }.Contains(method)) return;

            using (var db = new DbContextApp())
            {
                db.AuditoriasCrud.Add(new AuditoriaCrud
                {
                    Entidad = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Operacion = filterContext.ActionDescriptor.ActionName,
                    ClaveRegistro = filterContext.HttpContext.Request["id"],
                    ValoresNuevos = string.Join(";", filterContext.ActionParameters.Select(kv => $"{kv.Key}:{kv.Value}")),
                    UsuarioDominio = filterContext.HttpContext.User?.Identity?.Name,
                    Fecha = DateTime.Now,
                    Ip = filterContext.HttpContext.Request.UserHostAddress
                });
                db.SaveChanges();
            }
        }
    }
}
