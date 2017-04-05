using System.Net;

namespace Pomocnik
{
    public class Obsluga_sieci
    {
        // Wyszukaj linie, która zawiera "szukane1" pod adresem "strona" i usuń z tej linii "szukane1" i "szukane2"
        public static string Wyszukaj_na_stronie(string strona, string szukane1, string szukane2)
        {
            string pobrana_strona = new WebClient().DownloadString(strona);
            string do_wyswietlenia = "Brak szukanej zawartości na stronie!";
            string[] przerobiona_strona = pobrana_strona.Split('\n');

            foreach (string linia in przerobiona_strona)
            {
                if (linia.Contains(szukane1))
                {
                    do_wyswietlenia = linia.Replace(szukane1, "");
                    do_wyswietlenia = do_wyswietlenia.Replace(szukane2, "");
                    break;
                }
            }
            return do_wyswietlenia;
        }

        // Sprawdź czy można połączyć z internetem
        public static bool Sprawdz_polaczenie_z_internetem()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
