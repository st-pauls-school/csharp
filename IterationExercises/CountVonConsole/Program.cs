using System;
using IterationClasses;

namespace CountVonConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var counter = new CountVonCount(true, true, false);

            var numbers = counter.NumbersOfIncreasingLength(1, 1000);

            string longest = numbers[numbers.Count - 1].Item2;
            int step = numbers[numbers.Count - 1].Item1;

            Console.WriteLine("below a thousand, longest is {0}, {1} chars", longest, longest.Length);

            int limit = 140;
            string tweet = longest;
            UInt64 value = (ulong)step;

            do
            {
                value *= 1000;
                value += (ulong)step;
                tweet = counter.Generate(value);
            } while (tweet.Length + longest.Length <= limit);

            Console.WriteLine("{0} would break. ({1})", tweet, tweet.Length);

            int powers = (int)Math.Ceiling(Math.Log10(value));

            for (int i = 0; i < numbers.Count; i++)
            {
                UInt64 trial = (UInt64)numbers[i].Item1 * (UInt64)Math.Pow(10, powers);
                trial += value;
                string trialString = counter.Generate(trial);
                Console.WriteLine("{0}: {1}", trialString.Length, trialString);

            }

            Console.ReadLine();
        }
    }
}
