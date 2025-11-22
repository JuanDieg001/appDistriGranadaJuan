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
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _repository;


        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<UsuarioDto>> GetItem(int id)
        {
            var response = new BaseResponse<UsuarioDto>();
            try
            {
                var entity = await _repository.GetItem(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new UsuarioDto
                {
                    Id = entity.Id,
                    Correo = entity.Correo,
                    Clave = entity.Clave
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

        public async Task<BaseResponse<UsuarioDto>> CrearItem(UsuarioDto param)
        {

            var respuesta = new BaseResponse<UsuarioDto>();
            try
            {
                Usuario entity = new();

                entity.Correo = param.Correo;
                entity.Clave = param.Clave;

                entity = await _repository.CreateItem(entity);

                respuesta.Result = new UsuarioDto
                {
                    Id = entity.Id,
                    Correo = entity.Correo,
                    Clave = entity.Clave
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

        public async Task<BaseResponse<List<UsuarioDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<UsuarioDto>>();
            try
            {
                var result = await _repository.GetItemLista();

                response.Result = result.Select(entity => new UsuarioDto
                {
                    Id = entity.Id,
                    Correo = entity.Correo,
                    Clave = entity.Clave
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

        public async Task<BaseResponse<UsuarioDto>> ActualizarItem(int id, UsuarioDto param)
        {
            var response = new BaseResponse<UsuarioDto>();
            try
            {
                Usuario entity = new();
                entity.Id = id;
                entity.Correo = param.Correo;
                entity.Clave = param.Clave;

                await _repository.UpdateItem(entity);

                response.Result = new UsuarioDto
                {
                    Id = entity.Id,
                    Correo = entity.Correo,
                    Clave = entity.Clave
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