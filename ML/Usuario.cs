using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int idusuario, string nombre, string apellidoPaterno, string apellidoMaterno, int edad)
        {
            IdUsuario = idusuario;
            Nombre = nombre;
            ApellidoMaterno = apellidoMaterno;
            ApellidoPaterno = apellidoPaterno;
            Edad = edad;
        }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public List<Usuario> Usuarios { get; set; }

        //Propiedad de navegacion
        //Navegar entre clases
        public ML.Rol Rol { get; set; }
    }
}
