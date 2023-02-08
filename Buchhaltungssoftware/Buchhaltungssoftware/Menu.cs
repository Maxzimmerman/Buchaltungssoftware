using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    abstract class Menu
    {
        public Menu() 
        { 
            Console.Clear();
            DisplayMenu();
        }
        public abstract void DisplayMenu();
    }
}
