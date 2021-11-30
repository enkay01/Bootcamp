using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to the calculator\n=============================");
            while (true)
            {
                Calculator c1 = new Calculator();
                c1.getOperator();
                c1.getInputs();

                Console.Write("Continue? Y/N: ");
                if (Console.ReadLine().ToUpper().Equals("N"))
                    break;
            }
        }
        private static void PerformOneCalculation()
        {
            var op = AskForOperator();
            var numbers = AskForNumberArray(op);
            var answer = CalculateAnswer(op, numbers);

            Console.WriteLine("The answer is: " + answer);
            Console.WriteLine();
        }

        private static string AskForOperator()
        {
            Console.Write("Please enter the operator: ");
            string op = Console.ReadLine();
            return op;
        }

        private static int[] AskForNumberArray(string op)
        {
            var count = AskForNumber("How many numbers do you want to " + op + "? ");

            int[] numbers = new int[count];
            for (int index = 0; index < count; index++)
            {
                numbers[index] = AskForNumber("Please enter number " + (index + 1) + ": ");
            }
            return numbers;
        }

        private static int AskForNumber(string message)
        {
            int count;

            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out count));

            return count;
        }

        private static int CalculateAnswer(string op, int[] numbers)
        {
            int answer = numbers[0];

            for (int index = 1; index < numbers.Length; index++)
            {
                if (op == "*")
                {
                    answer = answer * numbers[index];
                }
                else if (op == "/")
                {
                    answer = answer / numbers[index];
                }
                else if (op == "+")
                {
                    answer = answer + numbers[index];
                }
                else if (op == "-")
                {
                    answer = answer - numbers[index];
                }
            }
            return answer;
        }
    }



    class Calculator
    {
        char op = '+';
        int noNums;
        int n1;
        string operands = "";
        public Calculator()
        {

        }
        
        public void getOperator()
        {
            Console.WriteLine("Please enter the operator.");
            char tOp = Console.ReadLine().ToCharArray()[0];
            if (tOp == '+' || tOp == '-' || tOp == '*' || tOp == '/')
                op = tOp;
            
        }
        public void getInputs()
        {
            Console.WriteLine("How many numbers do you want to {0}?", op);
            this.noNums = int.Parse(Console.ReadLine());
            for(int i = 1; i <= noNums; i++)
            {
                Console.WriteLine("Please enter number {0}:", i);
                operands = operands + Console.ReadLine();
                if (i == 1)
                    n1 = i;
                if (i < noNums)
                    operands += ",";
            }
            this.show_res(this.doOp());
            
        }
        public void show_res(int res)
        {
            Console.WriteLine("The answer is {0}", res);
            Console.ReadLine();
        }
        public int doOp()
        {
            string[] numList = operands.Split(",");
            int runningT; if(int.TryParse(numList[0], out runningT))
            {
                for (int c = 1; c < numList.Length; c++)
                {
                    int x;
                    if (int.TryParse(numList[c].ToString(), out x))
                    {
                        if (this.op == '+')
                            runningT += x;
                        else if (this.op == '-')
                            runningT -= x;
                        else if (this.op == '*')
                            runningT *= x;
                        else
                            runningT /= x;

                        Console.WriteLine("Total is: {0}", runningT);
                    }
                    else
                    {
                        Console.WriteLine("Please only enter numbers. Cancelling operation...");
                        return -777;
                    }


                }
            }
            else
            {
                Console.WriteLine("Please only enter numbers. Cancelling operation...");
                return -777;
            }

            
            return runningT;
            
        }

    }
}
