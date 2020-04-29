using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Entidades
{
    public class UpdateDataUsuario
    {
        [Required(ErrorMessage = "{0} campo nulo o esta vacio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "{0} campo nulo o esta vacio")]
        public string passUsuario { get; set; }
        [Required(ErrorMessage = "{0} campo nulo o esta vacio")]
        public string correo { get; set; }
        [Required(ErrorMessage = "{0} campo nulo o esta vacio")]
        public string celular { get; set; }

    }
}
