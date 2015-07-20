using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Threading;
namespace Mundo
{
    [Serializable]
    public class EasyHour
    {
        public const int LIMITE_MATERIAS = 8;
        public const int LIMITE_CREDITOS = 21;

        public List<Materia> Materias { get; set; }
        public List<Grupo> Grupos { get; set; }
        public List<Carrera> Carreras { get; set; }
        public ConjuntoMaterias Ingles { get; set; }
        public List<ConjuntoMaterias> CategoriasElectivas { get; set; }
        public List<int> DiasFiltrados { get; set; }
        public List<string> FiltrosHoraDia { get; set; }
        public List<Horario> HorariosFavoritos { get; set; }
        public int[] RestriccionIdeal { get; set; }

        public EasyHour()
        {
            Materias = new List<Materia>();
            Grupos = new List<Grupo>();
            RestriccionIdeal = new int[4];
            Carreras = new List<Carrera>(2);
            DiasFiltrados = new List<int>();
            FiltrosHoraDia = new List<string>();
            HorariosFavoritos = new List<Horario>();
            Ingles = new ConjuntoMaterias("Inglés");
            CategoriasElectivas = new List<ConjuntoMaterias>();
        }

        public Carrera cargarCarrera(string nombreCarrera, bool simultaneidad, string nombreArchivo)
        {
            Carrera carrera = null;
            if (nombreCarrera == null || nombreCarrera == "")
                throw new Exception("Carrera seleccionada inválida");
            if (nombreArchivo == null || nombreArchivo == "")
                throw new Exception("Nombre archivo inválido");
            if (Carreras.Count == 0 || (Carreras.Count <= 1 && simultaneidad))
            {
                carrera = new Carrera(nombreCarrera);
                Carreras.Add(carrera);
                FileManager.CargarDatosDeArchivoFinal(nombreArchivo, carrera);
            }
            else
            {
                if (Carreras.Count == 2)
                    throw new Exception("Ya ha cargado las dos carreras de su simultaneidad");
                else
                    throw new Exception("No puede cargar otra carrera." + Environment.NewLine + "Puede seleccionar simultaneidad para cargar una segunda carrera");
            }
            return carrera;
        }
        public List<Grupo> GetGruposDeMaterias(List<Materia> materias)
        {
            List<Grupo> grupos = new List<Grupo>();
            foreach (Materia materia in materias)
                foreach (Grupo grupo in materia.Grupos)
                    grupos.Add(grupo);
            return grupos;
        }
        public List<Horario> GenerarHorarios(int diasLibresEsperados, bool enSemana)
        {
            if (existenMateriasRepetidas())
                throw new Exception("Existen materias repetidas en la selección actual." + Environment.NewLine + "Revise las materias seleccionadas.");
            if (Materias.Count > 8)
                throw new Exception("Debe seleccionar máximo " + EasyHour.LIMITE_MATERIAS + " materias");

            List<Horario> iniciales = horariosInicialesDeGrupos(Grupos);
            List<Horario>[] horariosPorMaterias = new List<Horario>[9];
            for (int i = 0; i < horariosPorMaterias.Length; i++)
                horariosPorMaterias[i] = new List<Horario>();
            foreach (Horario h in iniciales)
                horariosPorMaterias[1].Add(h);

            Dictionary<string, int> indicesGrupos = new Dictionary<string, int>(500);
            for (int i = 0; i < Grupos.Count; i++)
            {
                Grupo g = Grupos[i];
                g.Compatibles = new bool[Grupos.Count];
                indicesGrupos.Add(g.Materia.Nombre + "" + g.Id, i);
            }
            for (int i = 0; i < Grupos.Count; i++)
            {
                Grupo g1 = Grupos[i];
                for (int j = i; j < Grupos.Count; j++)
                {
                    Grupo g2 = Grupos[j];
                    bool ver = g1.seCruzan(g2);
                    g1.Compatibles[j] = g2.Compatibles[i] = !ver;
                }
            }
            combinarHorarios(horariosPorMaterias, iniciales, Grupos, indicesGrupos);
            List<Horario> listaGenerados = horariosPorMaterias[Materias.Count];
            int horariosGenerados = listaGenerados.Count;
            if (horariosGenerados != 0)
            {
                bool a = buscarHorariosRepetidos(horariosPorMaterias);
                int b = filtrarPorDias(listaGenerados);
                ordenarHorariosPorHoraMedia(listaGenerados);
                eliminarHorariosSinRestriccionesIdeales(listaGenerados);
                if (diasLibresEsperados != 0)
                    filtrarDiasCantidadLibre(listaGenerados, diasLibresEsperados, enSemana);
                int c = filtrarHoraDia(listaGenerados);
            }
            horariosPorMaterias = null;
            GC.Collect();
            return listaGenerados;
        }

