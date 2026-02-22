using System.Data.Entity;
using MyApp.Web.Models.Entities;
using MyApp.Web.Security;

namespace MyApp.Web.Data
{
    public class DbContextApp : DbContext
    {
        public DbContextApp() : base("DefaultConnection") { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<UsuarioAcceso> UsuariosAccesos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolesPermisos { get; set; }
        public DbSet<AuditoriaCrud> AuditoriasCrud { get; set; }
        public DbSet<LogAplicacion> LogsAplicacion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolPermiso>().HasKey(x => new { x.RolId, x.PermisoId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
