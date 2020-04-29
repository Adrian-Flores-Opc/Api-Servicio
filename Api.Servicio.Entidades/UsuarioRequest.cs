using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Entidades
{
    public class UsuarioRequest : GenericRequest
    {
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string celular { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string correo_Electronico { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string password { get; set; }
    }

   
}
