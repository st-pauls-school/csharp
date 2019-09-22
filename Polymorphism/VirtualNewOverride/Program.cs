using PersonLibrary;
using System;
using System.Collections.Generic;


namespace VirtualNewOverride
{
    class Program
    {
        static void Main(string[] args)
        {



            DateTime dt = new DateTime(2001, 9, 11);

            #region 1
            // #1
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            BaseClass bcdc = new DerivedClass();

            List<BaseClass> lb = new List<BaseClass> { bc, dc, bcdc };
            // List<DerivedClass> ld = new List<DerivedClass> {  bc, dc, bcdc};

            bc.Method1();
            dc.Method1();
            dc.Method2();
            bcdc.Method1();
            #endregion

            #region 3
            //// #3            
            bcdc.Method2();

            #endregion


            Person p = new Person();

            Console.ReadKey();
        }

        class BaseClass
        {
            #region 6
            // #6 virtual 
            #endregion
            public virtual void Method1() 
            {
                Console.WriteLine("Base - Method1");
            }

            #region 2
            // #2
            public void Method2()
            {
                Console.WriteLine("Base - Method2");
            }
            #endregion

        }

        class DerivedClass : BaseClass
        {
            #region 5
            // // #5
            public override void Method1()
            {
                Console.WriteLine("Derived - Method1");
            }
            #endregion

            #region 4
            // #4 new 
            #endregion
            public new void Method2() 
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
