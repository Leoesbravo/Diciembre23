using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceUsuario" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceUsuario.svc or ServiceUsuario.svc.cs at the Solution Explorer and start debugging.
    public class ServiceUsuario : IServiceUsuario
    {
        public SL_WCF.Result Add(ML.Usuario usuario)
        {
            Dictionary<string, object> diccionario = BL.Usuario.AddEF(usuario);
            SL_WCF.Result result = new SL_WCF.Result();
            result.Resultado = (bool)diccionario["Resultado"];
            result.Mensaje = diccionario["Exepcion"].ToString();
            return result;
        }

        public SL_WCF.Result GetAll(Usuario usuario)
        {
            Dictionary<string, object> diccionario = BL.Usuario.GetAllEF(usuario);
            SL_WCF.Result result = new SL_WCF.Result();
            result.Resultado = (bool)diccionario["Resultado"];
            result.Mensaje = diccionario["Exepcion"].ToString();
            //List<string> keyList = new List<string>(this.yourDictionary.Keys);
            List<object> usuarios = new List<object>(diccionario.Keys); //ISAAC
            //result.Objects = (List<object>)diccionario["Usuario"]; //GetAll
            // result.Object = (object)diccionario["Usuario"]; //GetById
            return result;
        }
    }
}
