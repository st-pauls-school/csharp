using System;

namespace Shapes
{
    public interface IShape : IComparable<IShape>, IEquatable<IShape>
    {
        double Perimeter();
        double Area(); 
        int Sides { get; }
    }
}
