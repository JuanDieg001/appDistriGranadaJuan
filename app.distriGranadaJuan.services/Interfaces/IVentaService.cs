using app.distriGranadaJuan.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.services.Interfaces
{
    public interface IVentaService
    {

        Task<BaseResponse<VentaDto>> GetItem(int id);


        Task<BaseResponse<List<VentaDto>>> GetItemsList();


        Task<BaseResponse<VentaDto>> CrearItem(VentaDto param);


        Task<BaseResponse<VentaDto>> ActualizarItem(int id, VentaDto param);


        Task<BaseResponse<string>> EliminarItem(int id);
    }
}

