using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetItem(int id);

        Task<Cliente> CreateItem(Cliente entity);

        Task<List<Cliente>> GetItemLista();

        Task UpdateItem(Cliente entity);

        Task DeleteItem(int id);
    }
}