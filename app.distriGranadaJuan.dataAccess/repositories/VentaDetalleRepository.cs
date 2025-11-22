using app.distriGranadaJuan.dataAccess.context;
using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public class VentaDetalleRepository : CrudGenericService<VentaDetalle>, IVentaDetalleRepository
    {
        public VentaDetalleRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<VentaDetalle> CreateItem(VentaDetalle entity)
        {

            return await InsertEntity(entity);

        }

        public async Task DeleteItem(int id)
        {
            await DeleteEntity(id);
        }

        public async Task<VentaDetalle> GetItem(int id)
        {
            return await SelectEntity(id);
        }

        public async Task<List<VentaDetalle>> GetItemLista()
        {
            return await SelectEntitiesAll();
        }

        public async Task UpdateItem(VentaDetalle entity)
        {
            await UpdateEntity(entity);
        }
    }
}

