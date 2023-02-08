using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class ShowTransactionsMenu : Menu
    {
        // wir holen uns die inputs vom user mit denen wir dan 
        // die transactionen zeigen können
        public override void DisplayMenu()
        {
            Console.WriteLine("Gebe den Zeitraum ein");
            Console.WriteLine("---------------------");

            DateTime startDate = InputStartDate();
            DateTime endDate = InputEndDate(startDate);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            PrintTransactionFromTo(startDate, endDate);
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("Drücke eine Taste um zum Haubpmenü zurückzukommen");
            Console.ReadKey();

            Menu next = new MainMenu();
        }

        // der user muss eine Start datum angeben
        private DateTime InputStartDate()
        {
            DateTime input;

            while (true)
            {
                bool correctInput = true;
                Console.Write("Startdatum (TT.MM.JJJJ): ");
                
                if(!DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("FEHLER: Ungültiges Startdatum");
                    Console.ResetColor();
                }

                if(correctInput)
                {
                    break;
                }
            }
            return input;
        }
        // der unser muss ein enddatum angeben
        private DateTime InputEndDate(DateTime startDate)
        {
            DateTime input;

            while (true)
            {
                bool correctInput = true;
                Console.Write("Enddatum (TT.MM.JJJJ): ");

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.mm.yyyy", null, System.Globalization.DateTimeStyles.None, out input) || input < startDate)
                {
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("FEHLER: Ungültiges Endtdatum");
                    Console.ResetColor();
                }

                if(correctInput) 
                {
                    break;
                }
            }
            return input;
        }
        // wir durchlaufen alle transactionen in der transactionen liste
        // wenn die aktuell durchlaufene transaction eine datum hat das größer als das startdatum ist
        // und das enddatum größer ist
        // als das datum muss zwischen start- und enddatum liegen
        // dann prüfen wir ob es ein negativer oder positiver betrag ist
        // uns dann zeigen wir all transactionen die diese Anforderungen erfüllen
        private void PrintTransactionFromTo(DateTime startDate, DateTime endDate)
        {
            foreach(Transaction transaction in ProfilManager.CurrentProfile.Transactions)
            {
                if(transaction.Date >= startDate && transaction.Date < endDate)
                {
                    if(transaction.Amount > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(transaction.ToString());
                    Console.ResetColor();
                }
            }
        }
    }
}
