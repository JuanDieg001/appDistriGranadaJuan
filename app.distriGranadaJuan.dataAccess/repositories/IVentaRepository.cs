using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public interface IVentaRepository
    {
        Task<Venta> GetItem(int id);

        Task<Venta> CreateItem(Venta entity);

        Task<List<Venta>> GetItemLista();

        Task UpdateItem(Venta entity);

        Task DeleteItem(int id);
    }
}
