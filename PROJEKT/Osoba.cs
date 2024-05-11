//Přehled funkcí:
//Osoba(Konstruktor):

//Inicializuje a validuje atributy Jmeno, Prijmeni, Vek a Telefon.
//Vyvolá výjimku ArgumentException, pokud jsou Jmeno nebo Prijmeni prázdné nebo pokud je Vek záporný.
//Vlastnosti (Jmeno, Prijmeni, Vek, Telefon):

//Poskytují přístup k atributům objektu Osoba.
//ToString:

//Vrací reprezentaci objektu Osoba jako textový řetězec.

using System;

namespace EvidencePojisteni
{
    // Třída Osoba reprezentuje pojištěnou osobu s informacemi jako jméno, příjmení, věk a telefon
    public class Osoba
    {
        // Veřejné vlastnosti uchovávající informace o pojištěné osobě
        // Jméno osoby
        public string Jmeno { get; set; }

        // Příjmení osoby
        public string Prijmeni { get; set; }

        // Věk osoby (jako celé číslo)
        public int Vek { get; set; }

        // Telefonní číslo osoby (jako textový řetězec)
        public string Telefon { get; set; }

        // Konstruktor třídy inicializuje všechny atributy pojištěné osoby
        // a zároveň provádí validaci vstupů
        public Osoba(string jmeno, string prijmeni, int vek, string telefon)
        {
            // Validace jména a příjmení: nesmí být prázdné nebo obsahovat pouze bílé znaky
            if (string.IsNullOrWhiteSpace(jmeno) || string.IsNullOrWhiteSpace(prijmeni))
            {
                throw new ArgumentException("Jméno a příjmení nesmí být prázdné.");
            }

            // Validace věku: nesmí být záporný
            if (vek < 0)
            {
                throw new ArgumentException("Věk nemůže být záporný.");
            }

            // Nastavení vlastností třídy
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            Telefon = telefon;
        }

        // Přetížená metoda ToString poskytuje textovou reprezentaci objektu Osoba
        public override string ToString()
        {
            return $"{Jmeno} {Prijmeni}, Věk: {Vek}, Telefon: {Telefon}";
        }
    }
}
