using app.distriGranadaJuan.entities.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.dataAccess.repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetItem(int id);

        Task<Usuario> CreateItem(Usuario entity);

        Task<List<Usuario>> GetItemLista();

        Task UpdateItem(Usuario entity);

        Task DeleteItem(int id);
    }
}
