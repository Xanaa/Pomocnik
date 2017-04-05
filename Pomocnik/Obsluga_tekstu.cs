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
    }
}
