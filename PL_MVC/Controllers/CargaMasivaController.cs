using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        public ActionResult Carga()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Carga(HttpPostedFileBase txt)
        {
            StreamReader reader = new StreamReader(txt.InputStream);

            reader.ReadLine();//saltar la primera linea(encabezados)
            while ()//hasta que ya no tenga mas lineas que leer 
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario.Nombre = //?

                BL.Usuario.AddEF(usuario);
            }
            if ()
            {
                ViewBag.Mensaje = "Se han insertado los registros";
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un error";
            }
          
            return PartialView("Modal");
        }
    }
}