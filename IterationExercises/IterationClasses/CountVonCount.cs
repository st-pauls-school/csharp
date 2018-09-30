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

        IList<string> _units = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        IList<string> _teens = new List<string> { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        IList<string> _tens = new List<string> { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        IList<string> _kilos = new List<string> { "thousand", "million", "billion", "trillion" };

        public CountVonCount(bool commas, bool ands, bool has)
        {
            _comma = commas ? "," : "";
            _and = ands ? "and" : "";
            _has = has ? " ah! ah! ah!" : "";
        }

        public List<Tuple<int, string>> NumbersOfIncreasingLength(int from, int to)
        {
            List<Tuple<int, string>> rv = new List<Tuple<int, string>>();
            int longest = 0;
            for (int counter = from; counter <= to; counter++)
            {
                string number = Generate((UInt64)counter);
                if (number.Length > longest)
                {
                    rv.Add(new Tuple<int, string>(counter, number));
                    longest = number.Length;
                }
            }
            return rv;
        }


        public string Generate(UInt64 number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GenerateNumber(number));
            sb.Append("!");
            sb.Append(_has);
            return sb.ToString();
        }

        string GenerateNumber(UInt64 number)
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

        public string TripleDigits(int number, bool notall)
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

    }
}
