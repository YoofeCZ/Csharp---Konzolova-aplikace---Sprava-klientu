//UzivatelskeRozhrani(Konstruktor):

//Funkce: Inicializuje správce osob(třída SpravceOsob) a připraví tak prostředí pro ukládání a správu pojištěnců.
//ZobrazitMenu:

//Funkce: Zobrazuje hlavní nabídku konzolové aplikace pro evidenci pojištěnců.
//Nabídka:
//Přidání nové pojištěné osoby.
//Výpis všech pojištěných osob.
//Vyhledání pojištěné osoby.
//Ukončení programu.
//Spustit:

//Funkce: Implementuje hlavní smyčku aplikace, která umožňuje uživateli volit mezi různými funkcemi dle hlavního menu.
//Volby:
//1: Přidání nové pojištěné osoby (volá PridatOsobu).
//2: Výpis všech pojištěných osob (volá SeznamVsechOsob).
//3: Vyhledání pojištěné osoby (volá NajitOsobu).
//4: Ukončení programu(nastaví proměnnou konec na true a použije Environment.Exit(0)).
//PridatOsobu:

//Funkce: Umožňuje uživateli přidat novou pojištěnou osobu.
//Proces:
//Získá vstup pro jméno, příjmení, věk a telefonní číslo pomocí validačních metod.
//Vytvoří novou instanci třídy Osoba.
//Přidá novou osobu do kolekce ve správci osob (SpravceOsob).
//SeznamVsechOsob:

//Funkce: Zobrazí seznam všech pojištěných osob.
//Proces:
//Získá všechny osoby ze správce (SpravceOsob).
//Pokud nejsou nalezeny žádné osoby, zobrazí informativní zprávu.
//Pokud jsou nalezeny, zobrazí každou osobu pomocí přetížené metody ToString.
//NajitOsobu:

//Funkce: Umožňuje uživateli vyhledat pojištěnou osobu podle jména a příjmení.
//Proces:
//Získá vstup pro jméno a příjmení.
//Hledá odpovídající osobu pomocí správce (SpravceOsob).
//Zobrazí výsledky hledání nebo informativní zprávu, pokud osoba není nalezena.
//ZiskatTextovyVstup:

//Funkce: Zajišťuje validovaný vstup pro jméno nebo příjmení.
//Validace:
//Zkontroluje, že text není prázdný a obsahuje pouze písmena.
//Vrací platný vstup.
//ZiskatVek:

//Funkce: Zajišťuje validovaný vstup věku jako nezáporného celého čísla.
//Validace:
//Pokud vstup není celé číslo nebo je záporné, zobrazuje varovnou zprávu.
//Vrací platnou hodnotu věku.
//ZiskatTelefonniCislo:

//Funkce: Zajišťuje validovaný vstup telefonního čísla s předvolbou +420.
//Validace:
//Kontroluje, zda je číslo formátováno podle regulárního výrazu (začíná +420 a má přesně 9 číslic).
//Vrací platné telefonní číslo.



using EvidencePojisteni;
using System.Text.RegularExpressions;

namespace EvidencePojisteni
{
    // Třída zodpovědná za komunikaci s uživatelem a správu hlavního rozhraní aplikace
    public class UzivatelskeRozhrani
    {
        // Správce osob, který poskytuje CRUD operace nad entitou 'Osoba'
        private readonly SpravceOsob spravce;

        // Regulární výrazy pro validaci vstupů
        // regulerniVyrazText ověřuje, že vstup obsahuje pouze písmena
        private readonly Regex regulerniVyrazText = new Regex(@"^[a-zA-Zá-žÁ-Ž]+$");

        // regulerniVyrazTelefon ověřuje, že telefonní číslo začíná +420 a má 9 číslic
        private readonly Regex regulerniVyrazTelefon = new Regex(@"^\+420[0-9]{9}$");

        // Konstruktor třídy, který inicializuje správce osob
        public UzivatelskeRozhrani()
        {
            spravce = new SpravceOsob();
        }

        // Zobrazení nabídky hlavního menu
        public void ZobrazitMenu()
        {
            Console.WriteLine("Systém pro správu pojištění");
            Console.WriteLine("1. Přidat pojištěnou osobu");
            Console.WriteLine("2. Seznam všech pojištěných osob");
            Console.WriteLine("3. Vyhledat pojištěnou osobu");
            Console.WriteLine("4. Konec");
            Console.WriteLine("Zadejte svou volbu:");
        }

        // Hlavní metoda pro spuštění programu
        public void Spustit()
        {
            bool konec = false; // Indikátor pro ukončení programu
            while (!konec)
            {
                ZobrazitMenu(); // Zobrazí hlavní menu
                string volba = Console.ReadLine(); // Získání uživatelské volby
                switch (volba)
                {
                    case "1":
                        PridatOsobu(); // Volba 1: Přidání nové pojištěné osoby
                        break;
                    case "2":
                        SeznamVsechOsob(); // Volba 2: Výpis všech pojištěných osob
                        break;
                    case "3":
                        NajitOsobu(); // Volba 3: Vyhledání pojištěné osoby
                        break;
                    case "4":
                        konec = true; // Volba 4: Ukončení programu
                        Console.WriteLine("Program bude ukončen.");
                        Environment.Exit(0); // Okamžité ukončení programu
                        break;
                    default:
                        Console.WriteLine("Neplatná volba. Zkuste to prosím znovu.");
                        break;
                }
            }
        }

