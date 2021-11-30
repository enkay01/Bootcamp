using System;

namespace Calculator2
{
    class Program
    {
       
        static string welcomeString;
        enum CalculatorType
        {
            Number,
            Date,
            Exit
        }
        static void Main(string[] args)
        {
            while (true)
            {
                try{
                    printWelcomeMessage();
                    int mode = getMode();
                    if (mode == 1)
                    {
                        NumberCalculator nc = new();
                    }
                    else if (mode == 2)
                    {
                        DateCalculator dc = new();
                    }
                    else if (mode == 3)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    else
                    {
                        showError(string.Format("Error. Please enter either {0}, {1}, or {2}.", (int) CalculatorType.Number, (int) CalculatorType.Date, (int) CalculatorType.Exit));
                    }
                }catch(InvalidOperatorException e)
                {
                    Console.WriteLine("There was an error: " + e.Message + "\n");
                }
            }
        }
        public static void printWelcomeMessage()
        {
            
            Console.WriteLine("Welcome to the calculator\n" +
                               "=========================");
        }
        static int getMode()
        {
            
            Console.Write("\nWhich mode do you want?\n" +
                                  "{0}) Numbers\n{1}) Dates\n{2}) Exit\n> ", (int) CalculatorType.Number, (int) CalculatorType.Date, (int) CalculatorType.Exit);
            int ans;
            if(int.TryParse(Console.ReadLine(), out ans))
            {
                return ans;
            }
            else
            {
                return -1;
            }
        }
        private static void showError(string errorM)
        {
            Console.WriteLine(errorM);

        }





    }
}
