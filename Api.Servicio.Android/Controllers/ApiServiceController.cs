using Api.Servicio.Entidades;
using Api.Servicio.Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Servicio.Android.Controllers
{
    public class ApiServiceController : Controller
    {
        // GET: ApiService
        private NegocioObtenerDatos _conectorNegocio;

        [HttpPost]
        [ActionName("RecibirDataAndroid")]
        public string ResivirData(UsuarioRequest request)
        {
            GenericResponse _resonse = new GenericResponse();
            string _operation = String.Empty;
            string respose = String.Empty;
            _conectorNegocio = new NegocioObtenerDatos();
            try
            {
                if (ModelState.IsValid)
                {
                    _conectorNegocio.MandarDatosUsuario(request, _operation);

                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
            return JsonConvert.SerializeObject(_resonse);
        }


        [HttpPost]
        [ActionName("ModificarDatos")]

        public string UpdateDatos(UpdateUsuarioRequest request)
        {
            string _operation = String.Empty;
            string _response = String.Empty;
            _conectorNegocio = new NegocioObtenerDatos();
            try
            {
                if (ModelState.IsValid)
                {
                    _conectorNegocio.ModificarDatosUsuario(request, _operation);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return _response;
        }
    }
}