using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string password)
        {
            Dictionary<string, object> diccionario = BL.Usuario.GetByEmail(Email);
            bool resultado = (bool)diccionario["Resultado"];
            if (resultado == true)//el metodo funciono
            {
                ML.Usuario usuario = (ML.Usuario)diccionario["Usuario"];
                if(usuario.Email != "")
                {
                    if(usuario.Password == password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "El email no existe";
                    return View();
                }
            }
            else
            {
                ViewBag.Mensaje = "El email no existe";
                return PartialView("Modal");
            }
            return View();

        }
    }
}