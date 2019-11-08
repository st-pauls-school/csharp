using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LookSay
{
    public class Sequence
    {
        readonly IList<string> _cache;
        

        public Sequence(int seed)
        {
            _cache = new List<string> { seed.ToString()};
        }

        public string Generate(int number)
        {
            string result = _cache[0];
            for (int i = 0; i < number; i++)
                result = MakeNext(result);
            return result;
        }
        
        public IList<string> GenerateList(int number)
        {
            while (_cache.Count < number)
            {
                string last = _cache.Last();
                _cache.Add(MakeNext(last));
            }

            return _cache.Take(number).ToList().AsReadOnly();
        }

        string MakeNext(string incoming)
        {
            StringBuilder sb = new StringBuilder();
            char previous = (char)0;
            uint counter = 0;
            foreach (char c in incoming)
            {
                if (c == previous)
                {
                    counter++;
                    continue;
                }

                if (counter > 0)
                {
                    sb.Append(counter);
                    sb.Append(previous);
                }

                previous = c;
                counter = 1;
            }
            sb.Append(counter);
            sb.Append(previous);

            return sb.ToString();

        }
    }
}