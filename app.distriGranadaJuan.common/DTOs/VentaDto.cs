using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.common.DTOs
{
    public class VentaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo ClienteId es obligatorio")]
        public int ClienteId { get; set; }

        public ClienteDto? Cliente { get; set; }

        [Required(ErrorMessage = "La fecha de venta es obligatoria")]
        public DateTime FechaVenta { get; set; }

        [StringLength(20, ErrorMessage = "El número de factura no puede exceder 20 caracteres")]
        public string? NumeroFactura { get; set; }

        [StringLength(20, ErrorMessage = "El método de pago no puede exceder 20 caracteres")]
        public string? MetodoPago { get; set; }

        [Required(ErrorMessage = "El total de la venta es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El total de la venta debe ser un valor positivo")]
        public decimal TotalVenta { get; set; }

    }
}
