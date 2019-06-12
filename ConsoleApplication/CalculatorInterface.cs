using System.Collections.Generic;

namespace ElementCalculatorConsoleApp
{
    public interface CalculatorInterface
    {
        SortedDictionary<string, int> Calculate(string input);
        string Print();
        string toString();
    }
}
