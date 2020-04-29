using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Entidades
{
    public class GenericRequest
    {
        [Required(ErrorMessage = "{0} campo nulo o esta vacio")]
        public string Canal { get; set; }
        [Required(ErrorMessage = "{0} campo nulo o esta vacio")]
        public string PassCanal { get; set; }
    }
}
