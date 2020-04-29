using Api.Servicio.Comunes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Entidades
{
    public class GenericResponse :IDisposable
    {
        public string mensaje { get; set; }
        public int codigo { get; set; }
        public bool exito { get; set; }

        public GenericResponse()
        {
            this.mensaje = GerenteMensaje.GetMensaje("ERROR_FATAL");
            this.codigo = GerenteCodigo.GetCodigo("ERROR_FATAL");
            this.exito = false;
        }
        void IDisposable.Dispose() { }
    }
}
