
namespace Mundo
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Drawing;
    using Color = System.Drawing.Color;
    using System.IO;

    public class FileManager
    {
        public const int LIMITE_SEMESTRES = 10;
        public static Color[] Colores;

        static FileManager()
        {
            Colores = new Color[] { 
                Color.Red,
                Color.YellowGreen,
                Color.Silver,
                Color.Aquamarine,
                Color.Gold,
                Color.Orange,
                Color.Beige,
                Color.Yellow,
                Color.Coral,
                Color.LightSalmon,
                Color.LimeGreen,
                Color.DarkOliveGreen,
                Color.DarkRed,
                Color.DarkGreen,
                Color.Bisque,
                Color.BlueViolet,
                Color.DarkOrchid,
                Color.DarkMagenta,
                Color.CadetBlue,
                Color.Honeydew,
                Color.GreenYellow,
                Color.MediumVioletRed,
                Color.HotPink,
                Color.Teal,
                Color.Azure,
                Color.Lavender,
                Color.Aqua,
                Color.IndianRed,
                Color.LightGreen,
                Color.LightSeaGreen,
                Color.LightSkyBlue,
                Color.LightSteelBlue,
                Color.PaleGreen,
                Color.AliceBlue,
                Color.PeachPuff,
                Color.Wheat,
                Color.DarkCyan
            };
        }

        public static void leerArchivo(Excel.Worksheet hoja, Carrera carrera, int semestre)
        {
            Excel.Range range = hoja.UsedRange;

            int totalFilas = range.Rows.Count;
            var startCell = (Range)hoja.Cells[1, 1];
            var endCell = (Range)hoja.Cells[totalFilas, 4];
            var toGetRange = hoja.Range[startCell, endCell];
            object[,] data = toGetRange.Value2;

            int filaActual = 1;
            while (filaActual <= totalFilas)
            {
                if (data[filaActual, 1] != null)
                {
                    string nombre = (string)data[filaActual, 1];
                    int creditos = 0;
                    string strCod = (string)data[filaActual, 3];
                    if ((nombre != null) && (strCod != null))
                    {
                        int codigo = Convert.ToInt32(strCod);
                        Materia m = new Materia(nombre, creditos, codigo);
                        int grupoActual = 0;
                        Grupo g = null;
                        do
                        {
                            string cadena = (string)data[filaActual, 2];
                            if (cadena != null)
                            {
                                string[] cadenas = cadena.Split(' ');
                                int numGrupo = Convert.ToInt32(cadenas[0]);
                                if (grupoActual != numGrupo)
                                {
                                    grupoActual = numGrupo;
                                    string nombreProfesor = "";
                                    for (int j = 1; j < cadenas.Length; j++)
                                        nombreProfesor += cadenas[j] + " ";
                                    nombreProfesor = nombreProfesor.TrimEnd();
                                    g = new Grupo(nombreProfesor, m, grupoActual);
                                    m.Add(g);
                                }
                                do
                                {
                                    string[] clase = ((string)data[filaActual, 4]).Split(' ');
                                    string salon = clase[3];
                                    int horaInicioInt = Convert.ToInt32(clase[1].Replace(":", ""));
                                    int horaFinInt = Convert.ToInt32(clase[2].Replace(":", ""));
                                    bool contiene = false;
                                    for (int i = 0; i < g.Clases.Count && !contiene; i++)
                                    {
                                        Clase ca = g.Clases[i];
                                        contiene = (ca.HoraInicio == horaInicioInt && ca.HoraFin == horaFinInt && ca.NumeroDia == Clase.GetDiaSubStringToInt(clase[0]));
                                    }
                                    if (!contiene)
                                        g.Add(new Clase(Clase.GetDiaSubStringToInt(clase[0]), horaInicioInt, horaFinInt, salon));
                                    filaActual++;
                                } while (filaActual <= totalFilas && (data[filaActual, 2] == null || ((string)data[filaActual, 2]) == "") && data[filaActual, 4] != null);
                                filaActual--;
                            }
                            filaActual++;
                        } while (filaActual <= totalFilas && data[filaActual, 1] == null && data[filaActual, 4] != null);
                        filaActual--;
                        carrera.Semestres[semestre - 1].Materias.Add(m);
                    }
                }
                filaActual++;
            }
        }

        public static Dictionary<string, Color> AsignarColores(List<Materia> Materias)
        {
            int pos = 0;
            Dictionary<string, Color> coloresMateria = new Dictionary<string, Color>();
            for (int i = 0; i < Materias.Count; i++)
            {
                if (pos == Colores.Length)
                    pos = 0;
                coloresMateria.Add(Materias[i].Nombre, Colores[pos++]);
            }
            return coloresMateria;
        }

        public static void pintarHorariosExcel(List<Horario> horarios, List<Materia> Materias)
        {
            Excel.Application xlApp;
            Excel.Workbooks xlWorkBooks;
            Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;
            xlApp = new Excel.Application();
            xlWorkBooks = xlApp.Workbooks;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            Dictionary<string, Color> coloresMateria = AsignarColores(Materias);
            Excel.Worksheet sheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            sheet.Name = "Horarios";

            int rCnt = 1;
            int value = horarios.Count * (Materias.Count + 1 + 10);
            object[,] horariosArray = new object[value, 11];
            for (int h = 0; h < horarios.Count; h++)
            {
                Horario horario = horarios[h];
                pintarHorario(horariosArray, horario, rCnt, coloresMateria, h + 1);
                rCnt += 10;
            }
            var startCell = (Range)sheet.Cells[1, 1];
            var endCell = (Range)sheet.Cells[value, 11];
            var writeRange = sheet.Range[startCell, endCell];

            writeRange.Value2 = horariosArray;
            for (int i = 0; i < Materias.Count; i++)
            {
                Materia materia = Materias[i];
                validator(sheet, value, coloresMateria[materia.Nombre], materia.Nombre);
            }
            xlApp.Visible = true;
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlWorkBooks);
            Marshal.ReleaseComObject(xlApp);

        }

        private static void validator(Excel.Worksheet sheet, int lastCellRowNum, Color color, string subject)
        {
            FormatCondition cond = sheet.get_Range("A1:I" + lastCellRowNum, Type.Missing).FormatConditions.Add(XlFormatConditionType.xlTextString, Type.Missing, Type.Missing, Type.Missing, subject, XlContainsOperator.xlContains, Type.Missing, Type.Missing);
            cond.Interior.Color = color;
        }

        private static void pintarHorario(object[,] horariosArray, Horario horario, int rCnt, Dictionary<string, Color> colores, int counter)
        {
            string[] dias = new string[] { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes!", "Sabado", "Domingo", "", "Horario# " + counter, "Codigo: " + horario.Id };
            for (int i = 0; i < dias.Length; i++)
                horariosArray[rCnt, i + 1] = dias[i];
            rCnt++;
            horario.Sort((a, b) => a.Materia.Nombre.CompareTo(b.Materia.Nombre));
            for (int i = 0; i < horario.Count(); i++)
            {
                Grupo grupo = horario[i];
                Materia materia = grupo.Materia;
                List<Clase> clases = grupo.Clases;
                for (int j = 0; j < clases.Count(); j++)
                {
                    Clase clase = clases[j];
                    int dia = clase.NumeroDia + 1;
                    horariosArray[rCnt, dia] = FileManager.reporteClase(grupo, clase);
                }
                rCnt++;
            }
        }

        public static string reporteClase(Grupo g, Clase c)
        {
            return "Gr-" + g.Id + Environment.NewLine + g.Materia.Nombre.Trim() + Environment.NewLine + "Prof: " + g.NombreCortoProfesor + Environment.NewLine + c.HoraInicio + "-" + c.HoraFin;
        }

        public static void CargarDatosDeArchivoFinal(string path, Carrera carrera)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                             Type.Missing, Type.Missing);
            for (int i = 0; i < 10; i++)
            {
                Excel.Worksheet hoja = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i + 2);
                FileManager.leerArchivo(hoja, carrera, i + 1);
                Marshal.ReleaseComObject(hoja);
            }
            pintarMateriasJson(carrera);
            xlWorkBook.Close(true, Type.Missing, Type.Missing);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
        public static void pintarMateriasJson(Carrera carrera)
        {
            string nombre = carrera.Nombre.ToLower();
            StreamWriter sale = new StreamWriter("HORPROG0" + nombre + ".json");
            String cadena = "[\n";
            List<Semestre> semestres = carrera.Semestres;
            for (int l = 0; l < semestres.Count; l++)
            {
                Semestre sem = semestres[l];
                List<Materia> materias = sem.Materias;
                for (int i = 0; i < materias.Count(); i++)
                {
                    Materia m = materias[i];
                    List<Grupo> grupos = m.Grupos;
                    cadena += "	{\n 	\"semestre\":\"" + sem.NumeroSemestre + "\",\n" + "	\"materia\":\"" + m + "\",\n	\"grupos\":[";
                    for (int j = 0; j < grupos.Count(); j++)
                    {
                        Grupo g = grupos[j];
                        cadena += "	\n		{	\"id\":\"" + g.Id + "\",		\n" + g.Titulo() + "\n		}";
                        if (j != grupos.Count() - 1)
                            cadena += ",";
                    }
                    if (i < materias.Count() - 1)
                        cadena += "]\n	},\n";
                    else
                        cadena += "]\n	}\n";
                }
                if (l < semestres.Count() - 1)
                    cadena += ",";
            }
            cadena += "]";
            sale.WriteLine(cadena);
            sale.Flush();
            sale.Close();
        }
    }
}
