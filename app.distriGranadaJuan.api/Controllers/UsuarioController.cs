using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.distriGranadaJuan.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Crear un usuario
        [HttpPost]
        public async Task<IActionResult> PostUsuario([FromBody] UsuarioDto request)
        {
            var response = await _usuarioService.CrearItem(request);
            return Ok(response);
        }

        // Obtener un usuario por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var response = await _usuarioService.GetItem(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // Obtener todos los usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var result = await _usuarioService.GetItemsList();
            return result.Success ? Ok(result) : NotFound(result);
        }

        // Actualizar un usuario por id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] UsuarioDto param)
        {
            var result = await _usuarioService.ActualizarItem(id, param);
            return Ok(result);
        }

        // Eliminar un usuario por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var result = await _usuarioService.EliminarItem(id);
            return Ok(result);
        }
    }

}