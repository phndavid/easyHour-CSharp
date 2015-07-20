using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    [Serializable]
    public class Horario : List<Grupo>
    {

        public string Id { get; set; }
        public int Creditos { get; set; }

        public int[] Restriccion { get; set; }

        public int[] DiasOcupados { get; set; }

        public int CantidadDiasOcupados { get; set; }

        public Horario(string id)
        {
            this.Id = id;
            Creditos = 0;
            Restriccion = new int[4];
            DiasOcupados = new int[7];
            CantidadDiasOcupados = 0;
        }

        public Horario()
        {

        }

        public double horaMedia()
        {
            double sum = 0.0;
            int classCount = 0;
            foreach(Grupo g in this)
            {
                classCount += g.Clases.Count;
                foreach (Clase c in g.Clases)
                    sum += c.HoraInicio;
            }
            return sum / classCount;
        }

        public static Horario ClonarHorario(Horario toClone)
        {
            Horario cloned = new Horario();
            foreach (Grupo g in toClone)
                cloned.Add(g);
            cloned.Id = toClone.Id;
            cloned.Restriccion = new int[4];
            cloned.DiasOcupados = new int[7];
            cloned.CantidadDiasOcupados = toClone.CantidadDiasOcupados;
            for (int i = 0; i < toClone.Restriccion.Length && toClone.Restriccion[i] != 0; i++)
                cloned.Restriccion[i] = toClone.Restriccion[i];
            for (int i = 0; i < toClone.DiasOcupados.Length; i++)
                cloned.DiasOcupados[i] = toClone.DiasOcupados[i];
            return cloned;
        }

        public override String ToString()
        {

            String inicioHorario = "";
            String lunes = "		{\"dia\":\"Lunes\",\"materias\":[";
            String martes = "		{\"dia\":\"Martes\",\"materias\":[";
            String miercoles = "		{\"dia\":\"Miercoles\",\"materias\":[";
            String jueves = "		{\"dia\":\"Jueves\",\"materias\":[";
            String viernes = "		{\"dia\":\"Viernes!\",\"materias\":[";
            String sabado = "		{\"dia\":\"Sabado\",\"materias\":[";

            int[] contiene = new int[7];
            for (int i = 0; i < this.Count(); i++)
            {
                Grupo grupo = this[i];
                Materia materia = grupo.Materia;
                List<Clase> clases = grupo.Clases;
                for (int j = 0; j < clases.Count(); j++)
                {
                    Clase clase = clases[j];
                    int dia = clase.NumeroDia;
                    contiene[dia] = 1;
                    String format = "{\"grupo\":" + "\"" + grupo.Id + "\",\"materia\":" + "\"" + materia + "\",\"horaInicio\":" + clase.HoraInicio + ",\"horaFin\":" + clase.HoraFin + "},";

                    if (dia == Clase.LUNES)
                        lunes += format;
                    if (dia == Clase.MARTES)
                        martes += format;
                    if (dia == Clase.MIERCOLES)
                        miercoles += format;
                    if (dia == Clase.JUEVES)
                        jueves += format;
                    if (dia == Clase.VIERNES)
                        viernes += format;
                    if (dia == Clase.SABADO)
                        sabado += format;
                }
            }
            if (contiene[Clase.LUNES] == 1)
                lunes = lunes.Substring(0, lunes.Length - 1);
            if (contiene[Clase.MARTES] == 1)
                martes = martes.Substring(0, martes.Length - 1);
            if (contiene[Clase.MIERCOLES] == 1)
                miercoles = miercoles.Substring(0, miercoles.Length - 1);
            if (contiene[Clase.JUEVES] == 1)
                jueves = jueves.Substring(0, jueves.Length - 1);
            if (contiene[Clase.VIERNES] == 1)
                viernes = viernes.Substring(0, viernes.Length - 1);
            if (contiene[Clase.SABADO] == 1)
                sabado = sabado.Substring(0, sabado.Length - 1);


            String f2 = "]},\n"; // Cierre de: {"dia":"Sabado", "materias":[]}

            inicioHorario += "\n{\n\"estado\": true,\n\"dias\":\n	[\n"
                    + lunes + f2
                    + martes + f2
                    + miercoles + f2
                    + jueves + f2
                    + viernes + f2
                    + sabado + "]}\n	]\n}";
            return inicioHorario;
        }
    }
}
