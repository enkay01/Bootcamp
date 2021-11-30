using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    class DateCalculator
    {

        private const string datePrompt = "\nPlease enter a date: ";
        private const string dayPrompt = "\nPlease enter the number of days to add: ";
        public DateCalculator()
        {
            performOneCalculation();
        }
        public void performOneCalculation()
        {
            DateTime dt = AskForDate();
            int dy = AskForDays();
            Console.WriteLine("The answer is: {0}", AddDays(dt, dy));
        }
        public DateTime AskForDate()
        {
            DateTime date;
            do
            {
                Console.Write(datePrompt);


            } while (!DateTime.TryParse(Console.ReadLine(), out date));
            return date;
        }
        public int AskForDays()
        {
            int days;
            do
            {
                Console.Write(dayPrompt);
            } while (!int.TryParse(Console.ReadLine(), out days));
            return days;
        }
        public DateTime AddDays(DateTime date, int days)
        {
            return date.AddDays(days);
        }



    }

}
