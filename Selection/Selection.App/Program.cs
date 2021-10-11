using System;

namespace Selection.App
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while(!quit)
            {
                Console.WriteLine("Enter 1-7, or (Q)uit");
                ConsoleKeyInfo c = Console.ReadKey();
                switch(c.KeyChar)
                {
                    case('1'):
                        Question1();
                        break;
                    case('q'):
                    case('Q'):
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("unknown option");
                        break;
                }
            }            

        }

        static void Question1()
        {
            Console.Write("Integer 1: ");
            string integerInput = Console.ReadLine();
            int i1;
            if(!Int32.TryParse(integerInput, out i1))
            {
                Console.WriteLine("That's not an integer");
                return;
            }
            Console.Write("Integer 2: ");
            string integerInput2 = Console.ReadLine();
            int i2;
            if(!Int32.TryParse(integerInput2, out i2))
            {
                Console.WriteLine("That's not an integer");
                return;
            }

            string addition = string.Empty;
            if(i1 != i2)
                addition = "not ";
            
            string msg = "The two integers are " + addition + "the same";
            Console.WriteLine(msg);

        }
    }
}
