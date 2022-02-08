using System;
using System.Collections.Generic;

namespace VirtualNewOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            // follow the points of interest - POIn - in order 
            // based on the example: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords 

            // POI1 - we define 3 variables in various forms of our base/derived classes 
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            BaseClass bcdc = new DerivedClass();

            Console.WriteLine("Method 1");
            // when we run these, which methods are actually being run? 
            bc.Method1();
            dc.Method1();
            bcdc.Method1(); // in particular which one of these? 

            List<BaseClass> listOfBase = new List<BaseClass> { bc, dc, bcdc };
            Console.WriteLine("Iterate");
            foreach (BaseClass b in listOfBase)
                b.Method1();

            Console.WriteLine("Method 2");
            // POI 6 uncomment these two calls, now that method2 is defined in the base class 
            // bc.Method2();
            dc.Method2();
            // bcdc.Method2();

            // Note that we can never uncomment this - bc and bcdc are never allowed to be Derived classes 
            // List<DerivedClass> ld = new List<DerivedClass> {  bc, dc, bcdc};

            Console.ReadKey();
        }

        class BaseClass
        {            
            // POI3 add a virtual here to indicate that we _can_ override it 
            public void Method1() 
            {
                Console.WriteLine("Base - Method1");
            }


            // POI5 uncomment this method 
            /*
            public void Method2()
            {
                Console.WriteLine("Base - Method2");
            }
            */

        }

        class DerivedClass : BaseClass
        {            
            // POI2 - in the first place, this gives a warning because we have hidden the base version 
            // POI4 - add an override here to show that we've overridden it 
            public void Method1()
            {
                Console.WriteLine("Derived - Method1");
            }
                        
            // POI6 - now this methods exists in the base class, this gives a warning 
            // POI7 - add the new keyword - it doesn't change the behaviour, but it does suppress the warning 
            public void Method2() 
            {                
                Console.WriteLine("Derived - Method2");
            }

            public void Method3()
            {
                Console.WriteLine("Derived - Method3");

            }
        }
    }
}
