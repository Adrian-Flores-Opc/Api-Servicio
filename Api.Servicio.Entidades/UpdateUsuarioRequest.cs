using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Entidades
{
    public class UpdateUsuarioRequest : GenericRequest
    {
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string nameUser { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string passUser { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string celular { get; set; }
        [Required(ErrorMessage = "campo {0} nulo o esta vacio")]
        public string correoElectronico { get; set; }
    }
}