        // Přidání nové pojištěné osoby
        private void PridatOsobu()
        {
            try
            {
                // Získání a validace jednotlivých atributů pojištěné osoby
                string jmeno = ZiskatTextovyVstup("jméno");
                string prijmeni = ZiskatTextovyVstup("příjmení");
                int vek = ZiskatVek();
                string telefonniCislo = ZiskatTelefonniCislo();

                // Vytvoření nového objektu pojištěné osoby
                Osoba pojistenec = new Osoba(jmeno, prijmeni, vek, telefonniCislo);

                // Přidání pojištěné osoby do spravce
                spravce.PridatOsobu(pojistenec);

                // Potvrzení o úspěšném přidání
                Console.WriteLine("Pojištěná osoba byla úspěšně přidána.");
            }
            catch (Exception ex)
            {
                // V případě chyby zobrazí chybovou zprávu
                Console.WriteLine($"Chyba: {ex.Message}");
            }
        }

        // Výpis všech pojištěných osob
        private void SeznamVsechOsob()
        {
            // Získání seznamu všech pojištěných osob ze správce
            List<Osoba> osoby = spravce.ZiskatVsechnyOsoby();

            // Pokud seznam neobsahuje žádné osoby, zobrazí informativní zprávu
            if (osoby.Count == 0)
            {
                Console.WriteLine("Žádné pojištěné osoby nenalezeny.");
            }
            else
            {
                // Výpis všech pojištěných osob pomocí metody ToString
                foreach (Osoba osoba in osoby)
                {
                    Console.WriteLine(osoba);
                }
            }
        }

        // Vyhledání pojištěné osoby podle jména a příjmení
        private void NajitOsobu()
        {
            // Získání jména a příjmení pro vyhledávání
            string jmeno = ZiskatTextovyVstup("jméno");
            string prijmeni = ZiskatTextovyVstup("příjmení");

            // Hledání pojištěné osoby ve správci osob
            Osoba osoba = spravce.NajitOsobu(jmeno, prijmeni);

            // Výpis výsledků hledání nebo zprávy o nenalezení
            if (osoba == null)
            {
                Console.WriteLine("Nebyla nalezena žádná pojištěná osoba s tímto jménem.");
            }
            else
            {
                Console.WriteLine(osoba);
            }
        }

        // Získání textového vstupu pro zadaný typ (jméno nebo příjmení)
        private string ZiskatTextovyVstup(string typ)
        {
            string vstup = "";
            // Smyčka pro opakované získávání vstupu, dokud není platný
            while (string.IsNullOrWhiteSpace(vstup) || !regulerniVyrazText.IsMatch(vstup))
            {
                Console.WriteLine($"Zadejte {typ}:");
                vstup = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(vstup) || !regulerniVyrazText.IsMatch(vstup))
                {
                    Console.WriteLine($"{typ} nesmí být prázdné a musí obsahovat pouze písmena.");
                }
            }
            return vstup; // Vrací platný textový vstup
        }

        // Získání a validace věku jako nezáporného celého čísla
        private int ZiskatVek()
        {
            int vek = -1; // Inicializace věku na neplatnou hodnotu
            while (vek < 0)
            {
                Console.WriteLine("Zadejte věk:");
                string vstup = Console.ReadLine();

                // Pokud vstup nelze převést na celé číslo nebo je věk záporný
                if (!int.TryParse(vstup, out vek) || vek < 0)
                {
                    Console.WriteLine("Věk musí být nezáporné celé číslo a nesmí obsahovat text.");
                    vek = -1; // Resetování věku na neplatnou hodnotu, aby smyčka pokračovala
                }
            }
            return vek; // Vrácení platné hodnoty věku
        }

        // Získání a validace telefonního čísla
        private string ZiskatTelefonniCislo()
        {
            string telefonniCislo = "";
            // Smyčka pro opakované získávání telefonního čísla, dokud není platné
            while (string.IsNullOrWhiteSpace(telefonniCislo) || !regulerniVyrazTelefon.IsMatch(telefonniCislo))
            {
                Console.WriteLine("Zadejte telefonní číslo (začíná +420 a obsahuje přesně 9 číslic):");
                telefonniCislo = Console.ReadLine();
                // Validace prázdného nebo nesprávně formátovaného čísla
                if (string.IsNullOrWhiteSpace(telefonniCislo) || !regulerniVyrazTelefon.IsMatch(telefonniCislo))
                {
                    Console.WriteLine("Telefonní číslo nesmí být prázdné a musí začínat +420 a obsahovat přesně 9 číslic.");
                }
            }
            return telefonniCislo; // Vrací platné telefonní číslo
        }
    }
}


