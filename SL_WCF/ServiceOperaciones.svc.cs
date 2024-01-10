using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceOperaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceOperaciones.svc or ServiceOperaciones.svc.cs at the Solution Explorer and start debugging.
    public class ServiceOperaciones : IServiceOperaciones
    {
        public void DoWork()
        {
            Console.WriteLine("Entre al metodo do work");
        }

        public string Saludar(string nombre)
        {
            string saludo = "Hola " + nombre;
            return saludo;
        }
    }
}
