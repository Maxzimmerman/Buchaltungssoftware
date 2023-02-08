using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    [Serializable]
    class Profile
    {
        // ein profil hat einen namen einen höchstwert und eine liste aus transactionen
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Profile(string name, decimal balance) 
        {
            Name = name;
            Balance = balance;
            Transactions = new List<Transaction>();
        }

        // Hier wird ein Objekt aus der Transactions class in die Liste aus Transaction hinzugefügt
        // Und der Geldbetrag wird auf das konto des user dazu addiert
        // Das wird die Transaction noch abgespeichert
        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
            Balance += transaction.Amount;
            ProfilManager.SaveProfile(this);
        }
    }
}
