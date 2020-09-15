using System;
using System.Collections.Generic;
using System.Linq;

namespace BMO2019
{
    class Program
    {
        static void Main()
        {
            Q1();
            Q4();
            Q5();
            Console.ReadKey();
        }

        static IList<int> Primes(int ubound)
        {
            List<int> rv = new List<int> { 2 };
            IList<int> candidates = Enumerable.Range(1, ubound / 2).Select(i => 2 * i + 1).ToList();
            int candidate = 2;
            while (candidate < Math.Sqrt(ubound)) {
                candidate = candidates[0];
                rv.Add(candidate);
                candidates = candidates.Where(i => i % candidate != 0).ToList();
            }

            rv.AddRange(candidates);
            return rv;

        }

        static void Q1()
        {
            var primes = Primes(200);
            IList<int> a = new List<int>();
            IList<int> b = new List<int>();
            foreach (int i in primes)
            {
                if(primes.Contains(i+2) && primes.Contains(i + 6) && primes.Contains(i + 8) && primes.Contains(i + 12))
                {
                    a.Add(i);
                    if (primes.Contains(i + 14))
                        b.Add(i);
                }
            }
            Console.WriteLine("a: {0}", string.Join(", ", a));
            Console.WriteLine("b: {0}", string.Join(", ", b));
        }

        static void Q4()
        {
            IList<int> rv = new List<int> { 1 };
            for(int ticket = 2; ticket <= 2019; ++ticket)
            {
                int greatest = 0;
                for (int index = 0; index < rv.Count; ++index)
                {
                    if (ticket % rv[index] == 0 && rv[index] >= rv[greatest])
                    {
                        greatest = index;
                    }
                }
                rv.Insert(greatest+1, ticket);
            }
            Console.WriteLine("Q4a: {0}", rv.IndexOf(2));
            int i33 = rv.IndexOf(33);
            Console.WriteLine("Q4b: {0} {1} {2}", rv[i33-1], rv[i33], rv[i33+1]);
        }

        static void Q5()
        {
            IList<int> rv = new List<int>();
            for(int n = 7; n <100;++n)
            {
                IList<int> initial = new List<int> { n, 0, 0, 0, 0, 0 };
                IDictionary<string, bool> alreadyseen = new Dictionary<string, bool>();
                // using a stack because we're trying to prove existence, i.e. depth first traversal
                Stack<IList<int>> st = new Stack<IList<int>>();
                st.Push(initial);
                bool success = false;
                while(st.Count > 0)
                {
                    IList<int> next = st.Pop();
                    if(next.Where(i => i == next[0]).Count() == next.Count)
                    {
                        success = true;
                        Console.WriteLine("{0}: {1} [{2}]", n, string.Join(" ", next), alreadyseen.Count);
                        break;
                    }
                    for(int i = 0; i < 6; ++i)
                    {
                        if(next[i] >=4)
                        {
                            IList<int> newone = next.Select(item => item).ToList();
                            newone[i]-=4;
                            newone[(i+5) % 6]++; // cannot use a negative number 
                            newone[(i+1) % 6]++;
                            newone[(i+3) % 6]++;
                            if(!SeenBefore(alreadyseen, newone))
                                st.Push(newone);                            
                        }
                    }
                }
                if (success)
                    rv.Add(n);
            }
            Console.WriteLine("Q5: {0}", string.Join(" ", rv));
        }

        static bool SeenBefore(IDictionary<string, bool> alreadyseen, IList<int> newone)
        {
            int count = 0;
            string key;
            do
            {
                key = string.Join(" ", newone);
                if (alreadyseen.ContainsKey(key))
                    return true;
                int head = newone[0];
                newone.RemoveAt(0);
                newone.Add(head);
                count++;
            } while (count < 6);
            alreadyseen.Add(key, true);
            return false;
        }
    }
}
