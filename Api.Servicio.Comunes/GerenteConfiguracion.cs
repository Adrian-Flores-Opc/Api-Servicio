using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Comunes
{
    public static class GerenteConfiguracion
    {
        public static string GetConfiguracionString(string strClaveNameIn)
        {
            string resultado = String.Empty;
            try
            {
                resultado = ConfigurationManager.AppSettings.Get(strClaveNameIn);
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public static int GetConfiguracionInt(string strClaveNameIn)
        {
            int resultado = 0;
            try
            {
                resultado = Convert.ToInt32(ConfigurationManager.AppSettings.Get(strClaveNameIn).ToString());
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
    }
}
