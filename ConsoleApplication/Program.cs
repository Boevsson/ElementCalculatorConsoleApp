using System;

namespace ElementorCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the molecule structure: ");

            var input = Console.ReadLine();

            CalculatorInterface elementCalculator = new ElementCalculator();

            elementCalculator.Calculate(input);
            string result = elementCalculator.Print();

            Console.WriteLine(result);
        }
    }
}
