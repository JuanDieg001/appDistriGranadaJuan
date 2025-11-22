using app.distriGranadaJuan.dataAccess.context;
using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public class ProductoRepository : CrudGenericService<Producto>, IProductoRepository
    {
        public ProductoRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Producto> CreateItem(Producto entity)
        {

            return await InsertEntity(entity);

        }

        public async Task DeleteItem(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Producto> GetItem(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Producto>> GetItemLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateItem(Producto entity)
        {
            await UpdateEntity(entity);
        }
    }
}

