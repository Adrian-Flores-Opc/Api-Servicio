using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Comunes
{
    public static class GerenteCodigo
    {
        public static int GetCodigo(string typeIN)
        {
            int resultado = 0;
            if (typeIN.Equals("OK"))
                resultado = 200;
            else if (typeIN.Equals("CREATED"))
                resultado = 201;
            else if (typeIN.Equals("NO_CONTENT"))
                resultado = 203;
            else if (typeIN.Equals("NO_MODIFIED"))
                resultado = 304;
            else if (typeIN.Equals("UNAUTHORIZED"))
                resultado = 401;
            else if (typeIN.Equals("UNPROCESABLE_ENTITY"))
                resultado = 422;
            else if (typeIN.Equals("ERROR_FATAL"))
                resultado = 500;
            else if (typeIN.Equals("SERVICE_UNAVARIABLE"))
                resultado = 503;
            else
                resultado = 500;
            return resultado;
        }
    }
}
