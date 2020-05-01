using Api.Servicio.Comunes;
using Api.Servicio.Entidades;
using Api.Servicio.Log;
using Api.Servicio.Negocio;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Api.Servicio.Android.Controllers
{
    public class ApiServicioAndroidController : Controller
    {

        private NegocioObtenerDatos _conectorNegocio;
        private string _operation;

        [HttpPost]
        [ActionName("RecibirDataAndroid")]
        public string ResivirData(UsuarioRequest request)
        {
            GenericResponse _resonse = new GenericResponse();
            _operation = GerenteOperacion.GenerarOperacion();
            _conectorNegocio = new NegocioObtenerDatos();
            bool estado = false;
            try
            {
                Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ] REQUEST: " + GerenteJson.SerializeObject(request));
                if (ModelState.IsValid)
                {
                    _resonse = _conectorNegocio.VerificarCanal(request.Canal, request.PassCanal, _operation, ref estado);
                    if (!estado)
                        return GerenteJson.SerializeObject(_resonse);
                    _resonse = _conectorNegocio.MandarDatosUsuario(request, _operation);
                    Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ] RESPONSE: " + GerenteJson.SerializeObject(_resonse));
                }
                else
                {
                    var errors = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    _resonse.mensaje = Convert.ToString(errors);
                    return GerenteJson.SerializeObject(_resonse);
                }
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error en Recibir los datos.",ex);
            }
            return JsonConvert.SerializeObject(_resonse);
        }

        [HttpPost]
        [ActionName("ModificarDataAndroid")]

        public string ModificarData(UpdateUsuarioRequest request)
        {
            _operation = GerenteOperacion.GenerarOperacion();
            _conectorNegocio = new NegocioObtenerDatos();
            GenericResponse _response = new GenericResponse();
            bool estado = false;
            try
            {
                Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ] REQUEST: " + GerenteJson.SerializeObject(request));
                if (ModelState.IsValid)
                {
                    _response = _conectorNegocio.VerificarCanal(request.Canal,request.PassCanal,_operation, ref estado);
                    if (!estado)
                    {
                        return GerenteJson.SerializeObject(_response);
                    }
                    _response = _conectorNegocio.ModificarDatosUsuario(request, _operation);
                    Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ] RESPONSE: " + GerenteJson.SerializeObject(_response));
                }
                else
                {
                    var errors = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                    _response.mensaje = Convert.ToString(errors);
                    return GerenteJson.SerializeObject(_response);
                }
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error en Modificar los datos.", ex);
            }
            return JsonConvert.SerializeObject(_response);
        }

        [HttpPost]
        [ActionName("IniciarSecionAndroid")]
        public string IniciarSecion(InicioUsuario request)
        {
            _operation = GerenteOperacion.GenerarOperacion();
            GenericResponse _response = new GenericResponse();
            bool estado = false;
            try
            {
                Informacion.LogInformacion(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ] REQUEST: " + GerenteJson.SerializeObject(request));
                if (ModelState.IsValid)
                {
                    _response = _conectorNegocio.VerificarCanal(request.Canal, request.PassCanal, _operation, ref estado);
                    if (!estado)
                        return GerenteJson.SerializeObject(_response);
                    _response = _conectorNegocio.IniciarSecion(request, _operation);
                }
                else
                {
                    var errors = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                    _response.mensaje = Convert.ToString(errors);
                    return GerenteJson.SerializeObject(_response);
                }
            }
            catch (Exception ex)
            {
                Informacion.LogError(LogManager.GetCurrentClassLogger(), " [ " + GerenteLog.GetObtenerMetodo() + " ] -- [ " + _operation + " ]. Se genero un error inesperado. ",ex);
            }
            return GerenteJson.SerializeObject(_response);
        }
    }
}
