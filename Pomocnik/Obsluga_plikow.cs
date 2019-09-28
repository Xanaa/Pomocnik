using System.IO;
using System.Linq;

namespace Pomocnik
{
    public class Obsluga_plikow
    {     
        public static string[,] Wczytaj_plik_tekstowy(string sciezka, string plik, int ile_kolumn, string Komentarz_pomijany, string separator)
        {
            string plik_calosc = sciezka + plik;

            if (File.Exists(plik_calosc) == true)
            {
                string[] temp1 = Sprawdz_komentarze(File.ReadAllLines(plik_calosc), Komentarz_pomijany);
                string[,] gotowy = Podziel_na_kolumny(temp1, ile_kolumn, separator);
                return gotowy;
            }
            else
            {
                return null;
            }
        } // Wczytaj plik (jest w postaci "cały plik" ==> "oddzielne linie"), tablica 2d

        public static string[] Sprawdz_komentarze(string[] plik, string komentarz)
        {
            // Jeśli linia zaczyna się od "komentarz", pomiń
            int krzak_linie = 0;
            int nowe_linie = 0;

            foreach (string wiersz in plik)
            {
                if (wiersz.StartsWith(komentarz)) // Najpierw sprawdź czy zaczyna się od "#"
                {
                    krzak_linie++;
                }
            }

            string[] zastepczy = new string[(plik.Length - krzak_linie)];

            foreach (string wiersz in plik)
            {
                if (wiersz.StartsWith(komentarz) == false)
                {
                    zastepczy[nowe_linie] = wiersz;
                    nowe_linie++;
                }
            }
            return zastepczy;
        } // Usuń komentarze (zaczyna się od "komentarz")
       
        public static string[,] Podziel_na_kolumny(string[] plik, int liczba_kolumn, string Znak_separujacy)
        {
            string[,] podzielony_plik = new string[plik.Length, liczba_kolumn];
            char sep_temp = Znak_separujacy.ToCharArray()[0];
            int temp = 0;

            foreach (string wiersz in plik)
            {
                string[] temp2 = wiersz.Split(sep_temp);
                for (int i = 0; i < liczba_kolumn; i++)
                {
                    podzielony_plik[temp, i] = temp2[i];
                }
                temp++;
            }
            return podzielony_plik;
        } // Podziel tablicę 1d na 2d przez "Znak_separujacy"

    }
}
