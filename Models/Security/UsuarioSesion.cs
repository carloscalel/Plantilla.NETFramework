using System.Collections.Generic;

namespace MyApp.Web.Models.Security
{
    public class UsuarioSesion
    {
        public string UsuarioDominio { get; set; }
        public string NombreCompleto { get; set; }
        public List<string> Roles { get; set; } = new List<string>();

        public bool TieneRol(string rol)
        {
            return Roles.Contains(rol);
        }
    }
}
