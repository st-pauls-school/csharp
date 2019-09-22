using System;
using System.Collections.Generic;
using System.Text;

namespace IterationClasses
{
    public class CountVonCount
    {
        readonly string _comma;
        readonly string _and;
        readonly string _has;
        readonly IList<Tuple<int, string>> _numbers;

        IList<string> _units = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        IList<string> _teens = new List<string> { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        IList<string> _tens = new List<string> { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        IList<string> _kilos = new List<string> { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion" };

        public string Longest => _numbers[_numbers.Count - 1].Item2;
        public int Step => _numbers[_numbers.Count - 1].Item1;

        public CountVonCount(bool commas, bool ands, bool has)
        {
            _comma = commas ? "," : "";
            _and = ands ? "and" : "";
            _has = has ? " ah! ah! ah!" : "";
            
            _numbers = NumbersOfIncreasingLength(1, 1000);

        }

        /// <summary>
        /// The longest numbers are they increase in value
        /// </summary>
        /// <param name="from">the lower bound of the range</param>
        /// <param name="to">the upper bound</param>
        /// <returns>lengthening numbers as they increas in value</returns>
        public IList<Tuple<int, string>> NumbersOfIncreasingLength(int from, int to)
        {
            IList<Tuple<int, string>> rv = new List<Tuple<int, string>>();
            int longest = 0;
            for (int counter = from; counter <= to; counter++)
            {
                string number = Generate((ulong)counter);
                if (number.Length > longest)
                {
                    rv.Add(new Tuple<int, string>(counter, number));
                    longest = number.Length;
                }
            }
            return rv;
        }

        /// <summary>
        /// the written form of a number as spoken by the Count. 
        /// </summary>
        /// <param name="number">the number</param>
        /// <returns>the text equivalent</returns>
        public string Generate(ulong number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GenerateNumber(number));
            sb.Append("!");
            sb.Append(_has);
            return sb.ToString();
        }

        /// <summary>
        /// the private method, without any paraphenalia 
        /// </summary>
        /// <param name="number">the number</param>
        /// <returns>the words</returns>
        string GenerateNumber(ulong number)
        {
            StringBuilder sb = new StringBuilder();
            if (number == 0)
            {
                sb.Append("zero");
            }
            int triple_counter = 0;
            while (number > 0)
            {
                string ttt = TripleDigits((int)(number % 1000), number >= 1000);
                if (triple_counter > 0 && !string.IsNullOrEmpty(ttt))
                {
                    if (sb.Length > 0)
                    {
                        if (!sb.ToString().StartsWith(" ", StringComparison.InvariantCulture))
                        {
                            sb.Insert(0, " ");
                        }
                        if (!sb.ToString().StartsWith(" and", StringComparison.InvariantCulture))
                            sb.Insert(0, _comma);

                    }
                    sb.Insert(0, _kilos[triple_counter - 1]);
                    sb.Insert(0, ' ');
                }
                sb.Insert(0, ttt);
                number /= 1000;
                triple_counter++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// the final three digits in words 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="notall"></param>
        /// <returns></returns>
        string TripleDigits(int number, bool notall)
        {
            if (number == 0)
            {
                return string.Empty;
            }
            string rv = DoubleDigits(number % 100);
            if (number < 100)
            {
                return (notall ? _and + " " : string.Empty) + rv;
            }
            if (!string.IsNullOrEmpty(rv))
            {
                rv = (string.IsNullOrEmpty(_and) ? "" : _and + " ") + rv;
            }

            number /= 100;
            int j = number % 10;
            number /= 10;
            if (j > 0)
            {
                if (!string.IsNullOrEmpty(rv))
                {
                    rv = " " + rv;
                }

                rv = _units[j] + " hundred" + rv;

            }
            return rv;
        }

        /// <summary>
        /// the final two digits in words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string DoubleDigits(int number)
        {
            if (number == 0)
            {
                return string.Empty;
            }
            if (number < 10)
            {
                return _units[number];
            }
            if (number < 20)
            {
                return _teens[number - 10];
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(_tens[number / 10]);
            if (number % 10 != 0)
            {
                sb.Append("-");
                sb.Append(_units[number % 10]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Given the maximum number of characters, just how high can we go? 
        /// </summary>
        /// <param name="limit">number of characters</param>
        /// <param name="debug">show your working</param>
        /// <returns>how high we can go</returns>
        public Tuple<ulong, string> FindLongest(int limit, bool debug=false)
        {
            string tweet = Longest;
            ulong value = (ulong)Step;

            ulong previous = 0;
            do
            {
                try
                {
                    checked
                    {
                        value *= 1000;
                        value += (ulong)Step;
                    }
                    tweet = Generate(value);
                    if (debug)
                        Console.WriteLine("{0}/{1}/{2}", tweet.Length, value, tweet);
                    if (value < previous)
                    {
                        Console.WriteLine("We've broken ulong");
                        break;
                    }
                    previous = value;
                } catch()

            } while (tweet.Length + Longest.Length <= limit);


            int powers = (int)Math.Ceiling(Math.Log10(value));

            ulong largest = value;
            for (int i = 0; i < _numbers.Count; i++)
            {
                ulong trial = (ulong)_numbers[i].Item1 * (ulong)Math.Pow(10, powers);
                trial += value;
                string trialString = Generate(trial);
                if(debug)
                    Console.WriteLine("{0}: {1}", trialString.Length, trialString);
                if (trialString.Length <= limit && trial > largest)
                    largest = trial;
            }
            var rv = new Tuple<ulong, string>(largest, Generate(largest));
            if(debug)
                Console.WriteLine("I think the largest is going to be: {0}", rv.Item2);
            return rv;
        }
    }
}
