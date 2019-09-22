using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    // todo: move the classes into a hangman.Library 

    // todo: human Setter needs to interact with the human to get the information to return to the caller 
    // todo: computer setter just needs to return the information 

    public interface ISetter
    {
        bool Guess(char c);
        string Mask { get; }
        int Score { get; }
        bool Won { get; }
    }

    

    public class Monitor
    {
        // the list of characters already guessed 
        readonly IList<char> _guesses;
        // the target - as a mutable 
        readonly string _word;
        // the number of guesses allowed 
        const int TARGET = 10;
        // the character for mystery
        const char MYSTERY = '?';

        public int Score
        {
            get
            {
                // how many guesses are not in the word 
                return _guesses.Where(g => !_word.Contains(g)).Count();
            }
        }

        // a completed game - either the score is the highest possible (i.e. Lost) or the game is won 
        public bool Completed
        {
            get { return Score == TARGET || Won; }
        }

        // If the Mask contains no underline characters - the symbol chosen for mystery 
        public bool Won
        {
            get { return !Mask.Contains(MYSTERY); }
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
                IList<char> characters = 
                    _word
                        .Select(x => _guesses.Contains(x) ? x : MYSTERY)
                        .ToList();
                // turn a string into a list of characters, then join the list together with spaces 
                return string.Join(" ", characters.Select(x => x.ToString()).ToArray());
            }
        }

        /// <summary>
        /// Deal with the user guessing a word 
        /// </summary>
        /// <param name="word">the word the user is guessing </param>
        public Monitor(string word)
        {
            _word = word.ToLowerInvariant();
            _guesses = new List<char>();
        }

        /// <summary>
        /// Make a guess 
        /// </summary>
        /// <param name="guess">the next guess</param>
        /// <returns>was the guess in the word </returns>
        public bool Guess(char guess)
        {
            // add the guess to the list of guesses and then report if it is in the word 
            _guesses.Add(guess);
            return _word.Contains(guess.ToString());
        }
    }
}
