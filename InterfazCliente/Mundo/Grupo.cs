using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    [Serializable]
    public class Grupo
    {

        public List<Clase> Clases { get; set; }
        public String NombreProfesor { get; set; }

        public string NombreCortoProfesor { get; set; }
        public Materia Materia { get; set; }
        public int Id { get; set; }
        public bool[] Compatibles { get; set; }
        public bool Estado { get; set; }

        public Grupo(String nombreProfesor, Materia materia, int id)
        {
            this.Clases = new List<Clase>();
            this.NombreProfesor = nombreProfesor;
            this.Materia = materia;
            this.Id = id;
            this.NombreCortoProfesor = profesorShort();
            this.Estado = false;
        }

        public bool seCruzan(Grupo g)
        {
            if (this.Materia.Codigo == g.Materia.Codigo)
                return true;
            for (int i = 0; i < g.Clases.Count(); i++)
            {
                for (int j = 0; j < Clases.Count(); j++)
                {
                    if (g.Clases[i].cruzaClase(Clases[j]))
                        return true;
                }
            }
            return false;
        }

        ~Grupo()
        {

        }

        public void Add(Clase c)
        {
            Clases.Add(c);
        }

        public String Titulo()
        {
            String cad = "			\"profesor\":\"" + NombreProfesor + "\",\n			\"clases\":\n			[\n";
            for (int i = 0; i < Clases.Count; i++)
            {
                Clase c = Clases[i];
                cad += "				{\"dia\":\"" + c.Dia + "\", \"horaInicio\":\"" + c.HoraInicio + "\", \"horaFin\":\"" + c.HoraFin + "\"" + ", \"salon\":\"" + c.Salon + "\"}";
                if (i != Clases.Count - 1)
                    cad += ",\n";
            }
            return cad + "\n			]";
        }

        public string profesorShort()
        {
            string[] cads = NombreProfesor.Split(' ');
            string nombre = "PENDIENTE";
            if (cads[0] != "PENDIENTE")
                nombre = (cads.Length >= 3) ? cads[2] + " " + cads[0] : cads[0] + " " + cads[1];
            return nombre;
        }

        public override string ToString()
        {
            string cad = " | ";
            foreach(Clase c in Clases)
            {
                string clase = "" + c.Dia.Substring(0, 2) + " " + Clase.formatHora(c.HoraInicio) + "-" + Clase.formatHora(c.HoraFin) + " , ";
                cad += clase;
            }
            cad = "G: " + Id + " - " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NombreCortoProfesor.ToLower()) + " " + cad.Substring(0, cad.Length -2) + " |";
            return cad;
        }
    }
}
