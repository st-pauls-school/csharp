using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;

namespace LookSay.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                Sequence s = new Sequence(int.Parse(args[0]));

                DoFor(s, int.Parse(args[1]), int.Parse(args[2]));
                return;
            }

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
                    ms = DoFor(s, index, index+1);
                }
            }

            Console.WriteLine("done, {0}ms", ms);
            Console.ReadKey();
        }

        /// <summary>
        /// Loops in the given range, writing to an output text file
        /// </summary>
        /// <param name="s"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        static long DoFor(Sequence s, int from, int to)
        {
            long ms = -1;
            using(StreamWriter sw = new StreamWriter("output.txt"))
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                for (int i = from; i <= to; i++)
                {
                    string res = s.Generate(i);
                    Console.WriteLine("{1}: about to write {0} chars", res.Length, i);
                    sw.WriteLine("[{0}]: {3}{1}{3}({2}){3}", i, res, res.Length, Environment.NewLine);
                    ms = timer.ElapsedMilliseconds;
                    string sf = $"clock: {i} in {ms}ms";
                    sw.WriteLine(sf);
                    Console.WriteLine(sf);
                }
                timer.Stop();
            }

            return ms;
        }
    }

}