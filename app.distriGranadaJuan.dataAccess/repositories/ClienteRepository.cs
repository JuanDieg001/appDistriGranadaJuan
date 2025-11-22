using app.distriGranadaJuan.dataAccess.context;
using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public class ClienteRepository : CrudGenericService<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Cliente> CreateItem(Cliente entity)
        {

            return await InsertEntity(entity);

        }

        public async Task DeleteItem(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Cliente> GetItem(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Cliente>> GetItemLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateItem(Cliente entity)
        {
            await UpdateEntity(entity);
        }
    }
}