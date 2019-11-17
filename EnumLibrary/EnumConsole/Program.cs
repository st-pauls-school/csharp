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

            string s = "Hearts";
            bool success = Enum.TryParse<Suits>(s, out Suits r);
            if (success)
                Console.WriteLine(r.ToString());
            else
                Console.WriteLine("That's not a suit");

            string m = "March";
            success = Enum.TryParse<Months>(m, out Months mo);

            if (success)
                Console.WriteLine(mo.ToString());
            else
                Console.WriteLine("That's not a month");

            int i = (int)mo;
            mo++;

            for(int mc = 0; mc < 24; mc++)
            {
                mo++;
                Months month = (Months)mc;
                Console.WriteLine("{0}: G-{1:G} D-{1:D} {2}", mc, month, mo.ToString());
               
            }


            

            Suits c = Suits.Hearts;
            bool isRed = (c & Suits.Red) == c;

            Console.WriteLine("The card's suit is: {0}", c);
            Console.WriteLine("The card is red: {0}", isRed);

//            Console.WriteLine("Sp|Di: {0}", (Suits.Spades | Suits.Diamonds).ToString());
            Console.Read();
        }
    }
}
