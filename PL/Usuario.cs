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

            bool resultado = BL.Usuario.AddLINQ(usuario);
            if (resultado == true)
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
        //toda la informacion
        public static void GetAll()
        {
            ML.Usuario usuario = BL.Usuario.GetAllEF();
            foreach (ML.Usuario user in usuario.Usuarios)
            {
                Console.WriteLine("Nombre:" + user.Nombre);
                Console.WriteLine("Nombre:" + user.IdUsuario);
                Console.WriteLine("Nombre:" + user.ApellidoPaterno);
                Console.WriteLine("Nombre:" + user.Edad);
                //se va a crear la instancia de la prop de navegacion solamente
                //la primera vez que la vayan a utilizar
                Console.WriteLine("Nombre:" + user.Rol.IdRol);
                Console.WriteLine("-------------------------------");
            }
            Console.ReadKey();
            //llamar al BL(metodo para recuperar la informacion)
        }
        public static void GetById()
        {
            Console.WriteLine("Ingrese el id del usuario que quiere consultar");
            int idUsuario = int.Parse(Console.ReadLine());

            ML.Usuario user = BL.Usuario.GetByIdEF(idUsuario);

            Console.WriteLine("Nombre:" + user.Nombre);
            Console.WriteLine("Nombre:" + user.IdUsuario);
            Console.WriteLine("Nombre:" + user.ApellidoPaterno);
            Console.WriteLine("Nombre:" + user.Edad);
            Console.WriteLine("-------------------------------");

            Console.ReadKey();
            //llamar al BL(metodo para recuperar la informacion)
        }

    }
}
