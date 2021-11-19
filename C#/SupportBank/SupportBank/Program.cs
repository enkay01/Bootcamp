using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NLog.Config;
using NLog.Targets;
using NLog;

namespace SupportBank
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Work\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            
            string [] data = FileReader.ReadFile("C:\\Users\\Ian.Nkwocha\\OneDrive\\Documents\\Development\\Training\\Bootcamp\\C#\\SupportBank\\SupportBank\\DodgyTransactions2015.csv", true);
            
            Dictionary<string, Account> accounts = FileReader.BuildAccountDict(data);

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
                    
                    string name = PromptName();
                    if(accounts.TryGetValue(name, out Account acc))
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
                        Console.WriteLine(kp.Value.ToString());
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
