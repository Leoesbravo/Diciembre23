using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace SL_WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/Usuario/GetAll")]
        //PUT -- Actualizar todo -- Verificar si existe recurso -- Actualizar --- Error
        //POST -- Agregar nuevo recurso
        //PATCH -- Actualizar parcial -- Verificar si existe recurso -- Actualizar --- ADD

        //200 OK 200 
        //300 Redireccionamiento
        //400 Error en el cliente(No es sinonimo de Usuario) 
        //500 Error en el servidor 
        //100 Informativos
        public IHttpActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario("","","");
            Dictionary<string, object> resultado = BL.Usuario.GetAllEF(usuario);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {              
                usuario = (ML.Usuario)resultado["Usuario"];
                return Content(HttpStatusCode.OK, usuario);
            }
            else
            {
                return BadRequest("Error");
            }
        }
        [HttpPost]
        [Route("api/Usuario/Add")]
        public IHttpActionResult Add([FromBody]ML.Usuario usuario)
        {
            Dictionary<string, object> resultado = BL.Usuario.AddEF(usuario);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else
            {
                //devuelvan la exepcion

                return BadRequest((string)resultado["Resultado"]);
            }
        }
    }
}
