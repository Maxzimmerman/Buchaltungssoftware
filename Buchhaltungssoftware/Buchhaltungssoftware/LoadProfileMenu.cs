using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Buchhaltungssoftware
{
    class LoadProfileMenu : Menu
    {
        // Der user soll ein profil auswählen dazu kriegen wir einen namen aus InputProfilName
        // Wenn der string aus InputProfileName nicht cancel ist dann wird das profile aus 
        // dem ProfileManager geladen
        public override void DisplayMenu()
        {
            Console.WriteLine("Wähle ein Profil aus:");
            Console.WriteLine("---------------------");
            ShowProfiles();
            Console.WriteLine();
            string profilePath = InputProfileName();

            if(profilePath != "cancel")
            {
                ProfilManager.LoadProfile(profilePath);
                Menu nextMenu = new MainMenu();
            }
            else
            {
                Menu nextMenu = new StartMenu();
            }
        }

        // Dem user werden die Profile mit dem Namen angezeigt
        private void ShowProfiles()
        {
            // Wir erstellen ein array mit den namen der dateien, die auf .prof enden
            string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");

            foreach (string file in profileFiles)
            {
                Console.WriteLine("- " + Path.GetFileName(file));
            }
        }
        // 1. Wenn der user cancel eingibt wird aus der while loop gesprungen
        // 2. Wenn nicht durchlaufen wir alle dateien mit dem entsprechenden namen
        // 3. Wenn der aktuell durchlaufene Name dem input entspricht wird die datei im input gespeichert
        // 4. Wenn correct input true ist wird aus der while loop gesprungen
        // 5. Wenn nicht wird dem user ein Feheler angezeigt und er kann weiter machen
        // 6. Dann wird der input returnt, welcher dann von der LoadProfileMethode verwendet wird, um die Datei zu laden
        private string InputProfileName()
        {
            string input = "";

            while(true)
            {
                Console.Write("Zu ladendes Profil [\"cancel\" zum abbrechen]: ");
                input = Console.ReadLine();
                string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");
                bool correctInput = false;

                if(input == "cancel")
                {
                    correctInput= true;
                }
                else
                {
                    for(int i = 0; i < profileFiles.Length; i++)
                    {
                        profileFiles[i] = Path.GetFileName(profileFiles[i]);

                        if(input == profileFiles[i])
                        {
                            correctInput = true;
                            input = AppContext.BaseDirectory + input;
                            break;
                        }
                    }
                }

                if(correctInput)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültiges Profil!");
                    Console.ResetColor();
                }
            }

            return input;
        }
    }
}
