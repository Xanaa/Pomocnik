using System.Linq;

namespace Pomocnik
{
    public class Obsluga_tekstu
    {
        // Znajdz w "tekst" i zamień "szukany" na "zamiennik"
        public static string Znajdz_i_zamien(string tekst, string szukany, string zamiennik)
        {
            if (tekst.Contains(szukany))
            {
                tekst = tekst.Replace(szukany, zamiennik);
            }
            return tekst;
        }

        // Tablice muszą być tej samej długości Y
        public static string[,] Polacz_tablice_2d_i_usun_duplikaty(string[,] tablica1, string[,] tablica2, string Separator0)
        {
            string[] tablica_scalona1 = new string[tablica1.GetLength(0)];
            string[] tablica_scalona2 = new string[tablica2.GetLength(0)];
            string[] tablica_scalona3 = new string[(tablica1.GetLength(0) + tablica2.GetLength(0))];
            int pomoc = 0;

            tablica_scalona1 = Scal_tablice_2d_do_1d(tablica1, Separator0);
            tablica_scalona2 = Scal_tablice_2d_do_1d(tablica2, Separator0);

            for (int a = 0; a < tablica1.GetLength(0); a++)
            {
                tablica_scalona3[a] = tablica_scalona1[a];
                pomoc++;
            }
            for (int a = pomoc; a < tablica2.GetLength(0) + pomoc; a++)
            {
                tablica_scalona3[a] = tablica_scalona2[a - pomoc];
            }
            string[] tablica_scalona4 = tablica_scalona3.Distinct().ToArray();
            string[,] tablica_zwrotna = Podziel_tablice_1d_na_2d(tablica_scalona4, Separator0);
            return tablica_zwrotna;
        }

        public static string[] Scal_tablice_2d_do_1d (string[,] tablica, string separator)
        {
            int ilosc_wierszy = tablica.GetLength(0);
            int ilosc_kolumn = tablica.GetLength(1);

            string[] zwrot = new string[ilosc_wierszy];

            for(int a = 0; a < ilosc_wierszy; a++)
            {
                for (int b = 0; b < ilosc_kolumn; b++)
                {
                    zwrot[a] += tablica[a, b] + separator;
                }
                zwrot[a] = zwrot[a].Remove(zwrot[a].Length - 1, 1);
            }

            return zwrot;
        }

        public static string[,] Podziel_tablice_1d_na_2d (string[] tablica_do_podzialu, string Separator1)
        {
            int liczba_wierszy = tablica_do_podzialu.GetLength(0);
            string[] test = tablica_do_podzialu[0].Split(Separator1[0]);
            int liczba_kolumn = test.GetLength(0);
            string[,] zwrot = new string[liczba_wierszy, liczba_kolumn];
            for (int a = 0; a < liczba_wierszy; a++)
            {
                string[] tymczasowe = tablica_do_podzialu[a].Split(Separator1[0]);
                for (int b = 0; b < liczba_kolumn; b++)
                {
                    zwrot[a, b] = tymczasowe[b];
                }
            }
            return zwrot;
        }

        public static bool Czy_tablica_zawiera_liczbe(int[] tablica_intow,int liczba)
        {
            bool tak_czy_nie = false;
            for(int a = 0; a < tablica_intow.GetLength(0); a++)
            {
                if(tablica_intow[a] == liczba)
                {
                    tak_czy_nie = true;
                    break;
                }
            }
            return tak_czy_nie;
        }

        public static bool Czy_to_duplikat (bool[] tablica, int[] kolumny01)
        {
            int ile_sprawdzanych = kolumny01.GetLength(0);
            int ile_jest_tych_samych = 0;

            for (int b = 0; b < kolumny01.GetLength(0); b++)
            {
                if(tablica[kolumny01[b]] == true)
                {
                    ile_jest_tych_samych++;
                }
            }
            if (ile_sprawdzanych == ile_jest_tych_samych)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string[,] Usun_wiersze_z_tablicy_2d (string[,] tablica_operacji, int[] numery_wiersza_do_usuniecia, string Separator5)
        {
            string[] Tablica_scalona = Scal_tablice_2d_do_1d(tablica_operacji, Separator5);
            int ilosc_nowych_wierszy = Tablica_scalona.GetLength(0) - numery_wiersza_do_usuniecia.GetLength(0);
            string[] nowa_tablica = new string[ilosc_nowych_wierszy];
            int pomoc = 0;

            for(int a = 0; a < Tablica_scalona.GetLength(0); a++)
            {
                if(Czy_tablica_zawiera_liczbe(numery_wiersza_do_usuniecia,a) == false)
                {
                    nowa_tablica[pomoc] = Tablica_scalona[a];
                    pomoc++;
                }
            }

            return Podziel_tablice_1d_na_2d(nowa_tablica, Separator5);
        }

    }
}
