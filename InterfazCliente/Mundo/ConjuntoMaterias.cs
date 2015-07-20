using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    public class ConjuntoMaterias
    {
        public List<Materia> Materias { get; set; }
        public bool Estado { get; set; }
        public string NombreConjunto { get; set; }
        public ConjuntoMaterias(string nombreConjunto)
        {
            Estado = false;
            Materias = new List<Materia>();
            NombreConjunto = nombreConjunto;
        }

        public override string ToString()
        {
            return NombreConjunto;
        }
    }
}
