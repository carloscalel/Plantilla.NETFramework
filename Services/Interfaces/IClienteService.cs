using System.Collections.Generic;
using MyApp.Web.Models.ViewModels;

namespace MyApp.Web.Services.Interfaces
{
    public interface IClienteService
    {
        IEnumerable<ClienteVM> GetAll(string usuarioDominio);
        ClienteVM GetById(int id, string usuarioDominio);
        void Create(ClienteVM cliente, string usuarioDominio);
        void Update(ClienteVM cliente, string usuarioDominio);
        void Delete(int id, string usuarioDominio);
    }
}
