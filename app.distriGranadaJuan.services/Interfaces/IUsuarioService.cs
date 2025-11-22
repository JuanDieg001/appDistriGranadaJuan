using app.distriGranadaJuan.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.services.Interfaces
{
    public interface IUsuarioService
    {

        Task<BaseResponse<UsuarioDto>> GetItem(int id);


        Task<BaseResponse<List<UsuarioDto>>> GetItemsList();


        Task<BaseResponse<UsuarioDto>> CrearItem(UsuarioDto param);


        Task<BaseResponse<UsuarioDto>> ActualizarItem(int id, UsuarioDto param);


        Task<BaseResponse<string>> EliminarItem(int id);
    }
}

