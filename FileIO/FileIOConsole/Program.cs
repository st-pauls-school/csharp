﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIOConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<string> stations = AllTheStations();
            Console.WriteLine("{0} stations", stations.Count);

            foreach(string t in new List<string> {  "mackarel", "piranha", "bacteria", "sturgeon", "St pauls School", "John Colet Day"})
            {
                IList<string> hits = SharesNoLettersWith(t, stations);
                Console.WriteLine("{0} - [{1}]: {2}", t, hits.Count, string.Join(", ", hits));
            }

            Console.ReadKey();
        }

        static IList<string> AllTheStations()
        {
            return 
                File
                    .ReadAllText("stations.txt")
                    .Split('\n')
                    .Select(l => l.Trim())
                    .Where(l => l.Contains(","))
                    .Select(l => l.Split(',')[0])
                    .ToList();
        }

        static bool DoesNotShareLettersWith(string thing, string target)
        {
            return 
                thing
                    .All(t => !target.Contains(t));
        }

        static IList<string> SharesNoLettersWith(string target, IList<string> stations)
        {
            return 
                AllTheStations()
                    .Where(s => DoesNotShareLettersWith(s.ToLowerInvariant(), target.ToLowerInvariant()))
                    .ToList();
        }
    }
}
