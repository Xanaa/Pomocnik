using System.Net;

namespace Pomocnik
{
    public class Obsluga_sieci
    {
        // Zwraca tekst ze strony na lini 0
        public static string Podaj_linie_zero(string strona)
        {
            string pobrana_strona = new WebClient().DownloadString(strona);
            string do_wyswietlenia = "Brak szukanej zawartości na stronie!";
            do_wyswietlenia = pobrana_strona;

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
