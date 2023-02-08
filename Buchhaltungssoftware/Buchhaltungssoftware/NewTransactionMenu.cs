using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class NewTransactionMenu : Menu
    {
        // Wir lassen uns drei Werte vom User geben
        // Damit erstellen wir ein Obejkt von der Transaction class
        // Daruf rufen einen Methode aus der ProfileManager Klasse auf, welche das Obejkt in einer Liste speichert
        public override void DisplayMenu()
        {
            Console.WriteLine("Neue Transaction");
            Console.WriteLine("----------------");

            // Wir holen uns die Infos vom User
            string newTransactionName = InputTransactionName();
            decimal newTransactionAmount = InputTransactionAmount();
            DateTime TransactionDate = InputtransactionDate();

            // Wir erstellen ein Transaction objekt mit den entsprechenden daten
            Transaction transaction = new Transaction(newTransactionName, newTransactionAmount, TransactionDate);
            // wir fügen das Transactions Objekt der Transactions Liste im Profile hinzu
            ProfilManager.CurrentProfile.AddTransaction(transaction);
            Console.WriteLine("Die folgende Transaction wurde hinzugefügt");

            // Wenn der Amount negativ ist, wird die schrift rot
            if(transaction.Amount < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
            }
            // wenn der Amount positiv ist, wird die schrift grün
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
            }

            Console.WriteLine(transaction.ToString());
            Console.ResetColor();
            Console.ReadKey();
            
            Menu nextMenu = new MainMenu();
        }

        // Fragt den user nach einem Name 
        private string InputTransactionName()
        {
            Console.WriteLine("Transaction-Name: ");
            return Console.ReadLine();
        }
        // Fragt den user nach einem Betrag
        private decimal InputTransactionAmount()
        {
            decimal input;

            while(true)
            {
                Console.WriteLine("Euro-Betrag: ");
                bool correctInput = true;

                if(!decimal.TryParse(Console.ReadLine(), out input))
                {
                    correctInput = false;

                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiger Eurobetrag");
                    Console.ResetColor();
                }

                if(correctInput)
                {
                    break;
                }
            }

            return input;
        }
        // Fragt den user nach einem Datum
        private DateTime InputtransactionDate()
        {
            DateTime input;

            while(true)
            {
                Console.Write("Datum (TT.MM.JJJJ): ");
                bool correctInput = true;

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiges Datum");
                    Console.ResetColor();
                }

                if(correctInput)
                {
                    break;
                }
            }

            return input;
        }
    }
}
