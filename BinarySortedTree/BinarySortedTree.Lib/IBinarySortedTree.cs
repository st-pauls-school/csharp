using System;
using System.Collections.Generic;

namespace BinarySortedTree.Lib
{
    public interface IBinarySortedTree<T> where T : IComparable<T>, IEquatable<T>
    {
        void Insert(T val);
        void Delete(T val);
        IEnumerable<T> Output();
        int Depth { get; }
        T Sum { get; }
        bool Present(T target);
        T LowestCommonAncestor(T one, T two);
    }
}
