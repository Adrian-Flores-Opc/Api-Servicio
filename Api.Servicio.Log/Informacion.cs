using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Servicio.Log
{
    public class Informacion
    {
        private static string CorreoErrores = ConfigurationSettings.AppSettings["CORREO_OPERACIONES"];
        private static string CorreoDe = ConfigurationSettings.AppSettings["CORREO_APLICATIVO"];
        private static string AsuntoErrores = ConfigurationSettings.AppSettings["CABECERA_ERROR"];
        private static string ServidorCorreo = ConfigurationSettings.AppSettings["SERVIDOR_SMTP"];
        private static string Asunto = ConfigurationSettings.AppSettings["ASUNTO"];
        private static string Cuerpo = ConfigurationSettings.AppSettings["CUERPOCORREO"];

        protected static void configuracion()
        {
            LoggingConfiguration config = new LoggingConfiguration();

            FileTarget fileTarget = new FileTarget();
            fileTarget.FileName = ConfigurationSettings.AppSettings["DirecDailyLogs"].ToString() + ".txt";
            fileTarget.Layout = ConfigurationSettings.AppSettings["LayoutNlog"].ToString();

            config.AddTarget("logfile", fileTarget);

            LoggingRule rule = new LoggingRule("*", LogLevel.Info, fileTarget);
            config.LoggingRules.Add(rule);

            LogManager.Configuration = config;
        }

        public static void LogInformacion(Logger logger, string descripcion)
        {
            try
            {
                configuracion();
                logger.Info("   Informacion:    -> " + descripcion);
            }
            catch (Exception)
            {
            }
        }
        public static void LogAdvertencia(Logger logger, string descripcion)
        {
            try
            {
                configuracion();
                logger.Info("   Advertencia:    -> " + descripcion);
            }
            catch (Exception)
            {

            }
        }
        public static void LogError(Logger logger, string descripcion, Exception error)
        {
            try
            {
                configuracion();
                logger.Info("   Error      :    " + descripcion + " -> " + error.ToString());
            }
            catch (Exception)
            {

            }
        }
    }
}
