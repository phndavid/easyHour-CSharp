using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    public class Semestre : ConjuntoMaterias
    {
        public Carrera Carrera { get; set; }
        public int NumeroSemestre { get; set; }

        public Semestre(Carrera carrera, int numeroSemestre)
            : base(definirNombreSemestre(carrera, numeroSemestre))
        {
            this.Carrera = carrera;
            this.NumeroSemestre = numeroSemestre;
            this.Materias = new List<Materia>();
            this.Estado = false;
        }

        private static string definirNombreSemestre(Carrera c, int numeroSemestre)
        {
            string[] nombre = c.Nombre.Split(' ');
            string cad = "";
            foreach (string s in nombre)
                cad += s + ".";
            return "Semestre #" + numeroSemestre;
        }
    }
}
