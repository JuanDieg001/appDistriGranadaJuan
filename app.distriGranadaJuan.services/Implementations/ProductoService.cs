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
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _repository;


        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<ProductoDto>> GetItem(int id)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                var entity = await _repository.GetItem(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ProductoDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Descripcion = entity.Descripcion,
                    CategoriaId = entity.CategoriaId,
                    PrecioUnitario = entity.PrecioUnitario,
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

        public async Task<BaseResponse<ProductoDto>> CrearItem(ProductoDto param)
        {

            var respuesta = new BaseResponse<ProductoDto>();
            try
            {
                Producto entity = new();

                entity.Nombre = param.Nombre;
                entity.Descripcion = param.Descripcion;
                entity.CategoriaId = param.CategoriaId;
                entity.PrecioUnitario = param.PrecioUnitario;

                entity = await _repository.CreateItem(entity);

                respuesta.Result = new ProductoDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Descripcion = entity.Descripcion,
                    CategoriaId = entity.CategoriaId,
                    PrecioUnitario = entity.PrecioUnitario
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

        public async Task<BaseResponse<List<ProductoDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<ProductoDto>>();
            try
            {
                var result = await _repository.GetItemLista();

                response.Result = result.Select(entity => new ProductoDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Descripcion = entity.Descripcion,
                    CategoriaId = entity.CategoriaId,
                    PrecioUnitario = entity.PrecioUnitario
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

        public async Task<BaseResponse<ProductoDto>> ActualizarItem(int id, ProductoDto param)
        {
            var response = new BaseResponse<ProductoDto>();
            try
            {
                Producto entity = new();
                entity.Id = id;
                entity.Nombre = param.Nombre;
                entity.Descripcion = param.Descripcion;
                entity.CategoriaId = param.CategoriaId;
                entity.PrecioUnitario = param.PrecioUnitario;
                entity.Fecha = DateTime.Now;
                entity.Estado = true;


                await _repository.UpdateItem(entity);

                response.Result = new ProductoDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Descripcion = entity.Descripcion,
                    CategoriaId = entity.CategoriaId,
                    PrecioUnitario = entity.PrecioUnitario
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