using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBank
{
    static class FileReader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static string [] ReadFile(string path ,bool skipHeader)
        {
            Logger.Info("Attempting to read file");
            string [] data = null;
            try
            {
                data = File.ReadAllLines(path);
                if (skipHeader)
                    data = data.Skip(1).ToArray();
            }
            catch (FileNotFoundException e)
            {
                Logger.Error("Unable to read data from file. Exception caught was:\n{0}", e.Message);
                return new string[1];
            }
            
            return data;
        }
        public static Dictionary<string, Account> BuildAccountDict(string [] data)
        {
            Dictionary<string, Account> accounts = new();
            int count = 1;
            foreach (string s in data)
            {
                Logger.Info("Attempting to split line {0}", count);
                string[] field = s.Trim().Split(",");
                Logger.Info("Adding fields to objects");
                if (IsValidDate(field[0], count))
                {
                    if (IsValidDecimal(field[4], count))
                    {
                        if (!accounts.TryAdd(field[1], new Account(field[1])))
                            Logger.Debug("Account {0} already added, continuing", field[1]);
                        if (!accounts.TryAdd(field[2], new Account(field[2])))
                            Logger.Debug("Account {0} already added, continuing", field[2]);

                        Logger.Debug("Parsing transaction between {0} and {1}", field[1], field[2]);
                        DateTime date = DateTime.Parse(field[0]);
                        decimal value = Decimal.Parse(field[4]);
                        Transaction t = new(date, accounts[field[1]], accounts[field[2]], field[3], value);
                        accounts[field[1]].AddTransaction(t);
                        accounts[field[1]].DebitAccount(t.Amount);
                        accounts[field[2]].CreditAccount(t.Amount);
                    }
                    else
                    {
                        Logger.Warn("Invalid monetary value entered {0}", field[4]);
                    }
                }
                else
                {
                    Logger.Warn("Invalid date value entered {0}", field[0]);
                }

            }
            return accounts;
        }
        public static bool IsValidDecimal(string s, int count)
        {
            try
            {
                Decimal.Parse(s);
            }catch(FormatException)
            {
                Logger.Warn("Invalid input on line {0} of file: Value is not in correct format", count);
                return false;
            }
            return true;
        }
        public static bool IsValidDate(string s, int count)
        {
            try
            {
                DateTime.Parse(s);
            }catch(FormatException)
            {
                Logger.Warn("Invalid input on line {0} of file: Date is not in correct format", count);
                return false;
            }

            return true;
        }
    }
    
}
