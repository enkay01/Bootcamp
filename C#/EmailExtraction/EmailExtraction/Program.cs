using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string text = File.ReadAllText("C:\\Users\\Ian.Nkwocha\\OneDrive\\Documents\\Development\\Training\\Bootcamp\\C#\\EmailExtraction\\EmailExtraction\\sample.txt");
                Dictionary<string, int> emails = new();


                Regex emailRegex = new(@"([\w\.\-])+(\@)+[A-z]+(\.)+(\w){2,3}\.*(\w)*");
                MatchCollection matches = emailRegex.Matches(text);
                Console.WriteLine("{0} emails found", matches.Count);

                foreach(Match match in matches)
                {
                    string domain = match.ToString()[match.ToString().IndexOf("@")..].Trim();
                    if(emails.TryAdd(domain, 1)){
                        Console.WriteLine(domain);
                    }
                    else
                    {
                        emails[domain]++;
                    }

                }
                Console.WriteLine("{0} softwire emails found", emails["@softwire.com"]);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
