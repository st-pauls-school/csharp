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
            // Get the user to tap 'u' or 'c'. Note the use of the Environment.NewLine variable to insert a line break 
            Console.WriteLine("Who's going to guess? (U)ser or (C)omputer?{0}(or e(X)it)", Environment.NewLine);
            char input = ' ';
            while (!new List<char> { 'c', 'u', 'x' }.Contains(input))
                // ReadKey() does not return a character, but it can be cast to a string, then convert to lower case and then take the first character (of one) 
                input = Console.ReadKey().KeyChar.ToString().ToLowerInvariant()[0];

            if (input != 'x')
            {
                if (input == 'u')
                    ComputerSetter();
                if (input == 'c')
                    UserSetter();
                Console.ReadKey();
            }
        }

        static void ComputerSetter()
        {
            // read in the list of words into a list of strings 
            IList<string> words = File.ReadLines(@"words.txt").ToList();

            // then pick a random number from the list - set up the new Monitor object which deals with the computer monitoring the guesses 
            Monitor m = new Monitor(words[new Random().Next(words.Count)]);

            // loop until completion 
            while(!m.Completed)
            {
                // only accept an input between a and z (lower case) 
                char input = ' ';
                while(input < 'a' || input > 'z')
                {
                    input = Console.ReadKey().Key.ToString().ToLowerInvariant()[0];
                }
                // pass the guess into the monitor object, reporting if it was there and the correct score 
                // arguments to Console.WriteLine broken onto separate lines for clarity 
                Console.WriteLine("{3}{0} was {1}there ({2})", 
                    input, 
                    m.Guess(input) ? "" : "not ", 
                    m.Word, 
                    Environment.NewLine);
                // If not completed, update the user as to the state of their guess and their score 
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
            // ask the user how long their work is 
            Console.WriteLine("How many letters in your word?");
            int l = Int32.Parse(Console.ReadLine());
            // set up a new solver 
            Solver s = new Solver(l);

            while (!s.Complete)
            {
                // summarise the computer's thinking 
                Console.WriteLine("Current Thinking: {0}", s.ToString());
                // make a guess 
                char guess = s.Guess();
                // ask the user where the guess can be found 
                Console.WriteLine("I guess '{0}'. Is it there? (-1 for no, space separated list of zero-indexed locations)", guess);
                string response = Console.ReadLine().Trim();
                // todo: there is no validation done here 
                // split the list up using spaces, then take each in turn passing it to the parses and then write to a list 
                IList<int> locations = response.Split(' ').Select(x => Int32.Parse(x)).ToList();

                s.SetLocations(guess, locations);
            }
            // once finished, has the computer won or lost - or if the mask has no uncertainty, then question the user's spelling  
            if (s.Certain)
                Console.WriteLine("Your word is {0}", s.Candidates.ToList()[0]);
            else if (s.Lost)
                Console.WriteLine("You won! I still had {0} options.", s.Candidates.ToList().Count);
            else 
                Console.WriteLine("Are you sure {0} is a real word?", s.Mask);             
        }
    }
}
