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
        public IHttpActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario("","","");
            Dictionary<string, object> resultado = BL.Usuario.GetAllEF(usuario);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {              
                usuario = (ML.Usuario)resultado["Usuario"];
                return Ok(usuario); 
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
