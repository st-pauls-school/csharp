using System;
using CountVonLibrary;

namespace CountVonConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CountVonCount counter = new CountVonCount(true, true, false);
            
            Console.WriteLine("below a thousand, longest is {0}, {1} chars", counter.Longest, counter.Longest.Length);

            Tuple<ulong, string, bool> t140 = counter.FindLongest(140);
            Console.WriteLine("{0} characters: {1}: {2}", 140, t140.Item1, t140.Item2);
            Tuple<ulong, string, bool> t280 = counter.FindLongest(280, true);
            Console.WriteLine("{0} characters: {1}: {2}", 280, t280.Item1, t280.Item2);

            HitAKey();
        }

        private static void HitAKey()
        {
            Console.WriteLine("Hit a key to continue ...");
            Console.ReadKey();
        }
    }
}
