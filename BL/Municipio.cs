using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static Dictionary<string, object> GetByIdEstado(int idEstado)
        {
            ML.Municipio municipio = new ML.Municipio();
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Municipio", municipio }, { "Exepcion", null }, { "Resultado", false } };
            try
            {
                using (DL_EF.LEscogidoNormalizacionEntities context = new DL_EF.LEscogidoNormalizacionEntities())
                {
                    var objeto = context.MunicipioGetByIdEstado(idEstado).ToList();

                    if (objeto != null)
                    {
                        municipio.Municipios = new List<ML.Municipio>();
                        foreach (var objResult in objeto)
                        {
                            ML.Municipio objMunicipio = new ML.Municipio();
                            objMunicipio.IdMunicipio = (byte)objResult.IdEstado;
                            objMunicipio.Nombre = objResult.Nombre;

                            municipio.Municipios.Add(objMunicipio);
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
