using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ElementorCalculator
{
    public class ElementCalculator: CalculatorInterface
    {
        private readonly SortedDictionary<string, int> resultList = new SortedDictionary<string, int>();

        public SortedDictionary<string, int> Calculate(string input)
        {
            // [Cu(NH3)4(H2O)2]SO4
            Regex regex = new Regex(@"[A-Z][a-z]?\d*|\(.*?\)\d+");
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                // Handle inner molecules within brakets. Example: (NH3)4. The inner molecule is NH3.
                if (match.Value[0] == '(')
                {
                    // Regex the inner molecule
                    Regex innerRegex = new Regex(@"[A-Z][a-z]?\d*");
                    MatchCollection innerMatches = innerRegex.Matches(match.Value);

                    int closeBracketIndex = match.Value.IndexOf(')') + 1;

                    // Take the grand subscript of the whole molecule thats after the brackets. Example: (H2O)10. Grand subscript is 10.
                    string lastNumber = match.Value.Substring(closeBracketIndex, (match.Value.Length) - closeBracketIndex);

                    int gandSubscript = Convert.ToInt32(lastNumber);
                    
                    foreach (Match innerMatch in innerMatches)
                    {
                        this.AddToResult(innerMatch, gandSubscript);
                    }

                    continue;
                }

                this.AddToResult(match);
            }

            return this.resultList;
        }

        void AddToResult(Match match, int gandSubscript = 1)
        {
            int keyLength = match.Value.Length;
            int subscript = 1;
            bool withSubscript = false;

            // TODO: Make this support two digit subscript numbers in v1.1
            if (Char.IsDigit(match.Value[match.Value.Length - 1]))
            {
                keyLength = match.Value.Length - 1;
                withSubscript = true;
            }

            string key = match.Value.Substring(0, keyLength);
            string lastChar = match.Value[match.Value.Length - 1].ToString();

            if (withSubscript)
            {
                subscript = Convert.ToInt32(lastChar);
            }

            // Multiply the subscript with the grand subscript to get the total
            subscript *= gandSubscript;

            if (this.resultList.ContainsKey(key))
            {
                this.resultList[key] = this.resultList[key] + subscript;
            }
            else
            {
                this.resultList[key] = subscript;
            }
        }

        public string Print()
        {
            StringBuilder resultString = new StringBuilder();

            foreach (KeyValuePair<string, int> result in this.resultList)
            {
                resultString.Append(result.Key + result.Value);
            }

            return resultString.ToString();
        }

        public string toString()
        {
            return this.Print();
        }
    }
}
