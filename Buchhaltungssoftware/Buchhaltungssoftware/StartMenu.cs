using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class StartMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Willkommen zu Buchaltungs-Software!");
            Console.WriteLine();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("--------------------");
            Console.WriteLine("[1] Neues Profil erstellen");
            Console.WriteLine("[2] Profil laden");
            Console.WriteLine();

            InputOption();
        }

        private void InputOption() 
        {
            string input;
            Menu nextMenu;

            while (true)
            {
                Console.WriteLine("Eingabe: ");
                input = Console.ReadLine();

                bool correctInput = true;

                switch (input)
                {
                    case "1":
                        nextMenu = new CreateProfileMenu();
                        break;
                    case "2":
                        nextMenu = new LoadProfileMenu();
                        break;
                    default:
                        correctInput= false;

                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Ungültige Eingabe!");
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
