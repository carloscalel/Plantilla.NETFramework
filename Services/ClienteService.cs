using System;
using System.Linq;
using MyApp.Web.Data;
using MyApp.Web.Models.Entities;
using MyApp.Web.Models.ViewModels;
using MyApp.Web.Services.Interfaces;

namespace MyApp.Web.Services
{
    public class ClienteService : IClienteService
    {
        public System.Collections.Generic.IEnumerable<ClienteVM> GetAll(string usuarioDominio)
        {
            using (var uow = new UnitOfWork())
            {
                return uow.Clientes.GetAll().Select(c => new ClienteVM
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Correo = c.Correo,
                    Activo = c.Activo,
                    PuedeEditar = true,
                    PuedeEliminar = true
                }).ToList();
            }
        }

        public ClienteVM GetById(int id, string usuarioDominio)
        {
            using (var uow = new UnitOfWork())
            {
                var c = uow.Clientes.GetById(id);
                if (c == null) return null;
                return new ClienteVM { Id = c.Id, Nombre = c.Nombre, Correo = c.Correo, Activo = c.Activo };
            }
        }

        public void Create(ClienteVM cliente, string usuarioDominio)
        {
            using (var uow = new UnitOfWork())
            {
                uow.Clientes.Add(new Cliente
                {
                    Nombre = cliente.Nombre,
                    Correo = cliente.Correo,
                    Activo = cliente.Activo,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = usuarioDominio
                });
                uow.Save();
            }
        }

        public void Update(ClienteVM cliente, string usuarioDominio)
        {
            using (var uow = new UnitOfWork())
            {
                var entity = uow.Clientes.GetById(cliente.Id);
                entity.Nombre = cliente.Nombre;
                entity.Correo = cliente.Correo;
                entity.Activo = cliente.Activo;
                entity.FechaActualizacion = DateTime.Now;
                entity.UsuarioActualizacion = usuarioDominio;
                uow.Clientes.Update(entity);
                uow.Save();
            }
        }

        public void Delete(int id, string usuarioDominio)
        {
            using (var uow = new UnitOfWork())
            {
                var entity = uow.Clientes.GetById(id);
                if (entity == null) return;
                uow.Clientes.Delete(entity);
                uow.Save();
            }
        }
    }
}
