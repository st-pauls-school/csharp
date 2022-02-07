using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

/* 
Numbers can be represented in a base indicated by an integer. In this questions bases
should be in the range [2, 16] (i.e. inclusive). Bases in between 11 and 16 should use the
characters A − F as required.
(a) Write program code that will asks the user to input a decimal value and a second value
indicating a base into which the first value should be converted. Include validation of
both inputs, with a suitable error message being output in the case of an error. [10]
(b) Create three test cases — one should be an error, the other two should indicate two
different bases. [6]
2. A pangram is a sentence which contains all the letters of the alphabet, non-letters are
ignored.
(a) Write program code that will ask the user to input a string and return a suitable
message as to whether or not that input is a pangram. Your code should be case
insensitive. [10]
(b) Create two test cases — one should be a pangram, the other should not. [4]
3. Multiplication is just repeated addition.

(a) Write program code, including a recursive function, which asks the user for two inte-
gers (x, y ∈ Z), multiplying them together using only the addition operation. Include

validation of both inputs, with suitable error messages. [10]
(b) Create three test cases — one should be an error, at least one of the other two should
include a negative value.
*/

namespace FebruaryExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert((39, 3) == TwoIntegers("39 3"));
            Debug.Assert((-3, -39) == TwoIntegers("-3 -39"));
            Q1();
            Debug.Assert(IsPangram("abcdefghijklmNOPQRSTUVWXYZ"));
            Debug.Assert(IsPangram("abc.defg.hij34klm..NOPQRSTU(VWXYZ)"));
            Debug.Assert(!IsPangram("abcdefghijklmRSTUVWXYZabcdefghijklmRSTUVWXYZ"));
            Q2();
            Debug.Assert(Multiply(7, 7) == 49);
            Debug.Assert(Multiply(10, -7) == -70);
            Debug.Assert(Multiply(-7, -6) == 42);
            Debug.Assert(Multiply(-7, 6) == -42);
            Q3();
        }

        static void Q3()
        {
            (int multiplier, int multiplicand) pair = GetTwoIntegers("give me two numbers, separated by a space:");
            Console.WriteLine($"the product is {Multiply(pair.multiplicand, pair.multiplier)}");
        }

        static int Multiply(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;
            if (a < 0)
                return -1 * Multiply(-a, b);
            return b + Multiply(a - 1, b);
        }

        static void Q2()
        {
            Console.WriteLine("give me a sentence:");
            string output = IsPangram(Console.ReadLine()) ? "" : "not ";
            Console.WriteLine($"That sentence is {output}a Pangram");
        }

        static bool IsPangram(string candidate)
        {
            candidate = candidate.ToLowerInvariant();
            return Enumerable.Range(0, 26).All(offset => candidate.Contains((char)('a' + offset)));
        }

        static void Q1()
        {
            (int number, int tobase) values = GetTwoIntegers("Please give a number and base, separated by a space:");
            IList<char> characters = Enumerable.Range(0, values.tobase).Select(i => i < 10 ? i.ToString()[0] : (char)((i - 10) + 'A')).ToList();
            int value = values.number;
            List<char> rv = new();
            while (value > 0)
            {
                rv.Insert(0, characters[value % values.tobase]);
                value -= value % values.tobase;
                value /= values.tobase;
            }
            Console.WriteLine($"{values.number}_10 = {string.Join("", rv)}_{values.tobase}");
        }

        static (int, int) TwoIntegers(string s)
        {
            Regex rx = new Regex(@"(\-?)(\d+) (\-?)(\d+)");
            Match m = rx.Match(s);
            if (!m.Success)
                throw new Exception("no");
            int first = Convert.ToInt32(m.Groups[2].Value) * (m.Groups[1].Value == "-" ? -1 : 1);
            int second = Convert.ToInt32(m.Groups[4].Value) * (m.Groups[3].Value == "-" ? -1 : 1);
            return (first, second);
        }

        static (int, int) GetTwoIntegers(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string userInput = Console.ReadLine();

                try
                {
                    (int, int) rv = TwoIntegers(userInput);
                    return rv;

                }
                catch (Exception _)
                {

                }
            }
        }
    }
}
