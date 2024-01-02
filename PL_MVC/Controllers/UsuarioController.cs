using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    //Action verb -- especificar el tipo de operacion que queremos realizar
    //GET, POST, PUT, DELETE, PATCH (HTTP)
    //Action method -- un metodo en un controlador

    //GET para mostrar un recurso(vista, informacion)
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll(ML.Usuario usuario)
        {


            Dictionary<string, object> result = BL.Usuario.GetAllEF(usuario);
            //unboxing
            bool resultado = (bool)result["Resultado"];

            if (resultado == true)
            {
                usuario = (ML.Usuario)result["Usuario"];
                return View(usuario);
            }
            else
            {
                //pendiente la alerta
                string exepcion = (string)result["Exepcion"];
                return View();
            }

        }

        //mostrar el formulario
        //tipos de datos nullables
        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            if (IdUsuario != null)
            {
                Dictionary<string, object> result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                bool resultado = (bool)result["Resultado"];

                if (resultado == true)
                {
                    usuario = (ML.Usuario)result["Usuario"];
                    Dictionary<string, object> resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    ML.Estado estado = (ML.Estado)resultEstado["Estado"];
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = estado.Estados;

                    Dictionary<string, object> resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    ML.Municipio municipio = (ML.Municipio)resultMunicipio["Municipio"];
                    usuario.Direccion.Colonia.Municipio.Municipios = municipio.Municipios;

                    Dictionary<string, object> resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    ML.Colonia colonia = (ML.Colonia)resultColonia["Colonia"];
                    usuario.Direccion.Colonia.Colonias = colonia.Colonias;
                }
                else
                {
                    string exepcion = (string)result["Exepcion"];
                    ViewBag.Mensaje = "Ocurrio un error al recuperar la informacion" + exepcion;
                    return PartialView("Modal");
                }
            }
            else
            {
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            }
            Dictionary<string, object> resultRol = BL.Rol.GetAll();
            Dictionary<string, object> resultPais = BL.Pais.GetAll();

            bool rolCorrect = (bool)resultRol["Resultado"];
            if (rolCorrect == true)
            {
                ML.Rol rol = (ML.Rol)resultRol["Rol"];
                usuario.Rol = new ML.Rol();
                usuario.Rol.Roles = rol.Roles;

                ML.Pais pais = (ML.Pais)resultPais["Pais"];
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = pais.Paises;

                return View(usuario);
            }
            else
            {
                string exepcion = (string)resultRol["Exepcion"];
                ViewBag.Mensaje = "Ocurrio un error al recuperar la informacion" + exepcion;
                return PartialView("Modal");
            }

        }
        //insertar la informacion
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if(ModelState.IsValid )
            {
                HttpPostedFileBase file = Request.Files["amd"];
                if (file != null)
                {
                    usuario.Imagen = ConvertToBytes(file);
                }

                if (usuario.IdUsuario > 0)
                {
                    //llamar al update
                    ViewBag.Mensaje = "Se ha actualizado el registro";
                    return PartialView("Modal");
                }
                else
                {
                    Dictionary<string, object> result = BL.Usuario.AddEF(usuario);
                    bool resultado = (bool)result["Resultado"];

                    if (resultado == true)
                    {
                        ViewBag.Mensaje = "El Usuario ha sido insertado";
                        return PartialView("Modal");
                    }
                    else
                    {
                        //pendiente la alerta               
                        string exepcion = (string)result["Exepcion"];
                        ViewBag.Mensaje = "El Usuario no se pudo registrar " + exepcion;
                        return PartialView("Modal");
                    }
                }
            }
            else
            {
                Dictionary<string, object> resultRol = BL.Rol.GetAll();
                Dictionary<string, object> resultPais = BL.Pais.GetAll();
                ML.Rol rol = (ML.Rol)resultRol["Rol"];
                usuario.Rol.Roles = rol.Roles;

                ML.Pais pais = (ML.Pais)resultPais["Pais"];
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = pais.Paises;
                return View(usuario);
            }


        }
        [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {
            return View();
        }
        public ActionResult Ajax()
        {
            return View();
        }
        public JsonResult EstadoGetByIdPais(int idPais)
        {
            Dictionary<string, object> resultado = BL.Estado.GetByIdPais(idPais);
            ML.Estado estado = (ML.Estado)resultado["Estado"];
            return Json(estado.Estados, JsonRequestBehavior.AllowGet);
        }
        public byte[] ConvertToBytes(HttpPostedFileBase Foto)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            data = reader.ReadBytes((int)Foto.ContentLength);

            return data;
        }
    }
}
//modal
//ViewBag -- es una forma para enviar datos de un controlador a la vista