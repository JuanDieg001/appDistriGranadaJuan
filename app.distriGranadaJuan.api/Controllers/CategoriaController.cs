using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.services.Implementations;
using app.distriGranadaJuan.services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace app.distriGranadaJuan.api.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("hola")]
        public IActionResult GetHelloWorld()
        {
            return Ok("Hola Mundo -- categoria");
        }

        // Crear una categoría
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] CategoriaDto request)
        {
            var response = await _categoriaService.CrearItem(request);
            return Ok(response);
        }

        // Obtener categoría por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            var response = await _categoriaService.GetItem(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // Obtener todas las categorías
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var result = await _categoriaService.GetItemsList();
            return result.Success ? Ok(result) : NotFound(result);
        }

        // Actualizar categoría por id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, [FromBody] CategoriaDto param)
        {
            var result = await _categoriaService.ActualizarItem(id, param);
            return Ok(result);
        }

        // Eliminar categoría por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var result = await _categoriaService.EliminarItem(id);
            return Ok(result);
        }
    }
}