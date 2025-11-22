using app.distriGranadaJuan.dataAccess.context;
using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public class CategoriaRepository : CrudGenericService<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Categoria> CreateItem(Categoria entity)
        {

            return await InsertEntity(entity);

        }

        public async Task DeleteItem(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Categoria> GetItem(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Categoria>> GetItemLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateItem(Categoria entity)
        {
            await UpdateEntity(entity);
        }
    }
}