using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Buchhaltungssoftware
{
    static class ProfilManager
    {
        // Wir brauchen eine Eigenschaft aus der Profile class
        public static Profile CurrentProfile { get; private set; }

        public static void CreateProfile(string name, decimal balance)
        {
            // Hier erstellen wir ein Profile objekt und speichern es als eine datei ab
            CurrentProfile = new Profile(name, balance);
            SaveProfile(CurrentProfile);
        }

        public static void SaveProfile(Profile profile)
        {
            // Hier legen wir fest wie die datei heisen soll
            string filePath = AppContext.BaseDirectory + profile.Name + ".prof";
            // dann müssen wir ein objekt von BinaryFormatter erstellen
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                // dann erstellen wir einen filestream über den die daten gespeichert werden
                using(FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    // dann speichern wir es final
                    binaryFormatter.Serialize(stream, profile);
                }
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void LoadProfile(string profilepath)
        {
            // Wir erstellen wieder ein BinaryFormatter objekt
            BinaryFormatter binaryFormatter= new BinaryFormatter();

            try
            {
                // Dann benutzen wieder ein Filestream, der wir den filepath übergeben müssen
                using(FileStream stream = new FileStream(profilepath, FileMode.Open))
                {
                    // Dann können wir das gewünschte objekt deserializieren
                    CurrentProfile = (Profile)binaryFormatter.Deserialize(stream);
                }
            }
            catch(Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        // hier checken wir ob bereits eine datei mit einem solchen namen existiert
        public static bool CheckIfProfileExists(string profileName)
        {
            string fullPath = AppContext.BaseDirectory + profileName + ".prof";
            return File.Exists(fullPath);
        }
    }
}