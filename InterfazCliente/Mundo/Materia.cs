using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    [Serializable]
    public class Materia
    {

        public List<Grupo> Grupos { get; set; }
        public int Creditos { get; set; }
        public string Nombre { get; set; }
        public int Restriccion { get; set; }
        public int Codigo { get; set; }
        public bool Estado { get; set; }

        public Materia(String nombre, int creditos, int codigo)
        {
            this.Nombre = nombre;
            this.Grupos = new List<Grupo>();
            this.Creditos = creditos;
            this.Restriccion = int.MaxValue;
            this.Codigo = codigo;
            this.Estado = false;
        }

        public void Add(Grupo g)
        {
            Grupos.Add(g);
        }

        public override String ToString()
        {
            string cad = Nombre; //+ " - Crd: " + Creditos;
            if (Restriccion != int.MaxValue)
                cad += " - R: " + Restriccion;
            return cad;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Materia m = obj as Materia;
            if ((Object)m == null)
            {
                return false;
            }
            return (Nombre == m.Nombre && Creditos == m.Creditos);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
