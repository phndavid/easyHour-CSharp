using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    public class Carrera
    {
        public string Nombre { get; set; }
        public List<Semestre> Semestres;

        public Carrera(string nombre)
        {
            this.Nombre = nombre;
            Semestres = new List<Semestre>();
            for (int i = 0; i < 10; i++)
                Semestres.Add(new Semestre(this, i + 1));
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

}
