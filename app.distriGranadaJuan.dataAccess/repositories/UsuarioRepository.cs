using app.distriGranadaJuan.dataAccess.context;
using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public class UsuarioRepository : CrudGenericService<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Usuario> CreateItem(Usuario entity)
        {

            return await InsertEntity(entity);

        }

        public async Task DeleteItem(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Usuario> GetItem(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Usuario>> GetItemLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateItem(Usuario entity)
        {
            await UpdateEntity(entity);
        }
    }
}

