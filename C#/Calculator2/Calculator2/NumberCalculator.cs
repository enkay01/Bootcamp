using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    
    class NumberCalculator
    {
        string nNumbersPrompt = "How many numbers do you want to {0}";
        string numberPrompt = "Please enter the next number:";

        public NumberCalculator() 
        {
            performOneCalculation();
        }
        private string AskForOperator()
        {
            while (true)
            {
                Console.Write("Please enter the operator: ");
                char op = Console.ReadLine().ToCharArray()[0];
                if (op == '+' || op == '-' || op == '*' || op == '/')
                {
                    return op + "";
                }
            }
        }
        public void performOneCalculation()
        {
            var op = AskForOperator();
            List<int> numbers = AskForOperands(numberPrompt);
            if(numbers.Count > 0)
            {
                var answer = CalcAnswer(op, numbers);

                Console.WriteLine("The answer is: " + answer);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Cancelling operation...");
            }
            
        }
        private int[] AskForNumberArray(string op)
        {
            var count = AskForNumber(nNumbersPrompt, op);

            int[] numbers = new int[count];
            for (int index = 0; index < count; index++)
            {
                numbers[index] = AskForNumber(numberPrompt, "" + index+1);
            }
            return numbers;
        }
        

        private int AskForNumber(string message, string op)
        {
            int count;

            do
            {
                Console.Write(message, op);
            } while (!int.TryParse(Console.ReadLine(), out count));

            return count;
        }
        private List<int> AskForOperands(string message)
        {
            List<int> operands = new List<int>();
            int num;
            
            while (true)
            {
                Console.Write(message);
                string l = Console.ReadLine();
                if (l.Equals(""))
                    break;
                if(int.TryParse(l, out num))
                {
                    operands.Add(num);
                }

            }
            return operands;
        }
        
        private int CalcAnswer(string op, List<int> numbers)
        {
            switch (op)
            {
                case "*":
                    return numbers.Aggregate(1, (acc, number) => acc * number);
                case "/":
                    return numbers.Skip(1).Aggregate(numbers[0], (acc, number) => acc / number);
                case "+":
                    return numbers.Sum();
                case "-":
                    return numbers.Skip(1).Aggregate(numbers[0], (acc, number) => acc - number);
                default:
                    return -1;
                    
            }
            
        }

    }
}
