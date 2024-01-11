using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceUsuario" in both code and config file together.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [OperationContract]
        SL_WCF.Result Add(ML.Usuario usuario);
        [OperationContract]
        [ServiceKnownType (typeof(ML.Usuario))]
        SL_WCF.Result GetAll(ML.Usuario usuario);
    }
}
