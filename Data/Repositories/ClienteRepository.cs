using System.Collections.Generic;
using System.Linq;
using MyApp.Web.Models.Entities;

namespace MyApp.Web.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContextApp _db;

        public ClienteRepository(DbContextApp db)
        {
            _db = db;
        }

        public IEnumerable<Cliente> GetAll() => _db.Clientes.ToList();

        public Cliente GetById(int id) => _db.Clientes.FirstOrDefault(x => x.Id == id);

        public void Add(Cliente cliente) => _db.Clientes.Add(cliente);

        public void Update(Cliente cliente) => _db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;

        public void Delete(Cliente cliente) => _db.Clientes.Remove(cliente);
    }
}
