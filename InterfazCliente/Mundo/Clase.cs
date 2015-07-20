using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundo
{
    [Serializable]
    public class Clase
    {

        public const int LUNES = 0;
        public const int MARTES = 1;
        public const int MIERCOLES = 2;
        public const int JUEVES = 3;
        public const int VIERNES = 4;
        public const int SABADO = 5;
        public const int DOMINGO = 6;

        public string Dia { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }
        public int NumeroDia { get; set; }

        public static Dictionary<string, int> FullDayToInt;

        public static Dictionary<string, int> SubDayToInt;

        public static Dictionary<int, string[]> IntToDay;

        public string Salon { get; set; }

        public Clase(int numeroDia, int horaInicio, int horaFin, string salon)
        {
            this.NumeroDia = numeroDia;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.Dia = GetIntDiaToFullString(numeroDia);
            this.Salon = salon;
        }

        static Clase()
        {
            FullDayToInt = new Dictionary<string, int>(20);
            FullDayToInt.Add("Lunes", 0);
            FullDayToInt.Add("Martes", 1);
            FullDayToInt.Add("Miercoles", 2);
            FullDayToInt.Add("Jueves", 3);
            FullDayToInt.Add("Viernes!", 4);
            FullDayToInt.Add("Sabado", 5);
            FullDayToInt.Add("Domingo", 6);

            SubDayToInt = new Dictionary<string, int>(20);
            SubDayToInt.Add("LU", 0);
            SubDayToInt.Add("MA", 1);
            SubDayToInt.Add("MI", 2);
            SubDayToInt.Add("JU", 3);
            SubDayToInt.Add("VI", 4);
            SubDayToInt.Add("SA", 5);
            SubDayToInt.Add("DO", 6);

            IntToDay = new Dictionary<int, string[]>(20);
            IntToDay.Add(0, new string[] { "LU", "Lunes" });
            IntToDay.Add(1, new string[] { "MA", "Martes" });
            IntToDay.Add(2, new string[] { "MI", "Miercoles" });
            IntToDay.Add(3, new string[] { "JU", "Jueves" });
            IntToDay.Add(4, new string[] { "VI", "Viernes" });
            IntToDay.Add(5, new string[] { "SA", "Sabado" });
            IntToDay.Add(6, new string[] { "DO", "Domingo" });
        }

        public static string GetIntDiaToFullString(int dia)
        {
            return IntToDay[dia][1];
        }

        public static string GetIntDiaToSubString(int dia)
        {
            return IntToDay[dia][0];
        }

        public static int GetDiaFullStringToInt(string dia)
        {
            return FullDayToInt[dia];
        }
        public static int GetDiaSubStringToInt(string dia)
        {
            return SubDayToInt[dia];
        }
        public bool cruzaClase(Clase c)
        {
            return (c.Dia == Dia) ? cruzanHoras(HoraInicio, HoraFin, c.HoraInicio, c.HoraFin) : false;
        }

        public static bool cruzanHoras(int Inicio1, int fin1, int Inicio2, int fin2)
        {
            if (Inicio2 < Inicio1 && Inicio1 < fin2)
                return true;
            if (Inicio2 < fin1 && fin1 < fin2)
                return true;
            if (Inicio1 < Inicio2 && Inicio2 < fin1)
                return true;
            if (Inicio1 < fin2 && fin2 < fin1)
                return true;
            if (Inicio1 == Inicio2 && fin1 == fin2)
                return true;
            return false;
        }

        public static bool verificarHora(string hora)
        {
            if (hora.Length >= 4 && hora.Length <= 5 && hora.Contains(':'))
            {
                int inicio = 0;
                int fin = 0;
                string[] data = hora.Split(':');
                int.TryParse(data[0], out inicio);
                int.TryParse(data[1], out fin);
                if (data.Length == 2 && inicio > 0 && inicio <= 24 && fin >= 0 && fin <= 60)
                    return true;
            }
            return false;
        }

        public static bool verificarHoras(string hora1, string hora2)
        {
            if (verificarHora(hora1) && verificarHora(hora2))
            {
                int ini = Convert.ToInt32(hora1.Replace(":",""));
                int fini = Convert.ToInt32(hora2.Replace(":",""));
                if (ini >= 0 && fini <= 2400 && ini < fini)
                    return true;
            }
            return false;
        }

        public static string formatHora(int hora)
        {
            string h = hora + "";
            return (h.Length == 3) ? h[0] + ":" + h.Substring(1, 2) : h.Substring(0, 2) + ":" + h.Substring(2, 2);
        }

        public override string ToString()
        {
            return Dia.Substring(0, 2) + " " + formatHora(HoraInicio) + " - " + formatHora(HoraFin) + " / " + Salon;
        }
    }
}
