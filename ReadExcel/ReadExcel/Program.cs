using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace FormatExcel
{
    class Program
    {
        public const string INGENIERIA_TELEMATICA = "INGENIERÍA TELEMÁTICA";
        public const string ECONOMIA_Y_NEGOCIOS = "ECONOMÍA Y NEGOCIOS INTERNACIONALES";
        public const string MERCADEO = "MERCADEO INTERNACIONAL Y PUBLICIDAD";


        public static Excel.Application xlApp;
        public static Excel.Worksheet xlSemestres;
        public static Excel.Workbook xlWorkBook;
        public static Excel.Range range;
        public static Excel.Worksheet[] hojas;
       
        static void Main(string[] args)
        {
                InicializarExcel();
            //Crear hojas de trabajo (Se realiza sola una vez).
                CrearHojasDeTrabajo();
            //Inicializar hojas de trabajo.
                InicalizarHojasDeTrabajo();
             //Pasos:
                //1. Guardar pdf en txt. (Manual).
                //2. Copiar texto del archivo txt en un archivo de excel xlsx. (Manal)
                //3. Separar el texto en dos columnas (Manual)
                //4. Eliminar espacios en blanco.
                 //EliminarEspacios(); (Preferiblemente hacerlo de forma manual)
                //5. Borrar electivas(profesionales,biologia,humanidades,etc), extrariculares, idiomas.
                 BorrarElectivas();
                //6. Eliminar texto no deseado.
                 EliminarTextoNoDeseado(range);
                //7. Pegar semestres en diferentes hojas de trabajo.
                 PegarSemestre();
                //8. Eliminar el texto "Semestre-#" de cada hojas de trabajo. 
                 ELiminarTextoSemestrePorSemestre();
                //9. Eliminar fila de nombre extenso.
                 EliminarEspaciosEnBlanco();
                //10. Solucionar problema: Nombre de materias muy extensos.
                 SolNombreExtensos();
                //11. Borrar materias repetidas por semestre.
                 BorrarMateriasRepetidasPorSemestre();
                //12. Quitar espacios en blanco de celdas
                 QuitarEspaciosEnBlancoCeldas(); 
                //13. Lectura 
                 ExtraerClasesDeGrupos();
                //14. Guardar archivo de excel con los cambios realizados.
                SaveExcel();

        }
        public static void InicializarExcel()
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open("A:\\Libro1.xlsx",
                                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                             Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                             Type.Missing, Type.Missing);
            xlSemestres = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlSemestres.Name = "Semestres";
            range = xlSemestres.UsedRange;
        }
        public static void SaveExcel()
        {
            xlWorkBook.Close(true, Type.Missing, Type.Missing);
            xlApp.Quit();
            releaseObject(xlSemestres);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        public static void CrearHojasDeTrabajo()
        {
            for (int i = 0; i < 10; i++)
                xlWorkBook.Sheets.Add(After: xlWorkBook.Sheets[xlWorkBook.Sheets.Count]);
        }
        public static void InicalizarHojasDeTrabajo()
        {
            hojas = new Excel.Worksheet[10];
            int index = 2;
            for (int i = 0; i < 10; i++)
            {
                hojas[i] = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(index);
                hojas[i].Name = "S-0" + (index - 1);
                index++;
            }
        }
        public static void BorrarElectivas(){
            Console.WriteLine("Borrando electivas");
            string str;
            int rCnt = 1;
            int i = 1;
            bool encontro = false;
            while (rCnt <= range.Rows.Count)
            {
                str = (range.Cells[rCnt, 2] as Excel.Range).Value2 +"";
                if (str != null && str == "Profesional Electiva" && !encontro)
                {
                    encontro = true;
                    i = rCnt;
                }
                if (encontro) { 
                    range.Cells[i,range.Rows.Count].EntireRow.Delete();
                    rCnt--;
                }
                
                rCnt++;
            }
            
        }
        public static void CopiarSemestre(Excel.Range range, Excel.Worksheet xlWorkSheet, int semestre, int semestreD)
        {
        
            string str;
            int i = 0;
            int j = 0;
            bool sem1 = false, sem2 = false;
            bool sem10 = false;
            for (int rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
            {
                for (int cCnt = 1; cCnt <= 2; cCnt++)
                {
                    str = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                    if (str == ("Semestre 0" + semestre) && !sem1)
                    {
                        Console.WriteLine(str);
                        i = rCnt;
                        sem1 = true;
                    }
                    if ((semestre + 1) != 10)
                    {
                        if (str == ("Semestre 0" + (semestre + 1)) && !sem2)
                        {
                            Console.WriteLine(str);
                            j = rCnt;
                            Console.WriteLine("A" + i + ":B" + j);
                            xlWorkSheet.Range["A" + i + ":B"+(j-1)].Copy();
                            sem2 = true;
                        }
                    }
                    else if (str == "Semestre 10" && !sem2)
                    {
                        Console.WriteLine(str);
                        j = rCnt;
                        Console.WriteLine("A" + i + ":B" + j);
                        xlWorkSheet.Range["A" + i + ":B" + j].Copy();
                        sem2 = true;
                    }
                    if (str == "Semestre " + semestreD && !sem10)
                    {
                        Console.WriteLine(str);
                        j = rCnt;
                        xlWorkSheet.Range["A" + j + ":B" + range.Rows.Count].Copy();
                        sem10 = true;
                    }
                }
            }

        }
        public static void PegarSemestre()
        {
            Console.WriteLine("Pegar semestres.");
            for (int i = 0; i < 10; i++)
            {
                if (i == 10)
                {
                    CopiarSemestre(range, xlSemestres, (i + 1), (i + 1));
                    hojas[i].Paste();
                }
                else
                {
                    CopiarSemestre(range, xlSemestres, (i + 1), (i + 1));
                    hojas[i].Paste();
                }
            }
        }
        
        public static void EliminarTextoNoDeseado(Excel.Range range)
        {
            string str;
            int rCnt = 1;
            while (rCnt <= range.Rows.Count)
            {
               
                bool elimino = false;
                for (int i = 1; i <= 2 && !elimino; i++)
                {
                    string[] palabras = new string[]
                    {
                        "SISTEMA DE PROGRAMACIÓN DE CURSOS DE PREGRADO",
                        "Listado de Horarios Por Programa",
                        "Período Académico 142",
                        "OFERTA",
                        "MATERIA",
                        "RRPROHORAR -  PSIAEPRE",
                        "OFERTA: DI = Diurno, NO = Nocturno",
                        "CÓDIGO: PC = Problemas Colombianos",
                        "IDIOMA: ESP = Español, ING = Inglés",
                        MERCADEO
                    };
                    str = (string)(range.Cells[rCnt, i] as Excel.Range).Value2;
                    for (int j = 0; j < palabras.Length && !elimino; j++)
                    {
                        if ((str != null) && (str == palabras[j] || str[0] == '-'))
                        {
                            elimino = true;
                            Console.WriteLine(str);
                            range.Cells[rCnt, 1].EntireRow.Delete();
                            rCnt--;
                        }
                    }
                }
                rCnt++;
            }
        }
        public static void ELiminarTextoSemestrePorSemestre()
        {
            Console.WriteLine("Eliminar texto semestre por semestre");
            string str;
            for (int i = 0; i < 10; i++)
            {
                int rCnt = 1;
                while (rCnt <= hojas[i].UsedRange.Rows.Count)
                {
                    for (int cCnt = 1; cCnt <= 2; cCnt++)
                    {
                        str = (string)(hojas[i].UsedRange.Cells[rCnt, cCnt] as Excel.Range).Value2;
                        string sem = ("Semestre 0" + (i + 1));
                        if (str == sem)
                        {
                            hojas[i].UsedRange.Cells[rCnt, cCnt].EntireRow.Delete();
                            rCnt--;
                        }
                        if (str == "Semestre 10")
                        {
                            hojas[i].UsedRange.Cells[rCnt, cCnt].EntireRow.Delete();
                            rCnt--;
                        }
                            
                    }
                    rCnt++;
                }
            }
        }
        public static void BorrarMateriasRepetidasPorSemestre()
        {
            Console.WriteLine("Borrar materias repetidas por semestre");
            for (int r = 0; r < 10; r++)
            {

                string str;
                int i = 1;
                string textoTemp = "";
                while (i <= hojas[r].UsedRange.Rows.Count)
                {
                    str = (string)(hojas[r].UsedRange.Cells[i, 1] as Excel.Range).Value2;
                    if (str != null && textoTemp == str)
                    {
                        string gr = (string)(hojas[r].UsedRange.Cells[i, 2] as Excel.Range).Value2;
                        if (gr != null)
                        {
                            string n = gr.Trim();
                            if (!char.IsDigit(n[0]))
                            {
                                int j = 0;
                                while (!char.IsDigit(n[j]))
                                    j++;
                                string exceso = n.Substring(0, (j - 1));
                                string formato = n.Replace(exceso, "").Trim();
                                string code = formato.Substring(0, 5);
                                string cadena = formato.Replace(code, "").Trim();
                                hojas[r].UsedRange.Cells[i, 2] = cadena;
                                Console.WriteLine(cadena);
                            }
                            string code1 = n.Substring(0, 5);
                            string cadena1 = n.Replace(code1, "").Trim();
                            hojas[r].UsedRange.Cells[i, 2] = cadena1;
                            Console.WriteLine(cadena1);
                        }
                        hojas[r].UsedRange.Cells[i, 1] = "";
                    }
                    else if (str != null)
                    {
                        textoTemp = str;
                        string c = (string)(hojas[r].UsedRange.Cells[i, 2] as Excel.Range).Value2;
                        if (c != null)
                        {
                            string cod = c.Substring(0, 5);
                            hojas[r].UsedRange.Cells[i, 3] = cod;
                            string cadena = c.Replace(cod, "").Trim();
                            hojas[r].UsedRange.Cells[i, 2] = cadena;
                        }
                        
                    }
                    i++;
                }
            }
        }
        public static void QuitarEspaciosEnBlancoCeldas()
        {
            Console.WriteLine("Quitar espacios en blanco sobrantes.");
            for(int r = 0; r<10; r++){
                string str;
                int i = 1;
                while(i <= hojas[r].UsedRange.Rows.Count){

                    str = (string)(hojas[r].UsedRange.Cells[i, 2] as Excel.Range).Value2;
                    if (str != null) { 
                        string[] palabras = str.Split(' ');
                        string c = "";
                        for (int j = 0; j < palabras.Length; j++)
                            if (!palabras[j].Equals(""))
                                c += " " + palabras[j];

                        hojas[r].UsedRange.Cells[i, 2].Value2 = c.Trim();
                    }
                    i++;
                }
            }
            

        }
        public static void SolNombreExtensos()
        {
            Console.WriteLine("Nombres extensos");
            for (int r = 0; r < 10; r++) 
            {
                string str;
                int i = 1;
                while (i <= hojas[r].UsedRange.Rows.Count)
                {
                    str = (string)(hojas[r].UsedRange.Cells[i, 1] as Excel.Range).Value2;
                    string gr = (string)(hojas[r].UsedRange.Cells[i, 2] as Excel.Range).Value2;
                    if (str != null && gr != null)
                    {
                        string n = gr.Trim();
                        if (!char.IsDigit(n[0]))
                        {
                            int j = 0;
                            while (!char.IsDigit(n[j]))
                                j++;
                            string exceso = n.Substring(0, (j - 1));
                            string formato = n.Replace(exceso, "").Trim();
                            hojas[r].UsedRange.Cells[i, 2] = formato;
                            Console.WriteLine(formato);
                        }
                    }

                    i++;
                }
            }
        }
        public static void EliminarEspaciosEnBlanco()
        {
            Console.WriteLine("Eliminar filas de texto nombre materias en exceso ");
            for (int r = 0; r < 10; r++)
            {
                int i = 1;
                while (i <= hojas[r].UsedRange.Rows.Count)
                {
                    if (hojas[r].UsedRange.Cells[i, 2].Value2 == null)
                        hojas[r].UsedRange.Cells[i, 2].EntireRow.Delete();

                    i++;
                }
            }
            
        }
        public static void EliminarEspacios()
        {
            Console.WriteLine("Eliminar espacios ");
            int i = 1;
            while (i <= range.Rows.Count)
            {
                if (range.Cells[i, 2].Value2 == null) { 
                    range.Cells[i, 2].EntireRow.Delete();
                    i--;
                }
                i++;
            }
        }
        public static void ExtraerClasesDeGrupos()
        {
            for (int r = 0; r < 10; r++) { 
                int rCnt = 1;
                while (rCnt <= hojas[r].UsedRange.Rows.Count)
                {
                    string g = (string)(hojas[r].UsedRange.Cells[rCnt, 2] as Excel.Range).Value2;
                    if (g != null && char.IsDigit(g[0]))
                    {
                        string cadena = g.Replace(" ESP ",",");
                        Console.WriteLine(cadena);
                        string[] cadenas = cadena.Split(',');
                        string c1 = cadenas[0].Trim();
                        hojas[r].UsedRange.Cells[rCnt, 2] = c1.Substring(0,c1.Length-2);
                        string c2 = cadenas[1].Trim();
                        hojas[r].UsedRange.Cells[rCnt, 4] = c2;
                    }
                    else
                    {
                        hojas[r].UsedRange.Cells[rCnt, 2] = "";
                        hojas[r].UsedRange.Cells[rCnt, 4] = g;
                    }
                    rCnt++;
                }
            }
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
