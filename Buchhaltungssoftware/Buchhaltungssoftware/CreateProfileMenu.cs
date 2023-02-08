using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class CreateProfileMenu : Menu
    {
        // wenn der user einen namen und eine balance angibt dann wird ein neues profile erstellt
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil erstellen");
            Console.WriteLine();

            string profileName = InputName();
            decimal profileStartBalance = InputStartBalance();

            ProfilManager.CreateProfile(profileName, profileStartBalance);

            Menu nextMenu = new MainMenu();
        }
        // wenn der user soll einen namen vergeben
        private string InputName()
        {
            while (true)
            {
                string input = "";

                Console.Write("Profilname: ");
                input = Console.ReadLine();

                if (ValidateName(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: ungültiger Name");
                    Console.ResetColor();
                }
            }
        }
        // Wir wenden die checkifprofilexists methode auf den namen an und prüfen damit ob der namen bereits existiert
        // hier wird der name auf seine richtigkeit geprüft
        private bool ValidateName(string name)
        {
            if (ProfilManager.CheckIfProfileExists(name))
            {
                return false;
            }
            foreach(char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private decimal InputStartBalance()
        {
            while(true)
            {
                Console.Write("Start Kontostand: ");
                decimal input;
                string stringInput = Console.ReadLine();

                if(!decimal.TryParse(stringInput, out input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiger Geldbetrag");
                    Console.ResetColor();
                    continue;
                }

                return input;
            }
        }
    }
}