using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        //metodo para insertar la informacion
        public static bool Add(ML.Usuario usuario)
        {
            bool result = false;
            try
            {
                //abrir conexion
                using (SqlConnection context = new SqlConnection(DL.Conexion.ObtenerConnectionString()))
                {
                    //query, sentencia a ejecutar
                    var sentencia = "INSERT INTO Usuario(Nombre, ApellidoPaterno, ApellidoMaterno, Edad) VALUES (@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Edad)";

                    //llenar de valor los parametros
                    SqlParameter[] parametros = new SqlParameter[4];

                    parametros[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    parametros[0].Value = usuario.Nombre;
                    parametros[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    parametros[1].Value = usuario.ApellidoPaterno;
                    parametros[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    parametros[2].Value = usuario.ApellidoMaterno;
                    parametros[3] = new SqlParameter("@Edad", SqlDbType.Int);
                    parametros[3].Value = usuario.Edad;

                    //objeto que ejecutara la sentencia
                    SqlCommand commnad = new SqlCommand(sentencia, context);
                    commnad.Parameters.AddRange(parametros);
                    //inicar conexion
                    commnad.Connection.Open();
                    int filasAfectadas = commnad.ExecuteNonQuery();

                    //validando si hubo filas afectadas
                    if (filasAfectadas > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }

            }
            catch (Exception ex)//fallo algo
            {
                result = false;
            }
            return result;
        }
        public static ML.Usuario GetAll()
        {
            ML.Usuario user = new ML.Usuario();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.ObtenerConnectionString()))
                {
                    string query = "SELECT IdUsuario,Nombre,ApellidoPaterno,Edad FROM Usuario";

                    //crear la tabla
                    DataTable tablaUsuario = new DataTable();
                    SqlCommand command = new SqlCommand(query, context);
                    //leer la informacion
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(tablaUsuario);
                    //pasar la informacion de un data table a un mi modelo(ML.Usuario)

                    if (tablaUsuario.Rows.Count > 0)
                    {
                        user.Usuarios = new List<object>();
                        foreach (DataRow registro in tablaUsuario.Rows)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(registro[0].ToString());
                            usuario.Nombre = registro[1].ToString();
                            usuario.ApellidoPaterno = registro[2].ToString();
                            usuario.Edad = int.Parse(registro[3].ToString());

                            user.Usuarios.Add(usuario);
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return user;
        }
        public static ML.Usuario GetById(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.ObtenerConnectionString()))
                {
                    string sentencia = "UsuarioGetById";

                    SqlCommand command = new SqlCommand(sentencia, context);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parametro = new SqlParameter[1];
                    parametro[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                    parametro[0].Value = idUsuario;

                    command.Parameters.AddRange(parametro);

                    DataTable tablaUsuario = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(tablaUsuario);

                    if (tablaUsuario.Rows.Count == 1)
                    {
                        var registro = tablaUsuario.Rows[0];

                        usuario = new ML.Usuario();
                        usuario.IdUsuario = int.Parse(registro[0].ToString());
                        usuario.Nombre = registro[1].ToString();
                        usuario.ApellidoPaterno = registro[2].ToString();
                        usuario.ApellidoMaterno = registro[3].ToString();
                        usuario.Edad = int.Parse(registro[4].ToString());
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return usuario;
        }
        public static Dictionary<string,object> GetByIdEF(int idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", usuario }, { "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.UsuarioGetById(idUsuario).SingleOrDefault();
                        //SingleOrDefault -- devuelve el unico valor 
                        //FirstOrDefault -- devuelve el primero devuleve un valor por defecto

                    if(objeto != null)
                    {
                        usuario.IdUsuario = objeto.IdUsuario;
                        usuario.Nombre = objeto.Nombre;
                        usuario.ApellidoMaterno = objeto.ApellidoMaterno;
                        usuario.ApellidoPaterno = objeto.ApellidoPaterno;
                        usuario.Edad = objeto.Edad;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Calle = objeto.Calle;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objeto.IdColonia;
                        usuario.Direccion.Colonia.Nombre = objeto.ColoniaNombre;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objeto.IdMunicipio;
                        usuario.Direccion.Colonia.Municipio.Nombre = objeto.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objeto.IdEstado;


                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objeto.IdPais;


                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {

                    }
                        //ToList()
                }
            }
            catch (Exception ex)
            {

            }
            return diccionario;
        }
        public static Dictionary<string, object> GetByEmail(string email)
        {
 
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", null }, { "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.UsuarioGetByEmail(email).SingleOrDefault();
                    //SingleOrDefault -- devuelve el unico valor 
                    //FirstOrDefault -- devuelve el primero devuleve un valor por defecto

                    if (objeto != null)
                    {
                        ML.Usuario usuario = new ML.Usuario(objeto.Email, objeto.Password);

                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                    //ToList()
                }
            }
            catch (Exception ex)
            {

            }
            return diccionario;
        }
        public static Dictionary<string, object> GetAllEF(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", usuario }, { "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var registros = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno).ToList();
                    if (registros != null)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (var registro in registros)
                        {
                            //instancia -Crear un objeto
                            ML.Usuario user = new ML.Usuario();

                            user.IdUsuario = registro.IdUsuario;
                            user.Nombre = registro.Nombre;
                            user.ApellidoMaterno = registro.ApellidoMaterno;
                            user.ApellidoPaterno = registro.ApellidoPaterno;
                            user.Edad = registro.Edad;
                            //siempre que quieran usar una propiedad de navegacion hay que 
                            //instanciarla
                            user.Rol = new ML.Rol();
                            user.Rol.IdRol = registro.IdRol.Value;

                            usuario.Usuarios.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {
                        //
                    }
                }
                
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }

        //LINQ--.NET(C#, Visual Basic)
        //lenguaje interno que permite realizar consultas directamente desde
        //nuestro codigo
        //puede ser a una base de datos
        //o pueder a cualquier estructura de datos(listas, arreglos, diccionario)
        //sintaxis es similar a la de SQL, metodos

        public static Dictionary<string,object> GetAllLINQ()
        {
            ML.Usuario usuario = new ML.Usuario();
           string exepcion = "";
           Dictionary<string, object> diccionario = new Dictionary<string, object>{ {"Usuario",usuario  },{"Exepcion",exepcion  }, { "Resultado", false} };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    //metodo tolist
                    //var objetos = context.Usuarios.ToList();
                    var query = (from Usuario in context.Usuarios
                                 join Rol in context.Rols on Usuario.IdRol equals Rol.IdRol
                                 select new
                                 {
                                     IdUsuario = Usuario.IdUsuario,
                                     Nombre = Usuario.Nombre,
                                     ApellidoPaterno = Usuario.ApellidoPaterno,
                                     ApellidoMaterno = Usuario.ApellidoMaterno,
                                     Edad = Usuario.Edad,
                                     IdRol = Rol.IdRol,
                                     NombreRol = Rol.Tipo,
                                     Imagen = Usuario.IMAGEN
                                 }).ToList();
                    if (query != null)
                    {
                        usuario.Usuarios = new List<object>();
                        foreach (var registro in query)
                        {
                            //instancia -Crear un objeto
                            ML.Usuario user = new ML.Usuario();

                            user.IdUsuario = registro.IdUsuario;
                            user.Nombre = registro.Nombre;
                            user.ApellidoMaterno = registro.ApellidoMaterno;
                            user.ApellidoPaterno = registro.ApellidoPaterno;
                            user.Edad = registro.Edad;
                            user.Imagen = registro.Imagen;
                            //siempre que quieran usar una propiedad de navegacion hay que 
                            //instanciarla
                            user.Rol = new ML.Rol();
                            user.Rol.IdRol = registro.IdRol;
                            user.Rol.Tipo = registro.NombreRol;

                            usuario.Usuarios.Add(user);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string,object> AddLINQ(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> {{ "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    DL_EF.Usuario usuarioEntity = new DL_EF.Usuario();

                    usuarioEntity.Nombre = usuario.Nombre;
                    usuarioEntity.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioEntity.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioEntity.Edad = usuario.Edad;
                    usuarioEntity.IMAGEN = usuario.Imagen;
                    usuarioEntity.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioEntity);
                    int filasAfectadas = context.SaveChanges();
                    if(filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        
                    }

                }

            
            }
            catch (Exception ex)
            {

            }
            return diccionario;
        }
        public static Dictionary<string, object> AddEF(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", exepcion }, { "Resultado", false } };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var registros = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Edad, usuario.Direccion.Calle, usuario.Direccion.Colonia.IdColonia, usuario.Imagen);
                    if (registros > 0)
                    {
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        
                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
        public static Dictionary<string, object> LeerExcel(string connectionString)
        {
            ML.Usuario usuario = new ML.Usuario();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, {"Objects", null} };
            try
            {
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [Hoja$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;

                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableUsuario = new DataTable();

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            usuario.Usuarios = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario user = new ML.Usuario();
                                user.Nombre = row[0].ToString();
                                user.ApellidoPaterno = row[1].ToString();
                                user.ApellidoMaterno = row[2].ToString();
                                user.Edad = int.Parse(row[3].ToString());
                                user.Rol = new ML.Rol();
                                user.Rol.IdRol = int.Parse(row[4].ToString());

                                usuario.Usuarios.Add(user);
                            }
                            diccionario["Resultado"] = true;
                            diccionario["Objects"] = usuario.Usuarios;
                        }                       
                        else
                        {
                            diccionario["Resultado"] = false;
                            diccionario["Exepcion"] = "No existen registros en el excel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;

            }

            return diccionario;
        }
        //Falta explicar
        public static Dictionary<string, object> ValidarExcel(List<ML.Usuario> usuarios)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Objects", null} };
            ML.ResultExcel resultExcel = new ML.ResultExcel();
            try
            {
                resultExcel.Objects = new List<object>(); //almacena los registros incompletos
                int i = 1; //guarda el numero de la fila
                foreach (ML.Usuario usuario in usuarios)
                {
                    ML.ResultExcel error = new ML.ResultExcel();
                    error.IdRegistro = i++;

                    if (usuario.Nombre == "")
                    {
                        error.Mensaje += "Ingresar el nombre  ";
                    }
                    if (usuario.ApellidoMaterno == "") //Opcional
                    {
                        error.Mensaje += "Ingresar el Apellido materno  ";
                    }
                    if (usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingresar el Apellido paterno  ";
                    }
                    //Agregar todo los if necesarios

                    if (error.Mensaje != null) //si tuvo algun error
                    {
                        resultExcel.Objects.Add(error); // agregar a la lista de errores
                    }


                }
                diccionario["Objects"] = resultExcel.Objects;
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"]= ex.Message;

            }

            return diccionario;
        }
    }
}
