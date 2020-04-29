using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Comunes
{
    public static class GerenteMensaje
    {
        public static string GetMensaje(string typeIN)
        {
            string resultado = String.Empty;
            if (typeIN.Equals("OK"))
                resultado = "La solicitud se ejecuto correctamente.";
            else if (typeIN.Equals("CREATED"))
                resultado = "El registro se creo correctamente.";
            else if (typeIN.Equals("NO_CONTENT"))
                resultado = "La solicitud se ejecuto correctamente pero no se afecto ningun registro";
            else if (typeIN.Equals("NO_MODIFIED"))
                resultado = "No se pudo actualizar el regsitro solicitado";
            else if (typeIN.Equals("UNAUTHORIZED"))
                resultado = "Canal no autorizado";
            else if (typeIN.Equals("UNPROCESABLE_ENTITY"))
                resultado = "La información enviada no puede ser procesada";
            else if (typeIN.Equals("ERROR_FATAL"))
                resultado = "Ocurrio un error comuniquese con el administrador del sistema";
            else if (typeIN.Equals("SERVICE_UNAVARIABLE"))
                resultado = "El servicio se encuentra temporalmente fuera de servicio";
            else
                resultado = "Ocurrio un error comuniquese con el administrador del sistema";
            return resultado;
        }
    }
}
