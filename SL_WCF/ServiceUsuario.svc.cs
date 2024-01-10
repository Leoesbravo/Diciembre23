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
        public Dictionary<string,object> Add(ML.Usuario usuario)
        {
            Dictionary<string, object> diccionario = BL.Usuario.AddEF(usuario);
            return diccionario;
        }

        public Dictionary<string, object> GetAll(Usuario usuario)
        {
            Dictionary<string, object> diccionario = BL.Usuario.GetAllEF(usuario);
            return diccionario;
        }
    }
}
