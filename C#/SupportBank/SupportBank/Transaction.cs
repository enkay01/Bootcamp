using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Transaction
    {
        private Account destination;
        private DateTime date;
        private string reference;
        private decimal value;
        public Transaction(DateTime date, Account dest, string reference, decimal value)
        {
            this.date = date;
            this.destination = dest;
            this.value = value;
            this.reference = reference;
        }
        public Account GetDestination()
        {
            return this.destination;
        }
        public DateTime GetDate()
        {
            return this.date;
        }
        public string GetReference()
        {
            return this.reference;
        }
        public decimal GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return string.Format("Date: {0}, Destination: {1}, Reference: {2}, Value: £{3}", this.GetDate(), this.GetDestination().GetName(),
                this.GetReference(), this.GetValue());
        }
    }
}
