using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hangman.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Who's going to guess? (U)ser or (C)omputer?");
            char input = ' ';
            while (input.ToString().ToLowerInvariant() != "u" && input.ToString().ToLowerInvariant() != "c")
                input = Console.ReadKey().KeyChar;
            if (input == 'u')
                ComputerSetter();
            else
                UserSetter();
            Console.ReadKey();
        }

        static void ComputerSetter()
        {
            IList<string> words = File.ReadLines(@"words.txt").ToList();
            Monitor m = new Monitor(words[new Random().Next(words.Count)]);
            while(!m.Completed)
            {
                char input = ' ';
                while(input < 'a' || input > 'z')
                {
                    input = Console.ReadKey().Key.ToString().ToLowerInvariant()[0];
                }
                Console.WriteLine("{3}{0} was {1}there ({2})", input, m.Guess(input) ? "" : "not ", m.Word, Environment.NewLine);
                if (!m.Completed)
                    Console.WriteLine("Score {0}/10.{1}{2}", m.Score, Environment.NewLine, m.Mask);
                input = ' ';
            }
            if (m.Won)
                Console.WriteLine("You won!");
            else
                Console.WriteLine("You lost!");
        }

        static void UserSetter()
        {
            Console.WriteLine("How many letters in your word?");
            int l = Int32.Parse(Console.ReadLine());
            Solver s = new Solver(l);

            while (!s.Complete)
            {
                Console.WriteLine("Current Thinking: {0}", s.ToString());

                char guess = s.Guess();
                Console.WriteLine("I guess '{0}'. Is it there? (-1 for no, space separated list of zero-indexed locations)", guess);
                string response = Console.ReadLine();
                IList<int> locations = response.Split(' ').Select(x => Int32.Parse(x)).ToList();
                s.SetLocations(guess, locations);


            }
            if (s.Certain)
                Console.WriteLine("Your word is {0}", s.Candidates.ToList()[0]);
            else if (s.Lost)
                Console.WriteLine("You won! I still had {0} options.", s.Candidates.ToList().Count);
            else 
                Console.WriteLine("Are you sure {0} is a real word?", s.Mask);
                

        }
    }
}
