using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Comunes
{
    public class GerenteOperacion
    {
        public static string GenerarOperacion()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmssff");
        }
    }
}
