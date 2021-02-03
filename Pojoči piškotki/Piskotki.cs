using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pojoči_piškotki
{
    public class Piskotki
    {
        public static int Trenutni_glasek { get; set; }

        public static Random Nakljucni_glasek = new Random();

        public static int Sedajsnji_glas { get; set; }

        public static int Moj_Glas { get; set; }

        public static int stevec = 3, stopnja = 0;

        private static int index = 0;

        public static List<int> Stevilke = new List<int>()
        {
            1, 2, 3, 4
        };

        public static List<int> Serija_glasov = new List<int>();

        public static int Vrni_Trenutno_Stevilko_Glas()
        {
            Sedajsnji_glas = Nakljucni_glasek.Next(Stevilke.Count);

            return Stevilke[Sedajsnji_glas];
        }

        public static void Polni_glasove()
        {
            for (int indeks = 0; indeks < stevec; indeks++)
            {
                Serija_glasov.Add(Nakljucni_glasek.Next(1, 4));
            }
        }

        public static bool Preveri()
        {
            if (Serija_glasov[index] == Moj_Glas)
            {
                index++;
            }

            if (index == Serija_glasov.Count - 1)
            {
                stevec++;

                index = 0;

                return true;
            }

            else
            {
                index = 0;

                return false;
            }
        }
    }
}
