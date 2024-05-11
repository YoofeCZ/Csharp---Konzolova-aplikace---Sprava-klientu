//Přehled funkcí:
//SpravceOsob:
//Konstruktor: Inicializuje prázdnou kolekci osoby.
//PridatOsobu:
//Přidá novou instanci Osoba do seznamu osoby.
//ZiskatVsechnyOsoby:
//Vytváří a vrací novou kopii kolekce osoby.
//NajitOsobu:
//Hledá první osobu s odpovídajícím jménem a příjmením v kolekci.


using System;
using System.Collections.Generic;
using System.Linq;

namespace EvidencePojisteni
{
    // Třída SpravceOsob zodpovídá za správu a uchovávání seznamu osob (pojištěnců)
    public class SpravceOsob
    {
        // Soukromá kolekce osob uchovává všechny pojištěnce v paměti
        private List<Osoba> osoby;

        // Konstruktor třídy SpravceOsob inicializuje prázdnou kolekci osob
        public SpravceOsob()
        {
            osoby = new List<Osoba>();
        }

        // Přidá novou pojištěnou osobu do kolekce
        public void PridatOsobu(Osoba osoba)
        {
            osoby.Add(osoba);
        }

        // Vrací kopii seznamu všech osob v kolekci
        // Vrácení kopie zabraňuje přímé manipulaci s původní kolekcí
        public List<Osoba> ZiskatVsechnyOsoby()
        {
            return new List<Osoba>(osoby);
        }

        // Hledá první osobu v seznamu podle zadaného jména a příjmení
        // Porovnávání probíhá bez ohledu na velikost písmen (OrdinalIgnoreCase)
        public Osoba NajitOsobu(string jmeno, string prijmeni)
        {
            return osoby.FirstOrDefault(o => o.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase) &&
                                             o.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase));
        }
    }
}


