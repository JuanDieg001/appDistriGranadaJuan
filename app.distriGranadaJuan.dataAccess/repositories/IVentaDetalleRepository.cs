using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public interface IVentaDetalleRepository
    {
        Task<VentaDetalle> GetItem(int id);

        Task<VentaDetalle> CreateItem(VentaDetalle entity);

        Task<List<VentaDetalle>> GetItemLista();

        Task UpdateItem(VentaDetalle entity);

        Task DeleteItem(int id);
    }
}
