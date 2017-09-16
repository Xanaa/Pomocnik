using System;
using System.Threading;

namespace Pomocnik
{
    public class Obsluga_czasu
    {
        // Uśpienie programu na x sekund
        public static bool Uspij(int sekundy)
        {
            Thread.Sleep(sekundy * 1000); // Thread.Sleep(X) <--- czekaj Xms, więc 1000ms=1s
            return true;
        }

        // Zwraca obecny czas
        public static string Podaj_date_i_czas(int tryb, string odd1, string odd2, string odd3, string odd4, string odd5)
        {
            string do_wyslania = "";
            switch (tryb)
            {
                case 0:
                    do_wyslania = DateTime.Now.ToString("yyyy" + odd1 + "MM" + odd2 + "dd" + odd3 + "HH" + odd4 + "mm" + odd5 + "ss");
                    break;
                case 1:
                    do_wyslania = DateTime.Now.ToString("yyyy" + odd1 + "MM" + odd2 + "dd");
                    break;
                case 2:
                    do_wyslania = DateTime.Now.ToString("HH" + odd1 + "mm" + odd2 + "ss");
                    break;
            }
            return do_wyslania;
        }

        // Zwraca czas zwykły z poskładanego
        public static string[] Podaj_date_rozdzielnie (int tryb, string data)
        {
            string[] czas = new string[3];
            switch (tryb)
            {
                case 0: // dla stylu 01.01.1995
                    czas[0] = data[0].ToString() + data[1].ToString(); // dzień
                    czas[1] = data[3].ToString() + data[4].ToString(); // miesiąc
                    czas[2] = data[6].ToString() + data[7].ToString() + data[8].ToString() + data[9].ToString(); // rok
                    break;
            }

            return czas;
        }
    }
}
