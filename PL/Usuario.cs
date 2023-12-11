using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        //metodo para pedir informacion
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingresa el nombre del usuario");
            //string nombre = Console.ReadLine();
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingresa el apellido paterno del usuario");
            //string apellidoPaterno = Console.ReadLine();
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingresa el apellido materno del usuario");
            //string apellidoMaterno = Console.ReadLine();
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingresa la edad del usuario");
            //int edad = int.Parse(Console.ReadLine());
            usuario.Edad = int.Parse(Console.ReadLine());

            bool resultado = BL.Usuario.Add(usuario);
            if(resultado == true)
            {
                Console.WriteLine("Se inserto tu registro!");
            }
            else
            {
                Console.WriteLine("NO se inserto el registro");
            }
            Console.ReadKey();

            // Agregar(nombre, apellidoPaterno, apellidoMaterno)
        }

    }
}
