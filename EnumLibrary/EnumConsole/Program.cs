using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumLibrary;

namespace EnumConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Suits c = Suits.Hearts;
  //          bool isRed = (c & Suits.Red) == c;

            Console.WriteLine("The card's suit is: {0}", c);
            Console.WriteLine("The card is red: {0}", isRed);

//            Console.WriteLine("Sp|Di: {0}", (Suits.Spades | Suits.Diamonds).ToString());
            Console.Read();
        }
    }
}
