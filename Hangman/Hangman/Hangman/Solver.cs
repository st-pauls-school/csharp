using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class Solver
    {
        // maintain a list of possible candidates 
        IList<string> _candidates;
        // the length of the target 
        readonly int _length;
        // the backing field 
        string _mask;
        // the guesses 
        readonly IList<char> _guesses;
        // the score 
        int _incorrect;
        const char MYSTERY = '?';

        public bool Complete { get { return _candidates.Count <= 1 || _incorrect >= 10; } }
        public bool Certain { get { return _candidates.Count == 1; } }
        public IEnumerable<string> Candidates { get { return _candidates; } }
        public string Mask {  get { return _mask; } }
        public bool Lost {  get { return !Certain && _incorrect >= 10; } }

        /// <summary>
        /// Deal with the user setting the problem
        /// </summary>
        /// <param name="length">the length of the user's target word</param>
        public Solver(int length)
        {
            _length = length;
            // read in the candidates from a suitable text file (which is included in the solution and will be written to the output directory) 
            _candidates = File.ReadLines(@"words.txt").Where(w => w.Length == length).ToList();
            // The stringbuilder is a more efficient way to construct a string 
            StringBuilder sb = new StringBuilder();
            for (int c = 0; c < length; c++)
                sb.Append(MYSTERY);
            _mask = sb.ToString();
            _guesses = new List<char>();
            _incorrect = 0;
        }

        /// <summary>
        /// output the summary of the current state 
        /// </summary>
        /// <returns>a string</returns>
        public override string ToString()
        {
            return string.Format("Length: {0}. Mask: {1}. Candidates: {2}. Incorrect: {3}.", _length, _mask, _candidates.Count, _incorrect);
        }

        public char Guess()
        {
            IDictionary<char, int> counts = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
                if(!_guesses.Contains(c))
                   counts.Add(c, 0);
            foreach (string w in _candidates)
                foreach (char c in w.Distinct())
                    if(counts.Keys.Contains(c))
                        counts[c]++;
//            foreach (KeyValuePair<char, int> kvp in counts)
//                Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
            char nextguess = counts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return nextguess;

        }

        public void SetLocations(char guess, IList<int> locations)
        {
            IList<string> newcandidates = new List<string>();
            if(locations.Count == 0 || locations[0] == -1)
            {
                _incorrect++;
                foreach (string c in _candidates)
                    if (!c.Contains(guess))
                        newcandidates.Add(c);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i =  0; i < _length; i++)
                {
                    if (locations.Contains(i))
                        sb.Append(guess);
                    else
                        sb.Append(_mask[i] == '?' ? '?' : _mask[i]);
                }
                _mask = sb.ToString();
                foreach (string c in _candidates)
                {
                    bool match = true;
                    foreach(int l in locations)
                    {
                        if (c[l] != guess)
                            match = false;
                    }
                    if (match)
                        newcandidates.Add(c);
                }
            }
            _candidates = newcandidates;
            _guesses.Add(guess);
        }
    }
}
