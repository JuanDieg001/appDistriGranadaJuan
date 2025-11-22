using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.dataAccess.repositories;
using app.distriGranadaJuan.entities.models;
using app.distriGranadaJuan.services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace app.distriGranadaJuan.services.Implementations
{
    public class VentaDetalleService : IVentaDetalleService
    {

        private readonly IVentaDetalleRepository _repository;


        public VentaDetalleService(IVentaDetalleRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<VentaDetalleDto>> GetItem(int id)
        {
            var response = new BaseResponse<VentaDetalleDto>();
            try
            {
                var entity = await _repository.GetItem(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new VentaDetalleDto
                {
                    Id = entity.Id,
                    VentaId = entity.VentaId,
                    NumeroItem = entity.NumeroItem,
                    ProductoId = entity.ProductoId,
                    PrecioUnitario = entity.PrecioUnitario,
                    Cantidad = entity.Cantidad,
                    Total = entity.Total
                };

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;

        }

        public async Task<BaseResponse<VentaDetalleDto>> CrearItem(VentaDetalleDto param)
        {

            var respuesta = new BaseResponse<VentaDetalleDto>();
            try
            {
                VentaDetalle entity = new();


                entity.Id = param.Id;
                entity.VentaId = param.VentaId;
                entity.NumeroItem = param.NumeroItem;
                entity.ProductoId = param.ProductoId;
                entity.PrecioUnitario = param.PrecioUnitario;
                entity.Cantidad = param.Cantidad;
                entity.Total = param.Total;

                entity = await _repository.CreateItem(entity);

                respuesta.Result = new VentaDetalleDto
                {
                    Id = entity.Id,
                    VentaId = entity.VentaId,
                    NumeroItem = entity.NumeroItem,
                    ProductoId = entity.ProductoId,
                    PrecioUnitario = entity.PrecioUnitario,
                    Cantidad = entity.Cantidad,
                    Total = entity.Total,

                };

                respuesta.Success = true;
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.ErrorMessage = ex.Message;

            }

            return respuesta;



        }

        public async Task<BaseResponse<List<VentaDetalleDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<VentaDetalleDto>>();
            try
            {
                var result = await _repository.GetItemLista();

                response.Result = result.Select(entity => new VentaDetalleDto
                {
                    Id = entity.Id,
                    VentaId = entity.VentaId,
                    NumeroItem = entity.NumeroItem,
                    ProductoId = entity.ProductoId,
                    PrecioUnitario = entity.PrecioUnitario,
                    Cantidad = entity.Cantidad,
                    Total = entity.Total,
                }).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<BaseResponse<VentaDetalleDto>> ActualizarItem(int id, VentaDetalleDto param)
        {
            var response = new BaseResponse<VentaDetalleDto>();
            try
            {
                VentaDetalle entity = new();
                entity.Id = id;
                entity.VentaId = param.VentaId;
                entity.NumeroItem = param.NumeroItem;
                entity.ProductoId = param.ProductoId;
                entity.PrecioUnitario = param.PrecioUnitario;
                entity.Cantidad = param.Cantidad;
                entity.Total = param.Total;

                await _repository.UpdateItem(entity);

                response.Result = new VentaDetalleDto
                {
                    Id = entity.Id,
                    VentaId = entity.VentaId,
                    NumeroItem = entity.NumeroItem,
                    ProductoId = entity.ProductoId,
                    PrecioUnitario = entity.PrecioUnitario,
                    Cantidad = entity.Cantidad,
                    Total = entity.Total,
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }


        public async Task<BaseResponse<string>> EliminarItem(int id)
        {
            var response = new BaseResponse<string>();
            try
            {
                await _repository.DeleteItem(id);

                response.Result = "OK";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}

