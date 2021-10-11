using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digits.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Mode(new List<int> { 3, 4, 5, 3 }) == 2);
            Debug.Assert(Mode(new List<int> { 3, 4, 5, 3, 4 }) == null);

            int c = int.Parse(Console.ReadLine());
            IList<int> l = new List<int>();
            for (int i = 0; i < c; ++i)
                l.Add(int.Parse(Console.ReadLine()));
            int? result = Mode(l);
            if (result.HasValue)
                Console.WriteLine($"The answer is {result.Value}");
            else
                Console.WriteLine("Data was multimodal");
            Console.ReadKey();
        }

        static int? Mode(IList<int> integers)
        {
            IDictionary<int, int> counter = new Dictionary<int, int>();
            foreach(int i in integers)
            {
                if (counter.Keys.Contains(i))
                    ++counter[i];
                else
                    counter.Add(i, 1);
            }
            int? rv = null;
            int mostfrequent = -1;
            foreach(KeyValuePair<int,int> kvp in counter)
            {
                if (kvp.Value == mostfrequent)
                    rv = null;
                if (kvp.Value > mostfrequent)
                {
                    mostfrequent = kvp.Value;
                    rv = kvp.Key;
                }
            }
            return rv.HasValue ? (int?)mostfrequent : null;            
        }
    }
}
