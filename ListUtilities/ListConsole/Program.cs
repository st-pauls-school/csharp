using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listOfIntegers = new List<int>() { 1, 2, -4, 3, 4 };


            int s = listOfIntegers.Sum();
            int m1 = listOfIntegers.Min();

            List<int> negativeNumbers = 
                listOfIntegers
                    .Where(i => i < 0)
                    .Select(i => 2 *i)
                    .ToList();




            Double(listOfIntegers);


            foreach (int i in listOfIntegers)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

            listOfIntegers.Add(10);
            listOfIntegers.Add(123);

            // listOfIntegers.Clear();

            
            Console.ReadKey();

            listOfIntegers.Insert(0, -15);

            foreach (int i in listOfIntegers)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();

            listOfIntegers[0] -= 10;

            if(listOfIntegers.Contains(10))
                listOfIntegers.Remove(10);
            listOfIntegers.RemoveAt(0);
            


        }

        static int Double(int x)
        {
            x *= 2;
            return x;
        }

        static void Double(List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
                l[i] *= 2;
        }
        static List<int> CreateANewList(List<int> incoming)
        {
            List<int> returnValue = new List<int>() { 2, 3, 5, 7 };
            return returnValue;
        }
    }
}
