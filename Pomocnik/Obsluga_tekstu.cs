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

        public static string[,] Polacz_tablice_2d_i_usun_duplikaty(string[,] tablica1, string[,] tablica2)
        {
            string[] tablica_scalona1 = new string[tablica1.GetLength(0)];
            string[] tablica_scalona2 = new string[tablica2.GetLength(0)];
            string[] tablica_scalona3 = new string[(tablica1.GetLength(0) + tablica2.GetLength(0))];
            int pomoc = 0;

            for (int a = 0; a < tablica1.GetLength(0); a++)
            {
                tablica_scalona1[a] = tablica1[a, 0] + "," + tablica1[a, 1];
            }
            for (int a = 0; a < tablica2.GetLength(0); a++)
            {
                tablica_scalona2[a] = tablica2[a, 0] + "," + tablica2[a, 1];
            }
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
            string[,] tablica_zwrotna = new string[tablica_scalona4.GetLength(0), 2];
            int pomoc1 = 0;
            foreach(string linia in tablica_scalona4)
            {
                string[] linijeczka = linia.Split(',');
                tablica_zwrotna[pomoc1, 0] = linijeczka[0];
                tablica_zwrotna[pomoc1, 1] = linijeczka[1];
                pomoc1++;
            }
            return tablica_zwrotna;
        }
    }
}
