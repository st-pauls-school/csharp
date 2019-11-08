using System;
using System.Diagnostics;
using System.IO;

namespace LookSay.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Seed? ");
            string seed = Console.ReadLine();
            long ms = -1;
            if (int.TryParse(seed, out int iSeed))
            {
                Sequence s = new Sequence(iSeed);
                Console.Write("How many? ");
                string howMany = Console.ReadLine();
                if (int.TryParse(howMany, out int index))
                {
                    using(StreamWriter sw = new StreamWriter("output.txt"))
                    {
                        Stopwatch timer = new Stopwatch();
                        timer.Start();
                        for (int i = index-3; i <= index; i++)
                        {
                            string res = s.Generate(i);
                            sw.WriteLine("[{0}]: {1} ({2})", i, res, res.Length);
                            ms = timer.ElapsedMilliseconds;
                            string sf = $"clock: {i} in {ms}ms";
                            sw.WriteLine(sf);
                            Console.WriteLine(sf);
                        }
                        timer.Stop();
                    }
                }
            }

            Console.WriteLine("done, {0}ms", ms);
            Console.ReadKey();
        }
    }
}