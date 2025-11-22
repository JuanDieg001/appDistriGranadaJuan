using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.common.DTOs
{
    public class VentaDetalleDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo VentaId es obligatorio")]
        public int VentaId { get; set; }

        public VentaDto? Venta { get; set; }

        [Required(ErrorMessage = "El número de ítem es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de ítem debe ser mayor que 0")]
        public int NumeroItem { get; set; }

        [Required(ErrorMessage = "El campo ProductoId es obligatorio")]
        public int ProductoId { get; set; }

        public ProductoDto? Producto { get; set; }

        [Required(ErrorMessage = "El precio unitario es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio unitario debe ser un valor positivo")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0")]
        public decimal Cantidad { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El total debe ser un valor positivo")]
        public decimal Total { get; set; }

    }
}
