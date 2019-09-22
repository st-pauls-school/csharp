using System;
using System.Collections.Generic;

namespace SectionBQuestion6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input an integer: ");
            string inp = Console.ReadLine();
            int value;
            if(Int32.TryParse(inp, out value))
            {
                Console.Write("in reverse order: ");
                Stack<bool> values = new Stack<bool>();
                while(value > 0)
                {
                    bool bit = (value & 1) == 1;
                    values.Push(bit);
                    value >>= 1;
                    Console.Write("{0} ", bit ? "1" : "0");
                }
                Console.WriteLine();
                Console.Write("in correct order: ");
                while(values.Count != 0)
                    Console.Write("{0} ", values.Pop() ? "1" : "0");

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("That is not an integer");
            }
            Console.ReadLine();
        }
    }
}
