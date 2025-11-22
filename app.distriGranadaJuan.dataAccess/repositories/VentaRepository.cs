using app.distriGranadaJuan.dataAccess.context;
using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public class VentaRepository : CrudGenericService<Venta>, IVentaRepository
    {
        public VentaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Venta> CreateItem(Venta entity)
        {

            return await InsertEntity(entity);

        }

        public async Task DeleteItem(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<Venta> GetItem(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<Venta>> GetItemLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateItem(Venta entity)
        {
            await UpdateEntity(entity);
        }
    }
}

