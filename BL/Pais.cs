using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static Dictionary<string, object> GetAll()
        {
            ML.Pais pais = new ML.Pais();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Pais", pais }, { "Exepcion", null }, { "Resultado", false } };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.PaisGetAll().ToList();

                    if (objeto != null)
                    {
                        pais.Paises = new List<ML.Pais>();
                        foreach (var objRol in objeto)
                        {
                            ML.Pais objPais = new ML.Pais();
                            objPais.IdPais = objRol.IdPais;
                            objPais.Nombre = objRol.Nombre;

                            pais.Paises.Add(objPais);
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
