using System;
using System.Collections.Generic;

namespace october
{
    class Program
    {
        static void Main(string[] args)
        {


            List<int> list1 = new List<int> { 10, 8, 5, 6 };
            Console.WriteLine(Median.GetTheMedianValue(list1) == 7d);
            List<int> list2 = new List<int> { 4, 1, 3, 2, 5 };
            Console.WriteLine(Median.GetTheMedianValue(list2) == 3d);
            List<int> list3 = new List<int> { 4, 1, 3, 2, 5, 0 };
            Console.WriteLine(Median.GetTheMedianValue(list3) == 2.5d);

            /*
            List<string> listOfStrings = new List<string> { "1", "Bob", "Seven", "TRUE", "3.5", "-2" };
            Console.WriteLine(ListFunctions.SumTheNumbers(listOfStrings) == 2.5);

            Console.WriteLine(!ListFunctions.IsSet(new List<int> { 1, 2, 5, 3, 4, 5 }));
            Console.WriteLine(ListFunctions.IsSet(new List<string> { "two", "three", "four", "a", "b", "z" }));

            Console.WriteLine(ListFunctions.AreEquivalent(new List<int> { 5, 4, 3, 2, 1 }, new List<int> { 1, 2, 3, 4, 5 }));
            Console.WriteLine(!ListFunctions.AreEquivalent(new List<int> { 1, 2, 3, 4, 5 }, new List<int> { 6, 1, 2, 3, 4, 5 }));
            */

            Console.WriteLine(HashedValues.GenerateHash("Recursive methods") == 68);
            Console.WriteLine(HashedValues.GenerateHash("St Paul's School") == 69);
            Console.WriteLine(HashedValues.GenerateHash("A-Level Computing") == 122);
            Console.WriteLine(HashedValues.GenerateHash("October Test") == 90);
            Console.WriteLine(HashedValues.GenerateHash("meaningful variable names") == 68);

            List<string> hashedstrings = HashedValues.ReadFromFile();
            foreach(string s in new List<string>() { "Using C# from Microsoft", "Visual Studio 2017", "Google Classroom",
                "Recursive methods", "St Paul's School", "A-Level Computing", "October Test",  "Computer Gallery", "Conditional expressions", "Console.WriteLine()", "tertiary using ? and :", "Boolean",
                "Old Science Block", "Selection", "29/10/18", "Bitwise AND - &", "Bitwise OR - |", "Bitwise XOR - ^",
                "Logical AND", 
                "Logical OR", "helpful comments", 
            })
            {
                int h = HashedValues.GenerateHash(s, 128);
                Console.WriteLine("{1}: {0}", s, h);
                hashedstrings[h] = s;
            }
            HashedValues.WriteToFile("hashedvalues.txt", hashedstrings);

            Console.WriteLine(HashedValues.HashedPosition("Google Classroom", hashedstrings) == 24);
            Console.WriteLine(HashedValues.HashedPosition("meaningful variable names", hashedstrings) == 70);
            Console.WriteLine(HashedValues.HashedPosition("Iteration", hashedstrings) == 123);
            Console.WriteLine(HashedValues.HashedPosition("Computer Science", hashedstrings) == -1);




            Console.WriteLine(Numbers.HighestCommonFactor(8, 6) == 2);
            Console.WriteLine(Numbers.HighestCommonFactor(27, 4) == 1);
            Console.WriteLine(Numbers.HighestCommonFactor(330, 910) == 10);

            Console.WriteLine(Numbers.LowestCommonMultiple(8, 6) == 2);
            Console.WriteLine(Numbers.LowestCommonMultiple(27, 4) == 1);
            Console.WriteLine(Numbers.LowestCommonMultiple(330, 910) == 10);

            Problem1.ThreeNPlusOne();
            

            Console.ReadKey();
        }
    }
    class Numbers
    {
        public static int HighestCommonFactor(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        public static int LowestCommonMultiple(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}
