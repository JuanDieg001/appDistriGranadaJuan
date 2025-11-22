using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.services.Implementations;
using app.distriGranadaJuan.services.Interfaces;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace app.distriGranadaJuan.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // Crear un cliente
        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody] ClienteDto request)
        {
            var response = await _clienteService.CrearItem(request);
            return Ok(response);
        }

        // Obtener un cliente por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var response = await _clienteService.GetItem(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // Obtener todos los clientes
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var result = await _clienteService.GetItemsList();
            return result.Success ? Ok(result) : NotFound(result);
        }

        // Actualizar un cliente por id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteDto param)
        {
            var result = await _clienteService.ActualizarItem(id, param);
            return Ok(result);
        }

        // Eliminar un cliente por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var result = await _clienteService.EliminarItem(id);
            return Ok(result);
        }
    }

}