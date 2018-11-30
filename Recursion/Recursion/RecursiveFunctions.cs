using System.Collections.Generic;

namespace Recursion
{
    public class RecursiveFunctions
    { 
        

        public static List<int> FirstNNaturalNumbers(int n)
        {
            if (n == 0)            
                return new List<int>();
            
            List<int> li = FirstNNaturalNumbers(n - ((n > 0) ? 1 : -1));
            li.Add(n);
            return li;
        }

        public static List<int> Split(int n)
        {
            if (n <= 0)
                return new List<int>();

            List<int> li = Split(n/10);
            li.Add(n%10);
            return li;
        }

        public static List<int> Fibonacci(int n)
        {
            if (n <= 1)
                return new List<int> { 1 };
            if (n <= 2)
                return new List<int> { 1, 1 };
            List<int> li = Fibonacci(n-1);
            li.Add(li[li.Count-1] + li[li.Count - 2]);
            return li;
        }
        public static bool IsPrime(int n, int factor = 2)
        {
            if (n < 2)
                return false;
            if (factor >= n)
                return true;
            if (n % factor == 0)
                return false;
            return IsPrime(n, factor + 1);
        }
    }
}
