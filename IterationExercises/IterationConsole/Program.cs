using IterationLibrary;
using System;

namespace IterationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1 (noisy):");
            NonQuietFunctions.Countdown(10);
            Console.WriteLine("Question 1 (quiet):\n{0}", QuietFunctions.CountDown(10));
            Console.ReadKey();
        }
    }
}
