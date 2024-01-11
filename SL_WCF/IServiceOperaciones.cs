using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IServiceOperaciones
    {
        //Interfaz -- Define el comportamiento de las clases que hereden de ella
        //Plantilla metodos sin implementación
        //Herencia -- Obliga a implementar los metodos declarados
        [OperationContract] //Endpoint
        void DoWork();  //Firma de metodos

        [OperationContract]
        string Saludar(string nombre);

        //Como mandar a llamar los metodos de BL Producto/Transporte

    }
}
