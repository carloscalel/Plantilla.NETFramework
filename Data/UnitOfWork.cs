using System;
using MyApp.Web.Data.Repositories;

namespace MyApp.Web.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContextApp _db = new DbContextApp();
        public IClienteRepository Clientes { get; }

        public UnitOfWork()
        {
            Clientes = new ClienteRepository(_db);
        }

        public int Save() => _db.SaveChanges();

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
