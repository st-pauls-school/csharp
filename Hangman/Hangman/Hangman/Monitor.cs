using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class Monitor
    {
        readonly IList<char> _guesses;
        readonly string _word;
        const int TARGET = 10;

        public int Score
        {
            get
            {
                return _guesses.Where(g => !_word.Contains(g)).Count();
            }
        }

        public bool Completed
        {
            get { return Score == TARGET || Won; }
        }

        public bool Won
        {
            get { return !Mask.Contains('_'); }
        }

        public string Word
        {
            get
            {
                return _word;
            }
        }

        public string Mask
        {
            get
            {
                IList<char> characters = _word.Select(x => _guesses.Contains(x) ? x : '_').ToList();
                return string.Join(" ", characters.Select(x => x.ToString()).ToArray());
            }
        }

        public string Word1 => _word;

        public Monitor(string word)
        {
            _word = word.ToLowerInvariant();
            _guesses = new List<char>();
        }

        public bool GuessedAlready(char guess)
        {
            return _guesses.Contains(guess);
        }


        public bool Guess(char guess)
        {
            _guesses.Add(guess);
            return _word.Contains(guess.ToString());
        }
    }
}
