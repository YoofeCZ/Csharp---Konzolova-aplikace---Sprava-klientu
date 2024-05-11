# ZÁKLADNÍ PROJEKT C# - MRAČEK DOMINIK
Třída: UzivatelskeRozhrani Konstruktor:

UzivatelskeRozhrani(): Inicializuje instance SpravceOsob pro správu seznamu pojištěných osob. Metody:

ZobrazitMenu(): Zobrazuje hlavní menu aplikace s výběrem funkcí pro uživatele. Spustit(): Spouští hlavní smyčku programu, umožňuje uživateli volit akce z menu. PridatOsobu(): Umožňuje uživateli přidat novou pojištěnou osobu do systému. SeznamVsechOsob(): Zobrazuje seznam všech pojištěných osob uložených v systému. NajitOsobu(): Umožňuje uživateli vyhledat osobu podle jména a příjmení. ZiskatTextovyVstup(string typ): Zajišťuje validaci a získání vstupu pro textová pole jako jméno a příjmení. ZiskatVek(): Zajišťuje validaci a získání věku jako kladného celého čísla. ZiskatTelefonniCislo(): Zajišťuje validaci a získání telefonního čísla splňujícího formát.

Třída: SpravceOsob Konstruktor:

SpravceOsob(): Inicializuje seznam osob pro ukládání a správu pojištěných osob. Metody:

PridatOsobu(Osoba osoba): Přidává novou osobu do seznamu pojištěných osob. ZiskatVsechnyOsoby(): Vrací seznam všech zaregistrovaných pojištěných osob. NajitOsobu(string jmeno, string prijmeni): Hledá osobu v seznamu podle jména a příjmení a vrací odpovídající objekt Osoba.

Třída: Osoba Atributy:

Jmeno: Uchovává jméno osoby. Prijmeni: Uchovává příjmení osoby. Vek: Uchovává věk osoby. Telefon: Uchovává telefonní číslo osoby. Konstruktor:

Osoba(string jmeno, string prijmeni, int vek, string telefon): Inicializuje objekt Osoba s danými hodnotami. Metody:

ToString(): Přetížená metoda pro výpis informací o osobě ve formátovaném řetězci.
