using System.Collections.Generic;

namespace ElementorCalculator
{
    public interface CalculatorInterface
    {
        SortedDictionary<string, int> Calculate(string input);
        string Print();
        string toString();
    }
}
