using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.distriGranadaJuan.common.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(30, ErrorMessage = "El correo no puede tener más de 30 caracteres")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [StringLength(30, ErrorMessage = "La clave no puede tener más de 30 caracteres")]
        public string? Clave { get; set; }
    }
}
