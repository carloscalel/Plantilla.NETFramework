using System.Collections.Generic;
using MyApp.Web.Models.Entities;

namespace MyApp.Web.Data.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
    }
}