        public void eliminarMateria(Materia m)
        {
            Materias.Remove(m);
            Grupos.RemoveAll(g => g.Materia.Nombre == m.Nombre);
        }

        public void eliminarGrupo(Grupo g)
        {
            Grupos.Remove(g);
        }

        private bool verificar(Grupo grupo, Horario array, Dictionary<string, int> indicedGrupo)
        {
            int indice = indicedGrupo[grupo.Materia.Nombre + "" + grupo.Id];
            foreach (Grupo g in array)
            {
                if (!g.Compatibles[indice])
                    return false;
            }
            return true;
        }

        public bool existenMateriasRepetidas()
        {
            for (int i = 0; i < Materias.Count; i++)
            {
                for (int j = i + 1; j < Materias.Count; j++)
                {
                    if (Materias[i].Equals(Materias[j]))
                        return true;
                }
            }
            return false;
        }

        private List<Horario> horariosInicialesDeGrupos(List<Grupo> grupos)
        {
            List<Horario> horarios = new List<Horario>();

            for (int i = 0; i < grupos.Count(); i++)
            {
                Horario h = new Horario(i + "");
                h.Add(grupos[i]);
                foreach (Clase c in grupos[i].Clases)
                    if (h.DiasOcupados[c.NumeroDia] == 0)
                    {
                        h.CantidadDiasOcupados++;
                        h.DiasOcupados[c.NumeroDia] = 1;
                    }
                horarios.Add(h);
            }

            return horarios;
        }

        public void cambiarEstadoGrupos(Materia m)
        {
            foreach (Grupo g in m.Grupos)
            {
                g.Estado = m.Estado;
                if (g.Estado)
                    Grupos.Add(g);
                else
                    Grupos.Remove(g);
            }
        }

        public void cambiarEstadoMaterias(ConjuntoMaterias conjunto)
        {
            foreach (Materia m in conjunto.Materias)
            {
                m.Estado = conjunto.Estado;
                if (m.Estado)
                    Materias.Add(m);
                else
                    Materias.Remove(m);
                cambiarEstadoGrupos(m);
            }
        }

        private void combinarHorarios(List<Horario>[] horarios, List<Horario> horariosIniciales, List<Grupo> grupos, Dictionary<string, int> indicesGrupos)
        {
            foreach (Horario horario in horariosIniciales)
            {
                int cred = horario.Creditos;
                if (horario.Count() < LIMITE_MATERIAS && cred < LIMITE_CREDITOS)
                {
                    List<Horario> lista = new List<Horario>();
                    for (int i = GetNextGroupIndex(indicesGrupos, horario); i < grupos.Count(); i++)
                    {
                        Grupo grupo = grupos[i];
                        if (verificar(grupo, horario, indicesGrupos))
                        {
                            Horario horarT = Horario.ClonarHorario(horario);
                            horarT.Add(grupo);
                            horarT.Id += i + ".";
                            horarT.Creditos = cred + grupo.Materia.Creditos;
                            int restr = grupo.Materia.Restriccion;
                            if (restr != int.MaxValue)
                                horarT.Restriccion[restr]++;
                            foreach (Clase c in grupo.Clases)
                                if (horarT.DiasOcupados[c.NumeroDia] == 0)
                                {
                                    horarT.CantidadDiasOcupados++;
                                    horarT.DiasOcupados[c.NumeroDia] = 1;
                                }
                            horarios[horarT.Count].Add(horarT);
                            lista.Add(horarT);
                        }
                    }
                    if (lista.Count != 0)
                        combinarHorarios(horarios, lista, grupos, indicesGrupos);
                }
            }
        }

