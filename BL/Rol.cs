using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static Dictionary<string,object> GetAll()
        {
            ML.Rol rol = new ML.Rol();
            Dictionary<string,object> diccionario = new Dictionary<string, object> { { "Rol", rol},{ "Exepcion",null}, { "Resultado", false} };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.RolGetAll().ToList();

                    if(objeto != null)
                    {
                        rol.Roles = new List<ML.Rol>();
                        foreach(var objRol in objeto)
                        {
                            ML.Rol rolobj = new ML.Rol();
                            rolobj.IdRol = objRol.IdRol;
                            rolobj.Tipo = objRol.Tipo;

                            rol.Roles.Add(rolobj);
                        }
                        diccionario["Resultado"] = true;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
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
    }
}
