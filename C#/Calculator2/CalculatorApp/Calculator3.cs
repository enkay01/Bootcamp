using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Calculator3
    {
        public Calculator3()
        {

        }
        public int CalcAnswer(string op, List<int> numbers)
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
