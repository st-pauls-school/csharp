using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Student : Person
    {
        public Student(string f, string l,
            int y, int m, int d) 
            : this(f, l, new DateTime(y,m,d))
        {
        }

        public Student(string f, string l, DateTime dt) 
            : base(f, l)
        {
        }


    }

    public class Person
    {
        public Person(string f, string l, string e)
        {
            
        }

        public Person(string f, string l) : this(f, l, string.Empty)
        {
            

        }
    }
}
