using System.Collections.Generic;

namespace ML
{
    public class Colonia
    {
        public int IdColonia { get; set; }
        public string Nombre { get; set; }
        public ML.Municipio Municipio { get; set; }
        public List<Colonia> Colonias { get; set; }
    }
}