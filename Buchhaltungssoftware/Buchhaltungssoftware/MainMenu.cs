using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class MainMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil: " + ProfilManager.CurrentProfile.Name);
            Console.WriteLine("Aktueller Kontostand: " + ProfilManager.CurrentProfile.Balance + "Euro ");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("[1] Neue Transaction");
            Console.WriteLine("[2] Zeige Transactionen");
            Console.WriteLine("[3] Zurück ins Startmenü");

            InputOption();
        }

        private void InputOption()
        {
            string input;

            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine();
                bool correctInput = true;
                Menu nextMenu;

                switch (input)
                {
                    case "1":
                        nextMenu = new NewTransactionMenu();
                        break;
                    case "2":
                        nextMenu = new ShowTransactionsMenu();
                        break;
                    case "3":
                        nextMenu = new StartMenu();
                        break;
                    default:
                        correctInput = false;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Üngültige Eingabe!");
                        Console.ResetColor();
                        break;
                }

                if(correctInput)
                {
                    break;
                }
            }
        }
    }
}
