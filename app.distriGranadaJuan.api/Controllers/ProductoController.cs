using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.distriGranadaJuan.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // Crear un producto
        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] ProductoDto request)
        {
            var response = await _productoService.CrearItem(request);
            return Ok(response);
        }

        // Obtener un producto por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var response = await _productoService.GetItem(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var result = await _productoService.GetItemsList();
            return result.Success ? Ok(result) : NotFound(result);
        }

        // Actualizar un producto por id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, [FromBody] ProductoDto param)
        {
            var result = await _productoService.ActualizarItem(id, param);
            return Ok(result);
        }

        // Eliminar un producto por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var result = await _productoService.EliminarItem(id);
            return Ok(result);
        }
    }

}