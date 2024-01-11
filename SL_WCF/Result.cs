using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SL_WCF
{
    [DataContract]
    public class Result
    {
        //DataContract -- Datos que se intercambian entre el cliente-Servidor
        //             -- Compartir datos
        //DataMember -- propiedades del dataContract 
        //    --miembro del contrato para la serializacion/desrializacion
        [DataMember]
        public bool Resultado { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
        [DataMember]
        public object Object { get; set; }
        [DataMember]
        public List<object> Objects { get; set; }
    }
}