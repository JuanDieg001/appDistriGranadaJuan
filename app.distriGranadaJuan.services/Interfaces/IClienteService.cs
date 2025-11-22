using app.distriGranadaJuan.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.services.Interfaces
{
    public interface IClienteService
    {
        Task<BaseResponse<ClienteDto>> GetItem(int id);


        Task<BaseResponse<List<ClienteDto>>> GetItemsList();


        Task<BaseResponse<ClienteDto>> CrearItem(ClienteDto param);


        Task<BaseResponse<ClienteDto>> ActualizarItem(int id, ClienteDto param);


        Task<BaseResponse<string>> EliminarItem(int id);
    }
}
