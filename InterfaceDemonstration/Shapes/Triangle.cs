using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Triangle : IShape
    {
        public int Sides {  get { return 3; } }

        public double Area()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IShape other)
        {
            throw new NotImplementedException();
        }

        public double Perimeter()
        {
            throw new NotImplementedException();
        }
    }
}
