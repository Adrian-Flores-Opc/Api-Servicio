using Api.Servicio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Servicio.Log;
using NLog;
using Api.Servicio.Comunes;
using System.Data;

namespace Api.Servicio.Datos
{
    public class AccesoBaseDeDatos
    {
        string strConexion_wpp = AccesoBaseDatos.Conexion_Wpp();

        public bool InsertDatosUsuario(UsuarioRequest data, string _operation)
        {
            bool response = false;
            try
            {
                string nombreSp = "[api].[INSERT_DATOS_USUARIO]";
                StoreProcedure sp = new StoreProcedure(nombreSp);
                sp.AgregarParametro("@NOMBRE", data.nombre.ToUpper(),Direccion.Input);
                sp.AgregarParametro("@CORREO_ELECTRONICO", data.correo_Electronico.ToUpper(), Direccion.Input);
                sp.AgregarParametro("@CELULAR", data.celular, Direccion.Input);
                sp.AgregarParametro("@USER", data.usuario.ToUpper(), Direccion.Input);
                sp.AgregarParametro("@PASSWORD", data.password, Direccion.Input);
                sp.EjecutarStoreProcedure(strConexion_wpp);
                if (sp.Error.Trim() != String.Empty)
                {
                    response = false;
                    throw new Exception("Procedimiento Almacenado: " + nombreSp + " Descripcion: " + sp.Error.Trim());
                }
                response = true;
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(),GerenteLog.GetObtenerMetodo(),ex);
            }

            return response;
        }

        public bool UpdateDatosUsuario(UpdateUsuarioRequest request, string _operation)
        {
            bool _response = false;
            try
            {
                string nombreSp = "[api].[UPDATE_DATOS_USUARIO]";
                StoreProcedure sp = new StoreProcedure(nombreSp);
                sp.AgregarParametro("@USSER", request.nameUser,Direccion.Input);
                sp.AgregarParametro("@PASS", request.passUser,Direccion.Input);
                sp.AgregarParametro("@CORREO", request.correoElectronico,Direccion.Input);
                sp.AgregarParametro("@CELULAR", request.celular,Direccion.Input);
                sp.EjecutarStoreProcedure(strConexion_wpp);
                if (sp.Error.Trim() != String.Empty)
                {
                    _response = false;
                    throw new Exception("Procedimiento Almacenado: " + nombreSp + " Descripcion: " + sp.Error.Trim());
                }
                _response = true;
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error inesperado en Base de Datos BD_DATOS", ex);
            }
            return _response;
        }

        public DataTable Get_Canales(string canal, string _operation)
        {
            DataTable data = new DataTable();
            try
            {
                string nombre = "[api].[GET_CANALES]";
                StoreProcedure sp = new StoreProcedure(nombre);
                sp.AgregarParametro("@CANAL",canal,Direccion.Input);
                data = sp.RealizarConsulta(strConexion_wpp);
                if (sp.Error != String.Empty)
                {
                    throw new Exception("Procedimiento Almacenado: " + nombre + " Descripcion: " + sp.Error.Trim());
                }
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error inesperado en Base de Datos BD_DATOS", ex);
            }
            return data;
        }

        public DataTable Get_Usuario(InicioUsuario request, string _operation)
        {
            DataTable datos = new DataTable();
            try
            {
                StoreProcedure sp = new StoreProcedure("[api].[GET_USUARIO_INICIO]");
                sp.AgregarParametro("",request.nombreUsuario,Direccion.Input);
                sp.AgregarParametro("", request.contraseñaUsuario, Direccion.Input);
                datos = sp.RealizarConsulta(strConexion_wpp);
                if (sp.Error != String.Empty)
                {
                    throw new Exception("Procedimiento Almacenado: [api].[GET_USUARIO_INICIO] - Descripcion: " +sp.Error);
                }
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error inesperado. ",ex);
            }
            return datos;
        }
    }
}
