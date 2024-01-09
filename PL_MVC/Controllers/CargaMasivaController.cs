using System;
using System.Collections.Generic;
using System.Configuration;
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
        public ActionResult Carga(HttpPostedFileBase file)
        {

            if (Session["pathExcel"] == null) //*
            {
                if (file != null)
                {
                    //obtener la extension de mi archivo
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    //obtener la extension del appsetting
                    string extesionValida = ConfigurationManager.AppSettings["FormatoValido"];

                    if (extensionArchivo == extesionValida)
                    {
                        string rutaproyecto = Server.MapPath("~/CargaMasiva/");
                        string filePath = rutaproyecto + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                        if (!System.IO.File.Exists(filePath))
                        {

                            file.SaveAs(filePath);

                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                            Dictionary<string, object> resultUsuarios = BL.Usuario.LeerExcel(connectionString);
                            bool resultado = (bool)resultUsuarios["Resultado"];

                            if (resultado)
                            {
                                //Falta explicar

                                Dictionary<string, object> resultValidacion = BL.Usuario.ValidarExcel((List<ML.Usuario>)resultUsuarios["Objects"]);
                                if (((List<object>)resultValidacion["Objects"]).Count == 0) //que hubo por lo menos un regitro esta incompleto
                                {
                                    resultValidacion["Resultado"] = true;
                                    Session["pathExcel"] = filePath; //direccion del archivo
                                }

                                return View(resultValidacion);
                            }
                            else
                            {
                                string exepcion = (string)resultUsuarios["Exepcion"];
                                ViewBag.Message = exepcion;
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
                    }
                }
                else
                {
                    ViewBag.Message = "No selecciono ningun archivo, Seleccione uno correctamente";
                }
                return View();
            }
            else  // CARGA A LA BASE DE DATOS
            {
                string filepath = Session["pathExcel"].ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filepath;
                Dictionary<string, object> resultUsuarios = BL.Usuario.LeerExcel(connectionString);
                bool resultado = (bool)resultUsuarios["Resultado"];

                if (resultado)
                {
                    //foreach(ML.Usuario usuario in resultUsuarios["Objects"])//Unboxing
                    //{
                    //    BL.Usuario.Add(usuario);  //LOG de errores txt
                    //}
                    Session["pathExcel"] = null; //especifica
                    Session.Clear(); //TODAS 
                }
                return View();
            }
        }
    }
}