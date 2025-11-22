using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.distriGranadaJuan.api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            _ventaService = ventaService;
        }

        // Crear una venta
        [HttpPost]
        public async Task<IActionResult> PostVenta([FromBody] VentaDto request)
        {
            var response = await _ventaService.CrearItem(request);
            return Ok(response);
        }

        // Obtener una venta por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id)
        {
            var response = await _ventaService.GetItem(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // Obtener todas las ventas
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var result = await _ventaService.GetItemsList();
            return result.Success ? Ok(result) : NotFound(result);
        }

        // Actualizar una venta por id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, [FromBody] VentaDto param)
        {
            var result = await _ventaService.ActualizarItem(id, param);
            return Ok(result);
        }

        // Eliminar una venta por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var result = await _ventaService.EliminarItem(id);
            return Ok(result);
        }
    }


}