using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Feasible("EAT", "ATE"));
            Debug.Assert(Feasible("EAT", "HEART"));
            Debug.Assert(Feasible("TO", "POSITION"));
            Debug.Assert(!Feasible("MEET", "MEAT"));

            Console.Write("A: ");
            string wordA = Console.ReadLine();
            Console.Write("B: ");
            string wordB = Console.ReadLine();

            bool feasible = Feasible(wordA, wordB);
            string can = feasible ? "can" : "cannot";
            Console.WriteLine($"You {can} make {wordA} from the letters of the word {wordB}");
            Console.ReadKey();
        }
        static bool Feasible(string wordA, string wordB)
        {
            IList<char> bCharacters = wordB.Select(c => c).ToList();
            bool feasible = true;
            foreach (char ch in wordA)
            {
                if (bCharacters.Contains(ch))
                    bCharacters.Remove(ch);
                else
                {
                    feasible = false;
                    break;
                }
            }
            return feasible;
        }
    }
}
