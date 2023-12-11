using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
                    if(filasAfectadas > 0)
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
    }
}
