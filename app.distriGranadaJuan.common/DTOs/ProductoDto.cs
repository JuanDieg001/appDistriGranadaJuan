using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.common.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El ancho del campo es muy largo")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        [StringLength(50, ErrorMessage = "El ancho del campo es muy largo")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El campo Categoría es obligatorio")]
        public int CategoriaId { get; set; }

        public CategoriaDto? Categoria { get; set; }

        [Required(ErrorMessage = "El campo Precio Unitario es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal PrecioUnitario { get; set; }
    }
}