        private int GetNextGroupIndex(Dictionary<string, int> indicesGrupos, Horario horario)
        {
            Grupo g = horario[horario.Count() - 1];
            return indicesGrupos[g.Materia.Nombre + "" + g.Id] + 1;
        }

        private void eliminarHorariosSinRestriccionesIdeales(List<Horario> horarios)
        {
            int numIdeal = 0;
            for (int i = 0; i < RestriccionIdeal.Length && RestriccionIdeal[i] != 0; i++)
                numIdeal++;
            for (int j = 0; j < horarios.Count; j++)
            {
                Horario h = horarios[j];
                bool sale = false;
                for (int k = 0; k < numIdeal && !sale; k++)
                {
                    if (h.Restriccion[k] != 0 && h.Restriccion[k] != RestriccionIdeal[k])
                    {
                        sale = true;
                        horarios.Remove(h);
                        j--;
                    }
                }
            }
        }

        private Boolean buscarHorariosRepetidos(List<Horario>[] ListaPorCantidadMateria)
        {
            foreach (List<Horario> horarios in ListaPorCantidadMateria)
            {
                for (int i = 0; i < horarios.Count; i++)
                {
                    Horario uno = horarios[i];
                    bool salir = false;
                    for (int j = i + 1; j < horarios.Count && !salir; j++)
                    {
                        Horario dos = horarios[j];
                        foreach (Grupo g in uno)
                        {
                            if (!dos.Contains(g))
                                salir = true;
                        }
                        if (!salir)
                            return true;
                    }
                }
            }
            return false;
        }

        private void ordenarHorariosPorHoraMedia(List<Horario> horarios)
        {
            horarios.Sort((a, b) => a.horaMedia().CompareTo(b.horaMedia()));
        }

        private int filtrarPorDias(List<Horario> horarios)
        {
            int borrados = 0;
            for (int i = 0; i < DiasFiltrados.Count; i++)
            {
                int dia = DiasFiltrados[i];
                for (int j = horarios.Count - 1; j >= 0; j--)
                {
                    Horario h = horarios[j];
                    if (h.DiasOcupados[dia] == 1)
                    {
                        horarios.RemoveAt(j);
                        borrados++;
                    }
                }
            }
            return borrados;
        }

        private int filtrarDiasCantidadLibre(List<Horario> horarios, int diasLibresEsperados, bool enSemana)
        {
            int cantidadFiltrados = 0;
            for (int i = horarios.Count - 1; i >= 0; i--)
            {
                Horario h = horarios[i];
                int exceso = (enSemana) ? 7 - h.CantidadDiasOcupados + (h.DiasOcupados[5] + h.DiasOcupados[6] - 2) : 7 - h.CantidadDiasOcupados;
                if (exceso < diasLibresEsperados)
                {
                    horarios.RemoveAt(i);
                    cantidadFiltrados++;
                }
            }
            return cantidadFiltrados;
        }

        private int filtrarHoraDia(List<Horario> horarios)
        {
            int cantidadFiltrados = 0;
            foreach (string s in FiltrosHoraDia)
            {
                string[] data = s.Split(' ');
                string dia = data[0];
                string inicio = data[2];
                string fin = data[4];
                int intDay = (dia != "Semana") ? Clase.GetDiaFullStringToInt(dia) : -1;

                int ini = Convert.ToInt32(inicio.Replace(":", ""));
                int fini = Convert.ToInt32(fin.Replace(":", ""));

                for (int i = horarios.Count - 1; i >= 0; i--)
                {
                    Horario h = horarios[i];
                    bool breaks = false;
                    if (intDay == -1 || h.DiasOcupados[intDay] != 0)
                    {
                        foreach (Grupo g in h)
                        {
                            foreach (Clase c in g.Clases)
                            {
                                if ((c.NumeroDia == intDay || intDay == -1) && Clase.cruzanHoras(ini, fini, c.HoraInicio, c.HoraFin))
                                {
                                    horarios.RemoveAt(i);
                                    breaks = true;
                                    break;
                                }
                            }
                            if (breaks)
                                break;
                        }
                    }
                }
            }
            return cantidadFiltrados;
        }

        public static void Main()
        {
            new EasyHour();
            Console.ReadLine();
        }
    }
}
