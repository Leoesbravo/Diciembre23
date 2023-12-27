using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static Dictionary<string, object> GetByIdPais(int idPais)
        {
            ML.Estado estado = new ML.Estado();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Estado", estado }, { "Exepcion", null }, { "Resultado", false } };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.EstadoGetByIdPais(idPais).ToList();

                    if (objeto != null)
                    {
                        estado.Estados = new List<ML.Estado>();
                        foreach (var objResult in objeto)
                        {
                            ML.Estado objEstado = new ML.Estado();
                            objEstado.IdEstado = objResult.IdEstado;
                            objEstado.Nombre = objResult.Nombre;

                            estado.Estados.Add(objEstado);
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
