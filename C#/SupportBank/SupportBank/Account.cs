using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    class Account
    {
        private string name;
        private List<Transaction> transactions;
        public Account(string name)
        {
            this.name = name;
            transactions = new();
        }
        public void AddTransaction(Transaction t)
        {
            transactions.Add(t);
        }
        public List<Transaction> GetTransactions()
        {
            return this.transactions;
        }
        public string GetName()
        {
            return this.name;
        }
        public void PrintAllTransactions()
        {
            transactions.ForEach(e => Console.WriteLine(e.toString()));
            Console.WriteLine();
        }
        public decimal GetBalance()
        {
            return transactions.Sum(x => x.GetValue());
        }
        public string toString()
        {
            string status;
            decimal balance = GetBalance();
            if (balance > 0.0m)
                status = " is owed ";
            else
                status = " owes ";
            return string.Format("{0}{1}£{2}.", this.GetName(), status, balance);
        }
    }
}
