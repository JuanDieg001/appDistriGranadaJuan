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
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _repository;


        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }


        public async Task<BaseResponse<ClienteDto>> GetItem(int id)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                var entity = await _repository.GetItem(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Registro no encontrado";
                    return response;
                }

                response.Result = new ClienteDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    Email = entity.Email,
                    FechaNacimiento = entity.FechaNacimiento,
                    CedulaIdentidad = entity.CedulaIdentidad
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

        public async Task<BaseResponse<ClienteDto>> CrearItem(ClienteDto param)
        {

            var respuesta = new BaseResponse<ClienteDto>();
            try
            {
                Cliente entity = new();


                entity.Id = param.Id;
                entity.Nombre = param.Nombre;
                entity.Apellido = param.Apellido;
                entity.Email = param.Email;
                entity.FechaNacimiento = param.FechaNacimiento;
                entity.CedulaIdentidad = param.CedulaIdentidad;

                entity = await _repository.CreateItem(entity);

                respuesta.Result = new ClienteDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    Email = entity.Email,
                    FechaNacimiento = entity.FechaNacimiento,
                    CedulaIdentidad = entity.CedulaIdentidad
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

        public async Task<BaseResponse<List<ClienteDto>>> GetItemsList()
        {
            var response = new BaseResponse<List<ClienteDto>>();
            try
            {
                var result = await _repository.GetItemLista();

                response.Result = result.Select(entity => new ClienteDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    Email = entity.Email,
                    FechaNacimiento = entity.FechaNacimiento,
                    CedulaIdentidad = entity.CedulaIdentidad
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

        public async Task<BaseResponse<ClienteDto>> ActualizarItem(int id, ClienteDto param)
        {
            var response = new BaseResponse<ClienteDto>();
            try
            {
                Cliente entity = new();
                entity.Id = id;
                entity.Nombre = param.Nombre;
                entity.Apellido = param.Apellido;
                entity.Email = param.Email;
                entity.FechaNacimiento = param.FechaNacimiento;
                entity.CedulaIdentidad = param.CedulaIdentidad;

                await _repository.UpdateItem(entity);

                response.Result = new ClienteDto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Apellido = entity.Apellido,
                    Email = entity.Email,
                    FechaNacimiento = entity.FechaNacimiento,
                    CedulaIdentidad = entity.CedulaIdentidad
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