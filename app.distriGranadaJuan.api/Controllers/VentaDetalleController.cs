using app.distriGranadaJuan.common.DTOs;
using app.distriGranadaJuan.services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace app.distriGranadaJuan.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaDetalleController : Controller
    {
        private readonly IVentaDetalleService _ventaDetalleService;

        public VentaDetalleController(IVentaDetalleService ventaDetalleService)
        {
            _ventaDetalleService = ventaDetalleService;
        }

        // Crear un detalle de venta
        [HttpPost]
        public async Task<IActionResult> PostVentaDetalle([FromBody] VentaDetalleDto request)
        {
            var response = await _ventaDetalleService.CrearItem(request);
            return Ok(response);
        }

        // Obtener un detalle de venta por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVentaDetalle(int id)
        {
            var response = await _ventaDetalleService.GetItem(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        // Obtener todos los detalles de venta
        [HttpGet]
        public async Task<IActionResult> GetVentaDetalles()
        {
            var result = await _ventaDetalleService.GetItemsList();
            return result.Success ? Ok(result) : NotFound(result);
        }

        // Actualizar un detalle de venta por id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaDetalle(int id, [FromBody] VentaDetalleDto param)
        {
            var result = await _ventaDetalleService.ActualizarItem(id, param);
            return Ok(result);
        }

        // Eliminar un detalle de venta por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaDetalle(int id)
        {
            var result = await _ventaDetalleService.EliminarItem(id);
            return Ok(result);
        }
    }

}