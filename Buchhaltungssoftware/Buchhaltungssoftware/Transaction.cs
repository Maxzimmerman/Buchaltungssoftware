using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Buchhaltungssoftware
{
    [Serializable]
    class Transaction
    {
        // der user soll bei der erstellung einer neuen transaction einen name, einen betrag und das datum angeben
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string name, decimal amount, DateTime date) 
        {
            Name = name;
            Amount = amount;
            Date = date;
        }

        // so soll dem benutzer dann die transaction angezeigt werden
        public override string ToString()
        {
            return "Name: " + Name + " | Datum: " + Date.ToShortDateString() + " | Betrag: " + Amount + " Euro";
        }
    }
}
