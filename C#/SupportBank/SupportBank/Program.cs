using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SupportBank
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] data = File.ReadAllLines("C:\\Users\\Ian.Nkwocha\\OneDrive\\Documents\\Development\\Training\\Bootcamp\\C#\\SupportBank\\SupportBank\\Transactions2014.csv");
            data = data.Skip(1).ToArray();
            Dictionary<string, Account> accounts = new();
            
            foreach (string s in data){
                string[] field = s.Trim().Split(",");
                accounts.TryAdd(field[1], new Account(field[1]));
                
                accounts.TryAdd(field[2], new Account(field[2]));


                accounts[field[1]].AddTransaction(new Transaction(
                                                           field[0],
                                                           accounts[field[2]],
                                                           field[3],
                                                           Decimal.Parse(field[4])
                                                           ));
            }


            Console.WriteLine("Welcome to the accounts viewier");
            while (true)
            {
                string ListAll = "LIST ALL";
                string ListOne = "LIST ONE";

                Console.WriteLine("Enter a command:" +
                    "\n1)List All\n2)List One");
                string choice = Console.ReadLine().ToUpper();

                if (choice.Equals(ListOne))
                {
                    Account acc;
                    string name = PromptName();
                    if(accounts.TryGetValue(name, out acc))
                    {
                        acc.PrintAllTransactions();
                    }
                    else
                    {
                        Console.WriteLine("An account with that name cannot be found.");
                    }
                    
                }
                else if (choice.Equals(ListAll))
                {
                    foreach(KeyValuePair<string, Account> kp in accounts)
                    {
                        Console.WriteLine(kp.Value.toString());
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Please choose one of the two above options.");
                }
            }
            static string PromptName()
            {
                Console.WriteLine("Enter a name:");
                return Console.ReadLine();
            }
            
        }
    }

  
}
