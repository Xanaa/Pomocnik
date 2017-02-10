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

        // Zwraca obecny czas - godzina:minuta:sekunda
        public static string Podaj_czas()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
