using Api.Servicio.Entidades;
using Api.Servicio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Servicio.Android.Controllers
{
    public class ActualizarDatosController : Controller
    {
        private NegocioObtenerDatos _conectorNegocio;


        [ActionName("RecibirDataAndroid")]
        [HttpPost]
        public string ResivirData(UsuarioRequest request)
        {
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
            return respose;
        }


        [ActionName("ActualizarDatosUsuario")]
        [HttpPost]
        public string UpdateDataUsuario(UpdateDataUsuario request)
        {
            string _response = String.Empty;
            try
            {

            }
            catch (Exception ex)
            {
            }
            return _response;
        }
    }
}
