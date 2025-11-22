using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.dataAccess.repositories;
using app.distriGranadaJuan.entities.models;
using app.distriGranadaJuan.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.services.Implementations
{
    public class VentaService : IVentaService
    {

        private readonly IVentaRepository _repository;


        public VentaService(IVentaRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<VentaDto>> GetItem(int id)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                var entity = await _repository.GetItem(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new VentaDto
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    FechaVenta = entity.FechaVenta,
                    NumeroFactura = entity.NumeroFactura,
                    MetodoPago = entity.MetodoPago,
                    TotalVenta = entity.TotalVenta,

                    // navegación deshabilitada
                    Cliente = null
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

        public async Task<BaseResponse<VentaDto>> CrearItem(VentaDto param)
        {

            var respuesta = new BaseResponse<VentaDto>();
            try
            {
                Venta entity = new();


                entity.ClienteId = param.ClienteId;
                entity.FechaVenta = param.FechaVenta;
                entity.NumeroFactura = param.NumeroFactura;
                entity.MetodoPago = param.MetodoPago;
                entity.TotalVenta = param.TotalVenta;

                entity = await _repository.CreateItem(entity);

                respuesta.Result = new VentaDto
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    FechaVenta = entity.FechaVenta,
                    NumeroFactura = entity.NumeroFactura,
                    MetodoPago = entity.MetodoPago,
                    TotalVenta = entity.TotalVenta
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

        public async Task<BaseResponse<List<VentaDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<VentaDto>>();
            try
            {
                var result = await _repository.GetItemLista();

                response.Result = result.Select(entity => new VentaDto
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    FechaVenta = entity.FechaVenta,
                    NumeroFactura = entity.NumeroFactura,
                    MetodoPago = entity.MetodoPago,
                    TotalVenta = entity.TotalVenta
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

        public async Task<BaseResponse<VentaDto>> ActualizarItem(int id, VentaDto param)
        {
            var response = new BaseResponse<VentaDto>();
            try
            {
                Venta entity = new();
                entity.Id = id;
                entity.ClienteId = param.ClienteId;
                entity.FechaVenta = param.FechaVenta;
                entity.NumeroFactura = param.NumeroFactura;
                entity.MetodoPago = param.MetodoPago;
                entity.TotalVenta = param.TotalVenta;

                await _repository.UpdateItem(entity);

                response.Result = new VentaDto
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    FechaVenta = entity.FechaVenta,
                    NumeroFactura = entity.NumeroFactura,
                    MetodoPago = entity.MetodoPago,
                    TotalVenta = entity.TotalVenta
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

