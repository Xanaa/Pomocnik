using System.IO;
using System.Linq;

namespace Pomocnik
{
    public class Obsluga_plikow
    {
        // Wczytaj plik (jest w postaci "cały plik" ==> "oddzielne linie"), tablica 2d
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
        }

        // Wczytaj wszystkie pliki w folderze jako tablica 2d
        public static string[,] Wczytaj_wszystkie_pliki_tekstowe(string sciezka, int ile_kolumn, string Komentarz_pomijany, string separator)
        {
            string[] lista = Podaj_liste_plikow_ze_sciezka(sciezka);
            string[] Wczytane_pliki = new string[Podaj_dlugosc_plikow_w_folderze(lista)];
            int a = 0;
            foreach (string linia in lista)
            {
                string[] temp1 = File.ReadAllLines(linia);

                for (int x = 0; x < temp1.GetLength(0); x++)
                {
                    Wczytane_pliki[a] = temp1[x];
                    a++;
                }
            }

            string[] Kolumnowo0 = Sprawdz_komentarze(Wczytane_pliki, Komentarz_pomijany);
            string[,] Kolumnowo = Podziel_na_kolumny(Kolumnowo0, ile_kolumn, separator);
            return Kolumnowo;
        }


        // Usuń komentarze (zaczyna się od "komentarz")
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
        }

        // Podziel tablicę 1d na 2d przez "Znak_separujacy"
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
        }

        // Wczytaj wszystkie pliki w folderze jako tablica 1d
        public static string[] Wczytaj_wszystkie_pliki(string sciezka0)
        {
            string[] lista = Podaj_liste_plikow_ze_sciezka(sciezka0);
            string[] Wczytane_pliki = new string[Podaj_dlugosc_plikow_w_folderze(lista) + (2* lista.GetLength(0))];
            int a = 0;
            foreach(string linia in lista)
            {
                string[] temp1 = File.ReadAllLines(linia);
                Wczytane_pliki[a] = Obsluga_tekstu.Znajdz_i_zamien(linia,sciezka0 + "\\","");
                a++;
                for(int x = 0; x < temp1.GetLength(0); x++)
                {
                    Wczytane_pliki[a] = temp1[x];
                    a++;
                }
                a++;
            }
            return Wczytane_pliki;
        }

        public static string[] Podziel_na_tablice_i_usun_duplikaty (string do_podzialu, string znak_separujacy1)
        {
            string[] Podzielone = do_podzialu.Split(znak_separujacy1.ToCharArray()[0]);
            return Podzielone.Distinct().ToArray();
        }

        // Lista plików w folderze, razem ze sciezką
        public static string[] Podaj_liste_plikow_ze_sciezka(string sciezka)
        {
            return Directory.GetFiles(sciezka);
        }

        // Podaj ile maja wszystkie pliki razem
        public static int Podaj_dlugosc_plikow_w_folderze(string[] lista_plikow0)
        {
            int dlugosc = 0;
            foreach(string linka in lista_plikow0)
            {
                string[] temp1 = File.ReadAllLines(linka);
                dlugosc += temp1.GetLength(0);
            }
            return dlugosc;
        }

        // Przeszukanie zakresu
        public static string[] Wycinanie_tekstu_z_tekstu(string[] caly_plik, int pierwsza_linia, int ostatnia_linia)
        {
            int dlugosc = ostatnia_linia - pierwsza_linia;
            string[] wycinek = new string[dlugosc];
            int linia_wycinka = 0;

            for(int a = pierwsza_linia; a < ostatnia_linia; a++)
            {
                wycinek[linia_wycinka] = caly_plik[a];
                linia_wycinka++;
            }
            
            return wycinek;
        }

        public static string[] Przytnij_obszar_wyszukiwania (string[] tekst_caly, string szukana_fraza, int Poziom)
        {
            int poziom_nawiasu = 0;
            int poczatek = 0;
            int koniec = 1;
            for(int a = 0; a < tekst_caly.GetLength(0); a++)
            {
                if (tekst_caly[a] != null)
                {
                    if (tekst_caly[a].Contains("{"))
                    {
                        if (tekst_caly[a].Contains(szukana_fraza + " = {") && poziom_nawiasu == Poziom)
                        {
                            poczatek = a;
                        }
                        poziom_nawiasu++;
                    }
                    if (tekst_caly[a].Contains("}"))
                    {
                        poziom_nawiasu--;
                        if (poziom_nawiasu == Poziom && poczatek != 0)
                        {
                            koniec = a +1;
                            break;
                        }
                    }
                }
            }

            return Wycinanie_tekstu_z_tekstu(tekst_caly, poczatek, koniec);
        }

        public static int Podaj_liczbe_elementow_tagu (string[] tekst, int poziom_nawiasu)
        {
            int poziom_nawiasow = poziom_nawiasu;
            int liczba_elementow = 0;
            foreach(string linia in tekst)
            {
                if(linia != null)
                {
                    if (linia.Contains("{"))
                    {
                        if (poziom_nawiasow == poziom_nawiasu)
                        {
                            liczba_elementow++;
                        }
                        poziom_nawiasow++;
                    }
                    if (linia.Contains("}"))
                    {
                        poziom_nawiasow--;
                    }
                }               
            }
            return liczba_elementow;
        }

        public static string[] Podaj_liste_tagow(string[] tekst)
        {
            string[] tagi = new string[Podaj_liczbe_elementow_tagu(tekst,0)];
            int poziom_nawiasow = 0;
            int liczba = 0;

            foreach (string linia in tekst)
            {
                if(linia != null)
                {
                    if (linia.Contains("{"))
                    {
                        if (poziom_nawiasow == 0)
                        {
                            tagi[liczba] = Obsluga_tekstu.Znajdz_i_zamien(linia, " = {", "");
                            liczba++;
                        }
                        poziom_nawiasow++;
                    }
                    if (linia.Contains("}"))
                    {
                        poziom_nawiasow--;
                    }
                }          
            }
            return tagi;
        }

        public static string[] Wytnij_przedzial_z_podtagu(string[] Zakres1, string Parametr1,int poziom1, string Parametr2, int poziom2)
        {
            string[] Linie1 = Obsluga_plikow.Przytnij_obszar_wyszukiwania(Zakres1, Parametr1, poziom1);

            return Obsluga_plikow.Przytnij_obszar_wyszukiwania(Linie1, Parametr2, poziom2);
        }

        public static string[,] Podaj_liste_z_zakresu(string[] Zakres)
        {
            int de = 0;
            string[] zwrot = new string[Zakres.GetLength(0) - 2];
            for (int i = 1; i < Zakres.GetLength(0) - 1; i++)
            {
                zwrot[de] = Obsluga_tekstu.Znajdz_i_zamien(Zakres[i], " = ", "=");
                de++;
            }
            return Obsluga_plikow.Podziel_na_kolumny(zwrot, 2, "=");
        }
    }
}
