using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static Dictionary<string, object> GetByIdMunicipio(int idMunicipio)
        {
            ML.Colonia colonia = new ML.Colonia();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Colonia", colonia }, { "Exepcion", null }, { "Resultado", false } };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.ColoniaGetByIdMunicipio(idMunicipio).ToList();

                    if (objeto != null)
                    {
                        colonia.Colonias = new List<ML.Colonia>();
                        foreach (var objResult in objeto)
                        {
                            ML.Colonia objColonia = new ML.Colonia();
                            objColonia.IdColonia = objResult.IdMunicipio.Value;
                            objColonia.Nombre = objResult.Nombre;

                            colonia.Colonias.Add(objColonia);
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
