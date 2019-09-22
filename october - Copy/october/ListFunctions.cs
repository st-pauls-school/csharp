using System;
using System.Collections.Generic;

namespace october
{
    class ListFunctions
    {
        public static double SumTheNumbers(List<string> values)
        {
            // take the list of strings and return the sum of the numbers contained. If the string is not a number it counts as 0. 
            double sum = 0;
            foreach(string v in values)
            {
                double candidate;
                if (double.TryParse(v, out candidate))
                    sum += candidate;
            }
            return sum;
        }

        public static bool IsSet<T>(List<T> list)
        {
            throw new NotImplementedException();
        }

        internal static bool AreEquivalent(List<int> list1, List<int> list2)
        {
            throw new NotImplementedException();
        }
    }
}
