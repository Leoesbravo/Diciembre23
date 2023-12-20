using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    //Action verb
    //Action method -- un metodo en un controlador
    public class UsuarioController : Controller
    {
        public ActionResult GetAll()
        {
            Dictionary<string, object> result = BL.Usuario.GetAllLINQ();
            //unboxing
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {
                ML.Usuario usuario = (ML.Usuario)result["Usuario"];
                return View(usuario);
            }
            else
            {
                //pendiente la alerta
                string exepcion = (string)result["Exepcion"];
                return View();
            }

        }
    }
}