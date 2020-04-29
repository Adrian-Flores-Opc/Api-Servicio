using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Servicio.Comunes;
using Api.Servicio.Datos;
using Api.Servicio.Entidades;
using Api.Servicio.Log;
using Api.Servicio.Seguridad;
using NLog;

namespace Api.Servicio.Negocio
{
    public class NegocioObtenerDatos
    {
        AccesoBaseDeDatos _conectorBD;
        public NegocioObtenerDatos()
        {
            _conectorBD = new AccesoBaseDeDatos();
        }
        public GenericResponse MandarDatosUsuario(UsuarioRequest request, string _operation)
        {
            GenericResponse _response = new GenericResponse();
            try
            {
                if (_conectorBD.InsertDatosUsuario(request, _operation))
                {
                    _response.codigo = GerenteCodigo.GetCodigo("OK");
                    _response.mensaje = GerenteMensaje.GetMensaje("OK");
                    _response.exito = true;
                    Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se guardo de manera correcta al cliente con email: " + request.correo_Electronico);
                }
                else
                {
                    Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Ocurrio un error al guardar al cliente con email: " + request.correo_Electronico);
                    _response.codigo = 400 ;
                    _response.mensaje = "No se pudo registrar la informacion del usuario en base de datos";
                    _response.exito = false;
                }
            }
            catch (Exception ex)
            {
                _response.codigo = GerenteCodigo.GetCodigo("ERROR_FATAL");
                _response.mensaje = GerenteMensaje.GetMensaje("ERROR_FATAL");
                _response.exito = false;
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error inesperado. ", ex);
            }
            return _response;
        }

        public GenericResponse ModificarDatosUsuario(UpdateUsuarioRequest request, string _operation)
        {
            GenericResponse _response = new GenericResponse();
            try
            {
                if (_conectorBD.UpdateDatosUsuario(request, _operation))
                {
                    Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se Modifico al cliente con email: " + request.correoElectronico + " , de manera correcta.");
                    _response.codigo = GerenteCodigo.GetCodigo("OK");
                    _response.mensaje = GerenteMensaje.GetMensaje("OK");
                    _response.exito = true;
                }
                else
                {
                    Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Ocurrio un error al modificar al cliente con email: " + request.correoElectronico);
                    _response.codigo = GerenteCodigo.GetCodigo("ERROR_FATAL");
                    _response.mensaje = GerenteMensaje.GetMensaje("ERROR_FATAL");
                    _response.exito = false;
                }
            }
            catch (Exception ex)
            {
                _response.codigo = GerenteCodigo.GetCodigo("ERROR_FATAL");
                _response.mensaje = GerenteMensaje.GetMensaje("ERROR_FATAL");
                _response.exito = false;
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ].Se genero un error inesperado. ", ex);
            }
            return _response;
        }

        public GenericResponse VerificarCanal(string canal, string passCanal, string _operation, ref bool estado)
        {
            DataTable datos = new DataTable();
            GenericResponse _respuesta = new GenericResponse();
            try
            {
                string password = String.Empty;
                bool habilitado = false;
                datos = _conectorBD.Get_Canales(canal,_operation);
                if (datos.Rows.Count == 1)
                {
                    foreach (DataRow item in datos.Rows)
                    {
                        password = item.Field<string>("PASS_CANAL");
                        habilitado = item.Field<bool>("HABILITADO");
                    }
                    if (habilitado)
                    {
                        Encryptador.EncryptDecrypt(false, password, ref password);
                        estado = password == passCanal ? true : false;
                        if (!estado)
                        {
                            _respuesta.mensaje = "La contraseña es incorrecta";
                            _respuesta.codigo = 401;
                            _respuesta.exito = false;
                        }
                    }
                    else
                    {
                        _respuesta.mensaje = "El canal no se encuentra habilitado para usar el siguiente metodo.";
                        _respuesta.codigo = 401;
                        _respuesta.exito = false;
                    }
                }
                else if (datos.Rows.Count == 0)
                {
                    _respuesta.mensaje = "No se encuentra ningun dato sobre el canal";
                    _respuesta.codigo = 404;
                    _respuesta.exito = false;
                }
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error inesperado. ",ex);
            }
            return _respuesta;
        }
    }
}
