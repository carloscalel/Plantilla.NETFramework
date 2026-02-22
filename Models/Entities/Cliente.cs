using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Web.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Correo { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
}
