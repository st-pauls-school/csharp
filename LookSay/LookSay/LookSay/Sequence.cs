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
        

        /// <summary>
        /// Generates all values up to, and including, that numbered sequence 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IList<string> GenerateList(int number)
        {
            while (_cache.Count < number)
            {
                string last = _cache.Last();
                _cache.Add(MakeNext(last));
            }

            return _cache.Take(number).ToList().AsReadOnly();
        }

        /// <summary>
        /// Takes a string of digits and returns the next 
        /// </summary>
        /// <param name="incoming"></param>
        /// <returns></returns>
        string MakeNext(string incoming)
        {
            // the string builder object is a much more efficient way of building up a string, adding strings together is quite expensive 
            StringBuilder sb = new StringBuilder();
            int u = 0;
            try
            {
                char previous = (char) 0;
                uint counter = 0;
                // loop through the string, looking at the next character and deciding if it is different 
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
                    u = sb.Length;
                }
                // don't forget to clear the cache 
                sb.Append(counter);
                sb.Append(previous);
            }
            catch (OutOfMemoryException ome)
            {
                // even on 76 this doesn't get triggered, so the memory might well be somewhere else ... 
                Console.WriteLine("{1}: ran out of SB at {0}", u, ome.Message);
                throw;
            }
            

            return sb.ToString();

        }
    }
}