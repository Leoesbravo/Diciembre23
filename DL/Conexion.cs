using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        //metodo para obtener la cadena de conexion
        public static string ObtenerConnectionString()
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["LEscogidoProgramacionNCapas"].ToString();
            return cadenaConexion;
        }
    }
}
