using System.Collections.Generic;

namespace ML
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }
        public string Nombre { get; set; }
        public ML.Estado Estado { get; set; }
        public List<Municipio> Municipios { get; set; }
    }
}