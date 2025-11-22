using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.common.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [StringLength(30)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [StringLength(30)]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El campo fechaNacimiento es obligatorio")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El campo cedulaIdentidad es obligatorio max 10 npumeros")]

        [StringLength(10, ErrorMessage = "El ancho del campo es muy largo max 10 números")]
        public string? CedulaIdentidad { get; set; }

    }
}
