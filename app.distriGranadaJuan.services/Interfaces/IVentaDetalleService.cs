using app.distriGranadaJuan.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.services.Interfaces
{
    public interface IVentaDetalleService
    {

        Task<BaseResponse<VentaDetalleDto>> GetItem(int id);


        Task<BaseResponse<List<VentaDetalleDto>>> GetItemsList();


        Task<BaseResponse<VentaDetalleDto>> CrearItem(VentaDetalleDto param);


        Task<BaseResponse<VentaDetalleDto>> ActualizarItem(int id, VentaDetalleDto param);


        Task<BaseResponse<string>> EliminarItem(int id);
    }
}

