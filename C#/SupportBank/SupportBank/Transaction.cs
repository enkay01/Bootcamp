using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Transaction
    {
        public Account FromAccount { get; }
        public Account ToAccount { get; }
        public DateTime Date { get; }
        public string Narrative { get; }
        public decimal Amount { get; }
        public Transaction(DateTime date, Account source, Account dest, string reference, decimal value)
        {
            this.Date = date;
            this.FromAccount = source;
            this.ToAccount = dest;
            this.Amount = value;
            this.Narrative = reference;
        }
        
        

        public override string ToString()
        {
            return string.Format("Date: {0}, Destination: {1}, Reference: {2}, Value: £{3}", this.Date, this.ToAccount.GetName(),
                this.Narrative, this.Amount);
        }

    }
}
