using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Web.Security
{
    public class UsuarioAcceso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string UsuarioDominio { get; set; }
        [Required]
        [StringLength(100)]
        public string RolCodigo { get; set; }
        public bool Activo { get; set; }
    }

    public class Rol
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Codigo { get; set; }
        [StringLength(200)]
        public string Nombre { get; set; }
    }

    public class Permiso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Codigo { get; set; }
        [StringLength(200)]
        public string Nombre { get; set; }
    }

    public class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }

    public class AuditoriaCrud
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string Operacion { get; set; }
        public string ClaveRegistro { get; set; }
        public string ValoresAnteriores { get; set; }
        public string ValoresNuevos { get; set; }
        public string UsuarioDominio { get; set; }
        public DateTime Fecha { get; set; }
        public string Ip { get; set; }
    }

    public class LogAplicacion
    {
        public int Id { get; set; }
        public string Nivel { get; set; }
        public string Mensaje { get; set; }
        public string Detalle { get; set; }
        public string UsuarioDominio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
